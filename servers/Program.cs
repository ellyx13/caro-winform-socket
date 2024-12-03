using System;
using System.Threading.Tasks;


namespace servers
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("The Caro Game server is started");
            var server = new SocketServer();
            server.Start("127.0.0.1", 5000);

            Console.WriteLine("Press Enter to stop the server...");
            Console.ReadLine();
            server.Stop();

        }
    }
}
