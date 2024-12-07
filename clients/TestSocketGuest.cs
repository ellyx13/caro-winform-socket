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

            var guestLogin = await ClientControllers.Users.Login("nguyenthib@gmail.com", "123456");


            string guestId = guestLogin.Data["Id"].ToString();

            string gameCode = "8805";
            var game = await ClientControllers.Games.JoinGame(gameCode, guestId);

            string gameId = game.Data["Id"].ToString();

            while (true)
            {
                var chat = await ClientControllers.Chat.SendMessage(gameId, guestId, "Hello");
                var response = await ClientControllers.Reciver();
                Console.WriteLine(response);
                Console.ReadLine();
            }

            

            // Ngắt kết nối
            ClientControllers.Disconnect();
        }

    }
}
