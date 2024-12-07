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
            var response = await ClientControllers.Users.Register("Nguyen Van A", "nguyenvanbc123@gmail.com", "123456");
            Console.WriteLine(response);

            var response1 = await ClientControllers.Users.Login("nguyenvanbc123@gmail.com", "123456");
            Console.WriteLine(response1);

            // Ngắt kết nối
            ClientControllers.Disconnect();
        }

    }
}
