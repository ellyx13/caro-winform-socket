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
using MongoDB.Driver.Core.Events;


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

                        var resultReceiver = Schemas.ToResponse(true, 31, "New message.", dataSender);
                        await SocketServer.SendMessage(anotherStream, token, resultReceiver);

                        Console.WriteLine($"Send message to {receiverId}: {message}");
                        result = Schemas.ToResponse(true, 30, "Message sended.", dataSender);
                        break;
                    }
                case "games/winner":
                    {
                        string gameId = request.Data["gameId"].ToString();
                        string winner = request.UserId;
                        result = await _gameController.SetWinner(gameId, winner);
                        break;
                    }
                case "games/move":
                    {
                        string gameId = request.Data["gameId"].ToString();
                        string userId = request.UserId;
                        int x = int.Parse(request.Data["x"].ToString());
                        int y = int.Parse(request.Data["y"].ToString());

                        string receiverId = await _chatController.GetReceiverId(userId, gameId);
                        clients.TryGetValue(receiverId, out TcpClient anotherClient);
                        var anotherStream = anotherClient.GetStream();
                        var dataReceiver = new Dictionary<string, object>
                            {
                                { "GameId", gameId },
                                { "userMakeMove", userId },
                                { "x", x },
                                { "y", y }
                            };

                        var resultReceiver = Schemas.ToResponse(true, 27, "New move.", dataReceiver);
                        await SocketServer.SendMessage(anotherStream, token, resultReceiver);

                        result = _gameController.MakeMove(gameId, userId, x, y);
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
