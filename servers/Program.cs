using System;
using System.Threading.Tasks;


namespace servers
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Console.Write("Enter the server IP (Blank to 127.0.0.1): ");
            string serverIP = Console.ReadLine();
            if (serverIP == "")
            {
                serverIP = "127.0.0.1";
            }
            Console.Write("Enter the server port (Blank to 5000): ");
            string serverPortStr = Console.ReadLine();
            if (serverPortStr == "")
            {
                serverPortStr = "5000";
            }
            int serverPort = Int32.Parse(serverPortStr);
            Logger.Info("The Caro Game server is started");
            var server = new SocketServer();
            server.Start(serverIP, serverPort);

            Logger.Info("Press Enter to stop the server...");
            Console.ReadLine();
            server.Stop();
        }
    }
}
