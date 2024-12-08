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
    public partial class ChessForm : Form
    {

        private const int CHESS_BOARD_WIDTH = 12;  // Số cột của bàn cờ
        private const int CHESS_BOARD_HEIGHT = 12; // Số hàng của bàn cờ
        private const int CHESS_WIDTH = 52;        // Chiều rộng của mỗi ô
        private const int CHESS_HEIGHT = 52;       // Chiều cao của mỗi ô


        private Button[,] chessBoard;
        private bool isPlayer1Turn = true;
        public string status;
        public Schemas.Response message_response;
        public Schemas.Response game_response;
        public Schemas.Response user_response;
        public ChessForm(Schemas.Response data_game, Schemas.Response data_user)
        {
            InitializeComponent();  
            this.KeyPreview = true; // Cho phép Form nhận phím
            this.game_response = data_game;
            this.user_response = data_user;
            lb_code.Text = "Room code \n" + data_game.Data["Code"].ToString();
            lb_name.Text = "Name: " + data_user.Data["Name"].ToString();
            status = game_response.Data["Status"].ToString();
            HandleChess();
            DrawChessBoard();
        }

        public async Task<Boolean> HandleChess()
        {
            while (true)
            {
                Console.WriteLine("Đang đợi request");
                var response = await ClientControllers.Reciver();

                int chat_received_code = 31;
                int status_isready_code = 28;
                if(response.Code == status_isready_code)
                {
                    status = "playing";
                }
                if (response.Code == chat_received_code)
                {
                    string receivedMessage = response.Data["message"].ToString();
                    string senderName = response.Data["senderName"].ToString();
                    string chat = receivedMessage;
                    AppendMessage($"{senderName} > " + chat);
                }
                Console.WriteLine(response.Data);
            }
            return true;
        }

        private void DrawChessBoard()
        {
            chessBoard = new Button[CHESS_BOARD_HEIGHT, CHESS_BOARD_WIDTH];
            for (int i = 0; i < CHESS_BOARD_HEIGHT; i++)
            {
                for (int j = 0; j < CHESS_BOARD_WIDTH; j++)
                {
                    Button btn = new Button
                    {
                        Width = CHESS_WIDTH,
                        Height = CHESS_HEIGHT,
                        Location = new Point(j * CHESS_WIDTH, i * CHESS_HEIGHT),
                        BackColor = Color.White,
                        Font = new Font("Times New Roman", 25, FontStyle.Bold),
                        Tag = new Point(i, j)
                    };
                     btn.Click += Cell_Click;
                     pnlBoard.Controls.Add(btn);
                     chessBoard[i, j] = btn;
                }
            }
        }

        private async void ChessForm_Load(object sender, EventArgs e)
        {

        }
        //sự kiện gửi tin nhắn
        private async void SendMessage()
        {
            string message = txtChat.Text.Trim();
            if (status == "waiting")
            {
                MessageBox.Show("Phòng đang ở trạng thái chờ, bạn không thể gửi tin nhắn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!string.IsNullOrEmpty(message))
            {
                AppendMessage($"You > " + message);
                await ClientControllers.Chat.SendMessage(game_response.Data["Id"].ToString(), user_response.Data["Id"].ToString(), message);
                txtChat.Clear();
            }
            txtChat.Clear();
        }

        public void AppendMessage(string message)
        {
            txtShowChat.AppendText(message + Environment.NewLine);
            txtShowChat.ScrollToCaret();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtChat.Text))
            {
                SendMessage();
                txtChat.Clear();
            }
        }

        //Logic caro

        private void Cell_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton == null || clickedButton.Text != string.Empty)
                return;

            Point location = (Point)clickedButton.Tag;
            clickedButton.Text = isPlayer1Turn ? "X" : "O";
            clickedButton.ForeColor = isPlayer1Turn ? Color.Red : Color.Blue;

            if (CheckWinner(location))
            {
                MessageBox.Show((isPlayer1Turn ? "Người chơi X" : "Người chơi O") + " Thắng!");
                ResetBoard();
            }

            isPlayer1Turn = !isPlayer1Turn;
        }

        //Tính logic kiểm tra nước đi
        private bool CheckWinner(Point lastMove)
        {
            int row = lastMove.X;
            int col = lastMove.Y;
            string currentPlayer = chessBoard[row, col].Text;

            return CheckDirection(row, col, 1, 0, currentPlayer) ||
                   CheckDirection(row, col, 0, 1, currentPlayer) ||
                   CheckDirection(row, col, 1, 1, currentPlayer) ||
                   CheckDirection(row, col, 1, -1, currentPlayer);
        }

        private bool CheckDirection(int row, int col, int dRow, int dCol, string player)
        {
            int count = 1;

            for (int i = 1; i < 5; i++)
            {
                int r = row + dRow * i;
                int c = col + dCol * i;
                if (r >= 0 && r < CHESS_BOARD_HEIGHT && c >= 0 && c < CHESS_BOARD_WIDTH && chessBoard[r, c].Text == player)
                    count++;
                else
                    break;
            }

            for (int i = 1; i < 5; i++)
            {
                int r = row - dRow * i;
                int c = col - dCol * i;
                if (r >= 0 && r < CHESS_BOARD_HEIGHT && c >= 0 && c < CHESS_BOARD_WIDTH && chessBoard[r, c].Text == player)
                    count++;
                else
                    break;
            }

            return count >= 5;
        }
        //sự kiện reset trò chơi
        private void ResetBoard()
        {
            foreach (Button btn in chessBoard)
            {
                btn.Text = string.Empty;
                btn.BackColor = Color.White;
            }
            isPlayer1Turn = true;
        }
        //Xử lý sự kiện nút Esc 

        private void ChessForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) // Kiểm tra nếu phím là Esc
            {
                this.Close(); // Đóng Form hiện tại
            }
        }


        //Xử lý sự kiện nút Enter
        private void btnEnter_Click(object sender, EventArgs e)
        {
        }

        private void txtChat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SendMessage();
                e.Handled = true;
            }
        }

        private void pnlBoard_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtShowChat_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lb_code_Click(object sender, EventArgs e)
        {

        }

        private void txtChat_TextChanged(object sender, EventArgs e)
        {

        }

        private void lb_name_Click(object sender, EventArgs e)
        {

        }
    }
}
