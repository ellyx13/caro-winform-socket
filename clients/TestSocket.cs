using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace clients
{
    internal class TestSocket
    {
        public static async Task Test()
        {
            var user1 = await ClientControllers.Users.Register("Nguyen Van A", "nguyenvanbc123@gmail.com", "123456");
            Console.WriteLine(user1);

            var user1Login = await ClientControllers.Users.Login("nguyenvanbc123@gmail.com", "123456");
            Console.WriteLine(user1Login);

            var user2 = await ClientControllers.Users.Register("Nguyen Thi B", "nguyenthib@gmail.com", "123456");
            Console.WriteLine(user1);

            var user2Login = await ClientControllers.Users.Login("nguyenthib@gmail.com", "123456");
            Console.WriteLine(user2Login);

            string hostId = user1Login.Data["Id"].ToString();
            string guestId = user2Login.Data["Id"].ToString();

            var game = await ClientControllers.Games.CreateGame("Game 1", hostId);
            Console.WriteLine(game);

            string gameCode = game.Data["Code"].ToString();
            var response3 = await ClientControllers.Games.JoinGame(gameCode, guestId);
            Console.WriteLine(response3);


            // Ngắt kết nối
            ClientControllers.Disconnect();
        }

    }
}
