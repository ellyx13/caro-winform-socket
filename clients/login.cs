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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
            btnLogin.Select();
        }

        private void login_Load(object sender, EventArgs e)
        {

        }
        

        private void button1_click(object sender, EventArgs e)
        {
            register form = new register();
            form.ShowDialog();

            this.Close();
        }
    }
}
