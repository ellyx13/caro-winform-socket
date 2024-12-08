using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace clients
{
    internal class ClientControllers
    {

        public static SocketClient client = new SocketClient("26.189.99.4", 5000);
        //public static SocketClient client = new SocketClient("127.0.0.1", 5000);
        public static bool IsConnected = false;

        public static void Disconnect()
        {
            client.Disconnect();
        }

        public async static Task<Schemas.Response> Send(string request, bool isRecevice = true)
        {
            // Kết nối tới server
            if (IsConnected == false)
            {
                await client.ConnectAsync();
                IsConnected = true;
            }
            
            await client.SendAsync(request);
            if (isRecevice)
            {
                var response = await client.ReceiveAsync();
                return Schemas.ToDictionary(response);
            }
            return null;
        }

        public async static Task<Schemas.Response> Reciver()
        {
            Console.WriteLine("Waiting for request...");
            var response = await client.ReceiveAsync();
            return Schemas.ToDictionary(response);
        }

        public static class Users
        {
            public async static Task<Schemas.Response> Register(string fullname, string username, string password)
            {
                var data = new Dictionary<string, object>
                {
                    { "fullname", fullname },
                    { "username", username },
                    { "password", password }
                };

                var request = Schemas.ToRequest(null, "users/register", data);
                return await Send(request);
            }

            public async static Task<Schemas.Response> Login(string username, string password)
            {
                var data = new Dictionary<string, object>
                {
                    { "username", username },
                    { "password", password }
                };

                var request = Schemas.ToRequest(null, "users/login", data);
                return await Send(request);
            }

            public async static Task<Schemas.Response> GetMe(string userId)
            {
                var data = new Dictionary<string, object>
                {
                    { "null", "null" },
                    { "null1", "null" }
                };

                var request = Schemas.ToRequest(userId, "users/me", data);
                return await Send(request);
            }
        }

        public static class Games
        {
            public async static Task<Schemas.Response> CreateGame(string gameName, string UserId)
            {
                var data = new Dictionary<string, object>
                {
                    { "gameName", gameName }
                };

                var request = Schemas.ToRequest(UserId, "games/create", data);
                return await Send(request);
            }

            public async static Task<Schemas.Response> JoinGame(string gameCode, string UserId)
            {
                var data = new Dictionary<string, object>
                {
                    { "gameCode", gameCode }
                };

                var request = Schemas.ToRequest(UserId, "games/join", data);
                return await Send(request);
            }

            public async static Task<Schemas.Response> MakeMove(string gameId, string UserId, int x, int y)
            {
                var data = new Dictionary<string, object>
                {
                    { "gameId", gameId },
                    { "x", x },
                    { "y", y }
                };

                var request = Schemas.ToRequest(UserId, "games/move", data);
                return await Send(request, false);
            }

            public async static Task<Schemas.Response> Winner(string gameId, string UserId)
            {
                var data = new Dictionary<string, object>
                {
                    { "gameId", gameId },
                };

                var request = Schemas.ToRequest(UserId, "games/winner", data);
                return await Send(request);
            }
        }

        public static class Chat
        {
            public async static Task<Schemas.Response> SendMessage(string gameId, string UserId, string message)
            {
                var data = new Dictionary<string, object>
                {
                    { "gameId", gameId },
                    { "message", message }
                };

                var request = Schemas.ToRequest(UserId, "chat", data);
                return await Send(request, false);
            }
        }
    }
}
