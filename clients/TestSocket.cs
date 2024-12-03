using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clients
{
    internal class TestSocket
    {
        public static async Task Test()
        {
            var client = new SocketClient("127.0.0.1", 5000);

            Console.Write("Enter your client ID: ");
            string clientId = Console.ReadLine();

            // Kết nối tới server
            if (await client.ConnectAsync(clientId))
            {
                while (true)
                {
                    Console.Write("Enter message (or 'exit' to disconnect): ");
                    string message = Console.ReadLine();

                    if (message.ToLower() == "exit")
                    {
                        break;
                    }

                    // Gửi tin nhắn tới server
                    await client.SendAsync(message);

                    // Nhận phản hồi từ server
                    var response = await client.ReceiveAsync();
                }
            }
            // Ngắt kết nối
            client.Disconnect();
        }

    }
}
