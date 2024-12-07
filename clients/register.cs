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
    public partial class register : Form
    {

        public register()
        {
            InitializeComponent();
            this.KeyPreview = true; // Cho phép Form nhận phím
            this.KeyDown += MainForm_KeyDown;
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
        private void loginBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            login login = new login();
            login.Show();
        }
    }
}
