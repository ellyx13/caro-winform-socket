using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static clients.ClientControllers;

namespace clients
{
    public partial class register : Form
    {
        public register()
        {
            InitializeComponent();
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

        bool Check_Textbox(string fullname, string username, string password)
        {
            if (string.IsNullOrWhiteSpace(fullname))
            {
                MessageBox.Show("Chưa nhập Fullname");
                txt_fullname.Focus();
                return false;
            }
            else if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Chưa nhập Username");
                txt_username.Focus();
                return false;
            }
            else if (!IsValidEmail(username))
            {
                MessageBox.Show("Username phải ở dạng email");
                txt_username.Focus();
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
                btn_register.PerformClick(); // Thực hiện hành động khi nhấn Enter
            }
        }

        private void link_login_Click(object sender, EventArgs e)
        {
            this.Hide();
            login login = new login();
            login.Show();
        }

        private async void btn_register_Click(object sender, EventArgs e)
        {
            string fullname = txt_fullname.Text;
            string username = txt_username.Text;
            string password = txt_password.Text;
            if(Check_Textbox(fullname, username, password))
            {
                var userreigister = await ClientControllers.Users.Register(fullname, username, password);
                int register_success_code = 12;
                int register_email_exist_code = 11;
                if (userreigister.Code == register_success_code) 
                {
                    MessageBox.Show("Bạn đã đăng ký thành công");
                    new login().Show();
                    this.Close();
                }
                else if(userreigister.Code == register_email_exist_code)
                {
                    MessageBox.Show("Email đã tồn tại");
                }
            }
        }
    }
}
