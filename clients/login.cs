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
        public string email;
        public string password;

        public login()
        {
            InitializeComponent();
            btnLogin.Select();
            this.KeyPreview = true; // Cho phép Form nhận phím
            this.KeyDown += MainForm_KeyDown;
        }
        public void set_data_login(string email, string pass)
        {
            this.email = email;
            this.password = pass;
        }
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) // Kiểm tra nếu phím là Esc
            {
                var result = MessageBox.Show("Bạn có chắc chắn muốn thoát trò chơi?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    Application.Exit();
                }
            }
        }
        private void button1_click(object sender, EventArgs e)
        {
            this.Hide();
            register form = new register();
            form.Show();
        }

        public async void btnLogin_Click(object sender, EventArgs e)
        {
            set_data_login(txt_email.Text, txt_password.Text);
            var user1Login = await ClientControllers.Users.Login(email,password);
            Console.WriteLine(user1Login);

            this.Hide();
            new MainForm().Show();
        }
    }
}
