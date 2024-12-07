using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace clients
{
    internal class TestSocketGuest
    {
        public static async Task Test()
        {
            var guest = await ClientControllers.Users.Register("Nguyen Thi B", "nguyenthib@gmail.com", "123456");
            Console.WriteLine(guest);

            var guestLogin = await ClientControllers.Users.Login("nguyenthib@gmail.com", "123456");
            Console.WriteLine(guest);


            string guestId = guestLogin.Data["Id"].ToString();

            string gameCode = "8805";
            var game = await ClientControllers.Games.JoinGame(gameCode, guestId);
            Console.WriteLine(game);

            string gameId = game.Data["Id"].ToString();

            var chat = await ClientControllers.Chat.SendMessage(gameId, guestId, "Hello");

            // Ngắt kết nối
            ClientControllers.Disconnect();
        }

    }
}
