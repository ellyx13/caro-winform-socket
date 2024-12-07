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

        public static SocketClient client;

        public static void Disconnect()
        {
            client.Disconnect();
        }

        public async static Task<Schemas.Response> Send(string request)
        {
            // Kết nối tới server
            client = new SocketClient("127.0.0.1", 5000);
            await client.ConnectAsync();
            await client.SendAsync(request);
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
                return await Send(request);
            }
        }
    }
}
