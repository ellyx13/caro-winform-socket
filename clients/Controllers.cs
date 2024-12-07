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

                // Kết nối tới server
                client = new SocketClient("127.0.0.1", 5000);
                await client.ConnectAsync();
                await client.SendAsync(request);
                var response = await client.ReceiveAsync();
                return Schemas.ToDictionary(response);
            }

            public async static Task<Schemas.Response> Login(string username, string password)
            {
                var data = new Dictionary<string, object>
                {
                    { "username", username },
                    { "password", password }
                };

                var request = Schemas.ToRequest(null, "users/login", data);
                client = new SocketClient("127.0.0.1", 5000);
                await client.ConnectAsync();
                await client.SendAsync(request);
                var response = await client.ReceiveAsync();
                return Schemas.ToDictionary(response);
            }
        }
    }
}
