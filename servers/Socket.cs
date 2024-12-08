using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Driver.Core.Events;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using servers.Chat;
using servers.Users;
using Sprache;
using static servers.Schemas;

namespace servers
{
    public class SocketServer
    {
        private TcpListener _server;
        private readonly ConcurrentDictionary<string, TcpClient> _clients;
        private CancellationTokenSource _cancellationTokenSource;
        private ServerControllers _serverControllers;
        private ChatControllers _chatControllers;
        private static UserControllers _userControllers = new UserControllers();

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
            Logger.Info($"Server started on {ipAddress}:{port}");

            _cancellationTokenSource = new CancellationTokenSource();
            _ = AcceptClientsAsync(_cancellationTokenSource.Token);
        }

        public void Stop()
        {
            Logger.Info("Server stopped.");
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
                    Logger.Connection("User connected.");

                    _ = HandleClientAsync(client, token); // Xử lý client trong task riêng
                }
            }
            catch (OperationCanceledException)
            {
                Logger.Error("Accepting clients stopped.");
            }
        }

        public static Schemas.Request ToDictionary(string jsonString)
        {
            return JsonConvert.DeserializeObject<Schemas.Request>(jsonString);
        }

        public async static Task<bool> SendMessage(NetworkStream stream, CancellationToken token, string result)
        {
            var response = Encoding.UTF8.GetBytes(result);
            await stream.WriteAsync(response, 0, response.Length, token);
            return true;
        }

        public async static Task<bool> SendMessageToUser(ConcurrentDictionary<string, TcpClient> clients, CancellationToken token,  string receiverId, string senderId, string message)
        {
            string senderFullName = await _userControllers.GetNameById(senderId);
            string receiverFullName = await _userControllers.GetNameById(receiverId);

            if (clients.TryGetValue(receiverId, out TcpClient anotherClient))
            {
                if (anotherClient != null && anotherClient.Connected)
                {
                    var anotherStream = anotherClient.GetStream();
                    Logger.Chat(senderFullName, receiverFullName, message);
                    await SocketServer.SendMessage(anotherStream, token, message);
                    return true;
                }
                else
                {
                    Logger.Info($"Receiver {receiverFullName} is null or not connected.", senderId);
                }
            }
            else
            {
                Logger.Info($"Receiver {receiverFullName} not found in clients.", senderId);
            }
            return false;
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
                        if (_clients.ContainsKey(userId))
                        {
                            _clients[userId] = client;
                        }
                        else
                        {
                            _clients.TryAdd(userId, client);
                        }
                    }
                    string userFullName = await _userControllers.GetNameById(userId);
                    Logger.Received(request, userFullName);
                    await _serverControllers.HandleRequest(_clients, stream, token, request);
                }
            }
            // Client tự disconnect
            catch (IOException ex) when (ex.InnerException is SocketException socketEx && socketEx.SocketErrorCode == SocketError.ConnectionReset)
            {
                string userFullName = await GetUserFullNameFromClient(client);
                Logger.Error("Client disconnected unexpectedly", ex, userFullName);
            }
            catch (Exception ex)
            {
                string userFullName = await GetUserFullNameFromClient(client);
                Logger.Error("An unexpected error occurred", ex, userFullName);
            }
            finally
            {
                clientDisconnect(client);
            }
        }

        private string GetUserId(TcpClient client)
        {
            // Tìm userId tương ứng với TcpClient trong _clients
            foreach (var kvp in _clients)
            {
                if (kvp.Value == client)
                {
                    return kvp.Key;
                }
            }
            return null;
        }

        private async Task<string> GetUserFullNameFromClient(TcpClient client)
        {
            string userId = GetUserId(client);
            if (userId != null)
            {
                return await _userControllers.GetNameById(userId);
            }
            return null;
        }

        private async void clientDisconnect(TcpClient client)
        {
            string userId = GetUserId(client);

            // Log và xử lý nếu tìm thấy userId
            if (userId != null)
            {
                string userFullName = await _userControllers.GetNameById(userId);
                Logger.Connection("Disconnected", userFullName);
                _clients.TryRemove(userId, out _); // Xóa client khỏi dictionary
            }
            else
            {
                Logger.Error("Disconnected client not found in _clients.");
            }

            // Đóng kết nối
            client.Close();
        }
    }
}
