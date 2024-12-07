using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace servers
{
    public class SocketServer
    {
        private TcpListener _server;
        private readonly ConcurrentDictionary<string, TcpClient> _clients;
        private CancellationTokenSource _cancellationTokenSource;
        private ServerControllers _serverControllers;

        public SocketServer()
        {
            _clients = new ConcurrentDictionary<string, TcpClient>();
            _serverControllers = new ServerControllers();
        }

        public void Start(string ipAddress, int port)
        {
            _server = new TcpListener(IPAddress.Parse(ipAddress), port);
            _server.Start();
            Console.WriteLine($"Server started on {ipAddress}:{port}");

            _cancellationTokenSource = new CancellationTokenSource();
            _ = AcceptClientsAsync(_cancellationTokenSource.Token);
        }

        public void Stop()
        {
            Console.WriteLine("Stopping server...");
            _cancellationTokenSource.Cancel();
            _server.Stop();

            foreach (var client in _clients.Values)
            {
                client.Close();
            }

            _clients.Clear();
        }

        private async Task AcceptClientsAsync(CancellationToken token)
        {
            try
            {
                while (!token.IsCancellationRequested)
                {
                    var client = await _server.AcceptTcpClientAsync();
                    Console.WriteLine("User connected.");

                    _ = HandleClientAsync(client, token); // Xử lý client trong task riêng
                }
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Accepting clients stopped.");
            }
        }

        public static Schemas.Request ToDictionary(string jsonString)
        {
            return JsonConvert.DeserializeObject<Schemas.Request>(jsonString);
        }

        private async Task HandleClientAsync(TcpClient client, CancellationToken token)
        {
            var stream = client.GetStream();
            var buffer = new byte[1024];

            try
            {
                int bytesRead;

                // Xử lý giao tiếp với client
                while (!token.IsCancellationRequested)
                {
                    bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length, token);
                    if (bytesRead == 0) break; // Client đóng kết nối

                    var request = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    Console.WriteLine($"Received: {request}");
                    var data = ToDictionary(request);
                    Console.WriteLine(data);
                    string userId = data.UserId;
                    if (!string.IsNullOrEmpty(userId))
                    {
                        if (!_clients.TryAdd(userId, client))
                        {
                            Console.WriteLine($"User ID {userId} already exists. Closing connection.");
                            client.Close();
                            return;
                        }
                    }
                    
                    Console.WriteLine($"Received from {userId}: {data}");

                    var result = await _serverControllers.HandleRequest(request);
                    var response = Encoding.UTF8.GetBytes(result);
                    Console.WriteLine("Response: ", response);
                    await stream.WriteAsync(response, 0, response.Length, token);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error when handle request: {ex.Message}");
            }
            finally
            {
                DisconnectClient(client);
            }
        }

        private void DisconnectClient(TcpClient client)
        {
            var entry = _clients.FirstOrDefault(kvp => kvp.Value == client);
            if (!string.IsNullOrEmpty(entry.Key))
            {
                _clients.TryRemove(entry.Key, out _);
                Console.WriteLine($"Client disconnected: {entry.Key}");
            }

            client.Close();
        }
    }
}
