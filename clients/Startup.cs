using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clients
{
    public partial class Startup : Form
    {
        public Startup()
        {
            InitializeComponent();
            startBtn.Select();
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            string serverIp = serverIpLb.Text;
            int port = Int32.Parse(portLb.Text);
            ClientControllers.Start(serverIp, port);
            new login().Show();
            this.Hide();
        }
    }
}
