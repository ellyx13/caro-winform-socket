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
    public partial class ChessForm : Form
    {

        private const int CHESS_BOARD_WIDTH = 12;  // Số cột của bàn cờ
        private const int CHESS_BOARD_HEIGHT = 12; // Số hàng của bàn cờ
        private const int CHESS_WIDTH = 52;        // Chiều rộng của mỗi ô
        private const int CHESS_HEIGHT = 52;       // Chiều cao của mỗi ô


        private Button[,] chessBoard;
        public Schemas.Response message_response;
        public Schemas.Response game_response;
        public Schemas.Response user_response;

        private bool isPlayer1Turn = true;
        public string status;
        private bool isMyTurn;
        private string myRole;

        public ChessForm(Schemas.Response data_game, Schemas.Response data_user)
        {
            InitializeComponent();  
            this.KeyPreview = true; // Cho phép Form nhận phím

            this.game_response = data_game;
            this.user_response = data_user;

            lb_code.Text = "Room code: " + data_game.Data["Code"].ToString();
            lb_name.Text = data_user.Data["Name"].ToString();
            status = game_response.Data["Status"].ToString();
            lb_status.Text ="Status: " + status;

            if (data_game.Data["Host"].ToString() == data_user.Data["Id"].ToString())
            {
                myRole = "Host";
                lb_name.Text = myRole + ": " + lb_name.Text;
                isMyTurn = true;
            }
            else
            {
                myRole = "Guest";
                lb_name.Text = myRole + ": " + lb_name.Text;
                isMyTurn = false;
            }

            HandleChess();
            DrawChessBoard();
        }

        public async Task<Boolean> HandleChess()
        {
            int chat_received_code = 31;
            int status_isready_code = 28;
            int move_success_code = 26;
            int opponent_move_code = 27;
            int end_game_code = 40;
            while (true)
            {
                var response = await ClientControllers.Reciver();
                Console.WriteLine(response.Code);
                Console.WriteLine(response.Code == opponent_move_code);
                if (response.Code == status_isready_code)
                {
                    status = "playing";
                    lb_status.Text = "Status: " + status;
                }

                if (response.Code == chat_received_code)
                {
                    string receivedMessage = response.Data["message"].ToString();
                    string senderName = response.Data["senderName"].ToString();
                    AppendMessage($"{senderName} > {receivedMessage}");
                }

                if (response.Code == move_success_code)
                {
                    Console.WriteLine("Nước đi thành công.");
                    isMyTurn = false;
                }

                if (response.Code == opponent_move_code)
                {
                    int x = Convert.ToInt32(response.Data["x"]);
                    int y = Convert.ToInt32(response.Data["y"]);
                    UpdateBoardWithOpponentMove(x, y);
                    
                    isMyTurn = true;
                }
                if(response.Code == end_game_code)
                {
                    this.Close();
                }
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

        private async void Cell_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton == null || clickedButton.Text != string.Empty)
                return;
            if(status == "waiting")
            {
                MessageBox.Show("Game bắt đầu khi người chơi khác vào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!isMyTurn)
            {
                MessageBox.Show("Không phải lượt của bạn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Point location = (Point)clickedButton.Tag;
            clickedButton.Text = myRole == "Host" ? "X" : "O";
            clickedButton.ForeColor = myRole == "Host" ? Color.Red : Color.Blue;

            var moveResponse = await ClientControllers.Games.MakeMove(
                game_response.Data["Id"].ToString(),
                user_response.Data["Id"].ToString(),
                location.X,
                location.Y
            );
            if(CheckWinner(new Point(location.X, location.Y)))
            {
                string winnerId = myRole == "Host" ? game_response.Data["Host"].ToString() : game_response.Data["Guest"].ToString();
                var response = await ClientControllers.Games.Winner(
                    game_response.Data["Id"].ToString(),
                    winnerId
                );
                int win_code = 29;
                Console.WriteLine( response.Data );
                if(response.Code == win_code)
                {
                    MessageBox.Show("Bạn đã thắng!", "Kết thúc", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }

        }
        private void UpdateBoardWithOpponentMove(int x, int y)
        {
            try
            {
                Button opponentMoveButton = chessBoard[x, y];
                if (myRole == "Host")
                {
                    opponentMoveButton.Text = "O";
                    opponentMoveButton.ForeColor = Color.Blue;
                }
                else
                {
                    opponentMoveButton.Text = "X";
                    opponentMoveButton.ForeColor = Color.Red;
                }

                if (CheckWinner(new Point(x, y)))
                {
                    MessageBox.Show("Đối phương đã thắng!", "Kết thúc", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetBoard();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi cập nhật nước đi của đối phương: {ex.Message}");
            }
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

        private void lb_status_Click(object sender, EventArgs e)
        {

        }
    }
}
