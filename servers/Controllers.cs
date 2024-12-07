using servers.Games;
using servers.Users;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using servers.Chat;
using System.Net.Sockets;
using System.Text;
using System.Collections.Concurrent;
using System.Threading;
using Sprache;


namespace servers
{
    internal class ServerControllers
    {
        private readonly UserControllers _userController;
        private readonly GameControllers _gameController;
        private readonly ChatControllers _chatController;

        public ServerControllers()
        {
            _userController = new UserControllers();
            _gameController = new GameControllers();
            _chatController = new ChatControllers();
        }

        // Xử lý request từ client
        public async Task<bool> HandleRequest(ConcurrentDictionary<string, TcpClient> clients, NetworkStream stream, CancellationToken token, string requestJson)
        {
            // Parse dữ liệu JSON từ client
            var request = JsonConvert.DeserializeObject<Schemas.Request>(requestJson);
            string currentUserId = request.UserId;
            string result = "Default";

            // Xử lý route và điều hướng đến controller tương ứng
            switch (request.Route)
            {
                case "chat":
                    {
                        string gameId = request.Data["gameId"].ToString();
                        string message = request.Data["message"].ToString();
                        string userId = request.UserId;
                        string receiverId = await _chatController.GetReceiverId(request.UserId, gameId);
                        await _chatController.Save(gameId, userId, receiverId, message);

                        clients.TryGetValue(receiverId, out TcpClient anotherClient);

                        var anotherStream = anotherClient.GetStream();
                        var dataSender = new Dictionary<string, object>
                            {
                                { "message", message },
                                { "senderId", userId }
                            };

                        result = Schemas.ToResponse(true, 30, "New message", dataSender);
                        break;
                    }
                case "users/register":
                    {
                        result = await _userController.RegisterUser(request.Data);
                        break;
                    }
                case "users/login":
                    {
                        result = await _userController.LoginUser(request.Data);
                        break;
                    }
                case "games/create":
                    {
                        result = await _gameController.CreateGame(request.Data["gameName"], request.UserId);
                        break;
                    }
                case "games/join":
                    {
                        result = await _gameController.JoinGame(request.Data["gameCode"], request.UserId);
                        break;
                    }
                default:
                    {
                        result = Exceptions.RouteNotFound();
                        break;

                    }
            }
            await SocketServer.SendMessage(stream, token, result);
            Console.WriteLine($"Response to {currentUserId}: {result}");
            return true;
        }
    }

}
