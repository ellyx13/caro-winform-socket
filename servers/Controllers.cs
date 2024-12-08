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
using MongoDB.Driver.Core.Servers;


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
            string currentUserFullName = await _userController.GetNameById(currentUserId);  
            string result = Exceptions.RouteNotFound();
            // Xử lý route và điều hướng đến controller tương ứng
            switch (request.Route)
            {
                case "chat":
                    {
                        Console.WriteLine("Chat");
                        string gameId = request.Data["gameId"].ToString();
                        string message = request.Data["message"].ToString();
                        string userId = request.UserId;
                        string receiverId = await _chatController.GetReceiverId(request.UserId, gameId, null);
                        await _chatController.Save(gameId, userId, receiverId, message);

                        var dataSender = new Dictionary<string, object>
                        {
                            { "message", message },
                            { "senderId", request.UserId },
                            { "senderName", await _userController.GetNameById(request.UserId) },
                        };
                        var messageSender = Schemas.ToResponse(true, 31, "New message.", dataSender);
                        await SocketServer.SendMessageToUser(clients, token, receiverId, request.UserId, messageSender);

                        result = Schemas.ToResponse(true, 30, "Message sended.", dataSender);
                        break;
                    }
                case "games/winner":
                    {
                        string gameId = request.Data["gameId"].ToString();
                        string winner = request.UserId;
                        string receiverId = await _chatController.GetReceiverId(request.UserId, gameId, null);
                        var dataSender = new Dictionary<string, object>
                        {
                            { "WinnerId", request.UserId },
                            { "WinnerFullName", await _userController.GetNameById(request.UserId) },
                        };
                        var messageSender = Schemas.ToResponse(true, 40, "Game is end.", dataSender);
                        await SocketServer.SendMessageToUser(clients, token, receiverId, request.UserId, messageSender);
                        
                        result = await _gameController.SetWinner(gameId, winner);
                        break;
                    }
                case "games/move":
                    {
                        string gameId = request.Data["gameId"].ToString();
                        var dataSender = new Dictionary<string, object>
                            {
                                { "GameId", gameId },
                                { "userMakeMove", request.UserId },
                                { "x", int.Parse(request.Data["x"].ToString()) },
                                { "y", int.Parse(request.Data["y"].ToString()) }
                            };

                        string receiverId = await _chatController.GetReceiverId(request.UserId, gameId, null);
                        var messageSender = Schemas.ToResponse(true, 27, "New move.", dataSender);
                        await SocketServer.SendMessageToUser(clients, token, receiverId, request.UserId, messageSender);

                        result = _gameController.MakeMove(gameId, request.UserId, int.Parse(request.Data["x"].ToString()), int.Parse(request.Data["y"].ToString()));
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
                case "users/me":
                    {
                        result = await _userController.GetMe(request.UserId);
                        break;
                    }
                case "games/create":
                    {
                        result = await _gameController.CreateGame(request.Data["gameName"], request.UserId);
                        break;
                    }
                case "games/join":
                    {
                        string userId = request.UserId;
                        string gameCode = request.Data["gameCode"].ToString();
                        result = await _gameController.JoinGame(request.Data["gameCode"], request.UserId);
                        if (result.Contains("Join game successed"))
                        {
                            string receiverId = await _chatController.GetReceiverId(userId, null, gameCode);
                            var dataSender = new Dictionary<string, object>
                            {
                                { "gameCode", gameCode },
                                {"guestName",  await _userController.GetNameById(request.UserId)}
                            };
                            var messageSender = Schemas.ToResponse(true, 28, "Game is ready.", dataSender);
                            await SocketServer.SendMessageToUser(clients, token, receiverId, request.UserId, messageSender);
                        }
                        break;
                    }
                default:
                    {
                        result = Exceptions.RouteNotFound();
                        break;

                    }
            }
            await SocketServer.SendMessage(stream, token, result);
            Logger.Response(result, currentUserFullName);
            return true;
        }
    }

}
