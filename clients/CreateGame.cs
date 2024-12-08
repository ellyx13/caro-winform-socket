using Newtonsoft.Json.Linq;
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
    public partial class CreateGame : Form
    {
        public Schemas.Response data_user;
        public CreateGame(Schemas.Response data)
        {
            InitializeComponent();
            this.KeyPreview = true; // Cho phép Form nhận sự kiện phím
            this.KeyDown += close_KeyDown;
            this.data_user = data;
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
                creatBtn.PerformClick(); // Thực hiện hành động khi nhấn Enter
            }
        }


        private async void creatBtn_Click(object sender, EventArgs e)
        {
            string hostId = data_user.Data["Id"].ToString();
            var game = await ClientControllers.Games.CreateGame(txtRoomName.Text, hostId);
            int create_success_code = 23;
            if(game.Code == create_success_code)
            {
                var updatedUser = await ClientControllers.Users.GetMe(hostId);
                data_user.Data["Credits"] = updatedUser.Data["Credits"];
                lb_money.Text = "$" + updatedUser.Data["Credits"];

                new ChessForm(game, data_user).Show();
                this.Close();
            }
            
        }
        private void lb_money_Click(object sender, EventArgs e)
        {

        }

        private async void CreateGame_Load(object sender, EventArgs e)
        {
        }

        private void CreateGame_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
