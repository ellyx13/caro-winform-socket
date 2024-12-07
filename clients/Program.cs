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
            await TestSocketHost.Test();
            Console.ReadLine();
            Console.ReadLine();
        }
    }
}
