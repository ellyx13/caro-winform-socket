using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace clients
{
    internal class TestSocketHost
    {
        public static async Task Test()
        {
            var user1 = await ClientControllers.Users.Register("Nguyen Van A", "nguyenvanbc123@gmail.com", "123456");
            Console.WriteLine(user1);

            var user1Login = await ClientControllers.Users.Login("nguyenvanbc123@gmail.com", "123456");
            Console.WriteLine(user1Login);

            string hostId = user1Login.Data["Id"].ToString();

            var game = await ClientControllers.Games.CreateGame("Game 1", hostId);
            Console.WriteLine(game);

            Console.ReadLine();

            // Ngắt kết nối
            ClientControllers.Disconnect();
        }

    }
}
