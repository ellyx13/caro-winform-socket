using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clients
{
    class Program
    {
        static async Task Main(string[] args)
        {
            /*-- Này là code hiện giao diện winform --*/
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new login());

            //await TestSocket.Test();
            //Console.ReadLine();
        }
    }
}
