using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clients
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            /*-- Này là code hiện giao diện winform --*/
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new login());


            //connect_server client = new connect_server("172.17.48.190", 12345);

            //if (client.Connect())
            //{
            //    client.StartReceiving();

            //    // Gửi tin nhắn
            //    Console.WriteLine("Type messages to send to the server. Type 'exit' to quit.");
            //    while (true)
            //    {
            //        string message = Console.ReadLine();
            //        if (message != null && message.ToLower() == "exit")
            //        {
            //            client.Disconnect();
            //            break;
            //        }

            //        if (!string.IsNullOrWhiteSpace(message))
            //        {
            //            client.SendMessage(message);
            //        }
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("Unable to connect to the server. Exiting...");
            //}
        }
    }
}
