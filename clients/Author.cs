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
    public partial class Author : Form
    {
        public Author()
        {
            InitializeComponent();
            this.KeyPreview = true; // Cho phép Form nhận sự kiện phím
            this.KeyDown += close_KeyDown;
        }
        private void close_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) // Kiểm tra nếu phím là Esc
            {
                this.Close(); // Đóng Form hiện tại
            }
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
