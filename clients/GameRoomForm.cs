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
    public partial class GameRoomForm : Form
    {
        private const int CHESS_BOARD_WIDTH = 15;  // Số cột của bàn cờ
        private const int CHESS_BOARD_HEIGHT = 15; // Số hàng của bàn cờ
        private const int CHESS_WIDTH = 50;        // Chiều rộng của mỗi ô
        private const int CHESS_HEIGHT = 50;       // Chiều cao của mỗi ô
        public GameRoomForm()
        {
            InitializeComponent();
            DrawChessBoard();
        }
        private void DrawChessBoard()
        {
            Button oldButton = new Button { Width = 0, Location = new Point(0, 0) };

            for (int i = 0; i < CHESS_BOARD_HEIGHT; i++)
            {
                for (int j = 0; j <= CHESS_BOARD_WIDTH; j++)
                {
                    Button btn = new Button
                    {
                        Width = CHESS_WIDTH,
                        Height = CHESS_HEIGHT,
                        Location = new Point(oldButton.Location.X + oldButton.Width, oldButton.Location.Y),
                        BackColor = Color.White,
                        Font = new Font("Arial", 12, FontStyle.Bold),
                        Tag = new Point(i, j), // Lưu tọa độ vào Tag
                    };
                    pnlBoard.Controls.Add(btn);
                    oldButton = btn; // Cập nhật oldButton
                }
                // Dịch xuống dòng mới
                oldButton.Location = new Point(0, oldButton.Location.Y + CHESS_HEIGHT);
                oldButton.Width = 0;
                oldButton.Height = 0;
            }
        }
    }
}
