using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clients
{
    public partial class JoinGame : Form
    {
        private Schemas.Response data_user;
        public JoinGame(Schemas.Response data)
        {
            InitializeComponent();
            this.KeyPreview = true; // Cho phép Form nhận sự kiện phím
            this.KeyDown += close_KeyDown;
            data_user = data;
            lb_money.Text = "$" + data_user.Data["Credits"];
        }
        private void close_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) // Kiểm tra nếu phím là Esc
            {
                this.Close(); // Đóng Form hiện tại
            }
            else if (e.KeyCode == Keys.Enter) // Kiểm tra nếu phím là Enter
            {
                joinBtn.PerformClick(); // Thực hiện hành động khi nhấn Enter
            }
        }

        private async void joinBtn_Click(object sender, EventArgs e)
        {
            string guestId = data_user.Data["Id"].ToString();
            var joinGame = await ClientControllers.Games.JoinGame(txt_roomcode.Text, guestId);
        }

        private void lb_money_Click(object sender, EventArgs e)
        {

        }

        private void JoinGame_Load(object sender, EventArgs e)
        {

        }
    }
}
