using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace clients
{
    public partial class MainForm : Form
    {
        private List<Control> controlsByTabIndex; // Danh sách điều khiển sắp xếp theo TabIndex
        private int currentTabIndex = -1;
        public Schemas.Response data_user;
        public MainForm(Schemas.Response data)
        {
            InitializeComponent();
            this.KeyPreview = true; // Đảm bảo Form nhận sự kiện bàn phím
            InitializeTabIndexList();
            data_user = data;
        }
        private void joinBtn_Click(object sender, EventArgs e)
        {
            JoinGame join = new JoinGame(data_user);
            join.Show();
        }

        private void authorBtn_Click(object sender, EventArgs e)
        {
            Author author = new Author();
            author.Show();
        }
        //********************* tạo sự kiện di chuyển các nút *********************

        // Thống kê và sắp xếp các điều khiển theo TabIndex
        private void InitializeTabIndexList()
        {
            controlsByTabIndex = GetAllControls(this)
                .Where(c => c.TabStop) // Chỉ lấy các điều khiển có thể nhận Tab
                .OrderBy(c => c.TabIndex)
                .ToList();
        }

        // Hàm đệ quy để lấy tất cả các điều khiển
        private IEnumerable<Control> GetAllControls(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                yield return control;

                foreach (Control child in GetAllControls(control))
                {
                    yield return child;
                }
            }
        }

        // Xử lý sự kiện KeyDown để điều hướng và kích hoạt
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (e.KeyCode == Keys.W)
            {
                NavigateControls(-1); // Di chuyển ngược
            }
            else if (e.KeyCode == Keys.S)
            {
                NavigateControls(1); // Di chuyển xuôi
            }
            else if (e.KeyCode == Keys.Enter)
            {
                ActivateCurrentControl(); // Kích hoạt sự kiện điều khiển
            }
        }

        // Điều hướng giữa các điều khiển
        private void NavigateControls(int direction)
        {
            if (controlsByTabIndex.Count == 0)
                return;

            if (currentTabIndex == -1)
            {
                // Chưa chọn điều khiển nào, bắt đầu từ TabIndex = 1
                currentTabIndex = 1;
            }
            else
            {
                // Tìm điều khiển hiện tại
                var currentIndex = controlsByTabIndex.FindIndex(c => c.TabIndex == currentTabIndex);
                if (currentIndex == -1) currentIndex = 0;

                // Tính toán TabIndex tiếp theo
                int nextIndex = (currentIndex + direction) % controlsByTabIndex.Count;
                if (nextIndex < 0)
                    nextIndex = controlsByTabIndex.Count - 1;

                currentTabIndex = controlsByTabIndex[nextIndex].TabIndex;
            }

            // Highlight điều khiển được chọn
            HighlightControl(currentTabIndex);
        }

        // Đổi focus đến điều khiển có TabIndex tương ứng
        private void HighlightControl(int tabIndex)
        {
            var targetControl = controlsByTabIndex.FirstOrDefault(c => c.TabIndex == tabIndex);
            if (targetControl != null)
            {
                targetControl.Focus();
            }
        }

        // Kích hoạt sự kiện của điều khiển hiện tại
        private void ActivateCurrentControl()
        {
            if (currentTabIndex == -1)
                return;

            var targetControl = controlsByTabIndex.FirstOrDefault(c => c.TabIndex == currentTabIndex);
            if (targetControl is Button button)
            {
                button.PerformClick();
            }
            else if (targetControl != null)
            {
                MessageBox.Show($"Kích hoạt điều khiển: {targetControl.Name}");
            }
        }

        private void createBtn_Click(object sender, EventArgs e)
        {
            CreateGame game = new CreateGame(data_user);
            game.ShowDialog();
            this.Close();
        }

        private void helpBtn_Click(object sender, EventArgs e)
        {
            Help help = new Help();
            help.ShowDialog();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
            this.Close();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
