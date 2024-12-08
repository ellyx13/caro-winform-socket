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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
            btnLogin.Select();
            this.KeyPreview = true; // Cho phép Form nhận phím
            this.KeyDown += MainForm_KeyDown;
        }

        bool IsValidEmail(string email)
        {
            // Check if email ends with @gmail.com
            return email.EndsWith("@gmail.com") &&
                   System.Text.RegularExpressions.Regex.IsMatch(
                       email,
                       @"^[^@\s]+@[^@\s]+\.[^@\s]+$", // Basic email validation regex
                       System.Text.RegularExpressions.RegexOptions.IgnoreCase
                   );
        }

        bool IsPasswordValid(string password)
        {
            return password.Length >= 8;
        }

        bool Check_Textbox(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Chưa nhập Email");
                txt_email.Focus();
                return false;
            }
            else if (!IsValidEmail(email))
            {
                MessageBox.Show("Email không đúng định dạng");
                txt_email.Focus();
                return false;
            }
            else if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Chưa nhập Password");
                txt_password.Focus();
                return false;
            }
            else if (!IsPasswordValid(password))
            {
                MessageBox.Show("Password phải tối thiểu 8 ký tự");
                txt_password.Focus();
                return false;
            }
            else
            {
                return true;
            }
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
            else if (e.KeyCode == Keys.Enter) // Kiểm tra nếu phím là Enter
            {
                btnLogin.PerformClick(); // Thực hiện hành động khi nhấn Enter
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
            string email = txt_email.Text;
            string pass = txt_password.Text;
            if (Check_Textbox(email, pass))
            {
                var userLogin = await ClientControllers.Users.Login(email, pass);
                int login_success_code = 14;
                int login_authen_failed_code = 15;
                if(userLogin.Code == login_success_code)
                {
                    new MainForm(userLogin).Show();
                    this.Hide();
                }
                else if(userLogin.Code == login_authen_failed_code)
                {
                    MessageBox.Show("Email or password không đúng");
                }
            }
        }
    }
}
