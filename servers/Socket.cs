﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using servers.Chat;
using Sprache;

namespace servers
{
    public class SocketServer
    {
        private TcpListener _server;
        private readonly ConcurrentDictionary<string, TcpClient> _clients;
        private CancellationTokenSource _cancellationTokenSource;
        private ServerControllers _serverControllers;
        private ChatControllers _chatControllers;

        public SocketServer()
        {
            _clients = new ConcurrentDictionary<string, TcpClient>();
            _serverControllers = new ServerControllers();
            _chatControllers = new ChatControllers();
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

                    var data = ToDictionary(request);
                    string userId = data.UserId;
                    if (!string.IsNullOrEmpty(userId))
                    {
                        _clients.TryAdd(userId, client);
                    }
                    
                    Console.WriteLine($"Received from {userId}: {request}");
                    var requestParse = JsonConvert.DeserializeObject<Schemas.Request>(request);
                    if (requestParse.Route == "chat")
                    {
                        string message = requestParse.Data["message"].ToString();
                        string gameId = requestParse.Data["gameId"].ToString();
                        string receiverId = await _chatControllers.GetReceiverId(requestParse.UserId, requestParse.Data["gameId"].ToString());
                        if (!string.IsNullOrEmpty(receiverId))
                        {
                            await _chatControllers.Save(gameId, requestParse.UserId, receiverId, message);
                            // Send message to another user
                            if (_clients.TryGetValue(receiverId, out TcpClient anotherClient))
                            {
                                var anotherStream = anotherClient.GetStream();
                                var dataSender = new Dictionary<string, object>
                                {
                                    { "message", message },
                                    { "senderId", requestParse.UserId }
                                };
                                string response = Schemas.ToResponse(true, 30, "New message", dataSender);
                                var messageBytes = Encoding.UTF8.GetBytes(response);
                                await anotherStream.WriteAsync(messageBytes, 0, messageBytes.Length, token);
                            }
                        }
                    }
                    else
                    {
                        string result = await _serverControllers.HandleRequest(request);
                        Console.WriteLine($"Response to {userId}: {result}");
                        var response = Encoding.UTF8.GetBytes(result);
                        await stream.WriteAsync(response, 0, response.Length, token);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error when handle request: {ex.Message}");
            }
            finally
            {
                DisconnectClient(client, null);
            }
        }

        private void DisconnectClient(TcpClient client, string userId)
        {
            if (userId != null)
            {
                _clients.TryRemove(userId, out _);
            }
            client.Close();
        }
    }
}
