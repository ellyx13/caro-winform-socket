namespace clients
{
    partial class ChessForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChessForm));
            this.pnlBoard = new System.Windows.Forms.Panel();
            this.txtShowChat = new System.Windows.Forms.TextBox();
            this.txtChat = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnEsc = new System.Windows.Forms.Button();
            this.btnEnter = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBoard
            // 
            resources.ApplyResources(this.pnlBoard, "pnlBoard");
            this.pnlBoard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(52)))), ((int)(((byte)(69)))));
            this.pnlBoard.Name = "pnlBoard";
            this.pnlBoard.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlBoard_Paint);
            // 
            // txtShowChat
            // 
            resources.ApplyResources(this.txtShowChat, "txtShowChat");
            this.txtShowChat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(36)))), ((int)(((byte)(54)))));
            this.txtShowChat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtShowChat.ForeColor = System.Drawing.Color.White;
            this.txtShowChat.Name = "txtShowChat";
            this.txtShowChat.ReadOnly = true;
            this.txtShowChat.TextChanged += new System.EventHandler(this.txtShowChat_TextChanged);
            // 
            // txtChat
            // 
            resources.ApplyResources(this.txtChat, "txtChat");
            this.txtChat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(36)))), ((int)(((byte)(54)))));
            this.txtChat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtChat.ForeColor = System.Drawing.Color.White;
            this.txtChat.Name = "txtChat";
            this.txtChat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtChat_KeyPress);
            // 
            // btnSend
            // 
            resources.ApplyResources(this.btnSend, "btnSend");
            this.btnSend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(36)))), ((int)(((byte)(54)))));
            this.btnSend.BackgroundImage = global::clients.Properties.Resources.send_1;
            this.btnSend.Name = "btnSend";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnEsc
            // 
            resources.ApplyResources(this.btnEsc, "btnEsc");
            this.btnEsc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(36)))), ((int)(((byte)(54)))));
            this.btnEsc.BackgroundImage = global::clients.Properties.Resources.send_1;
            this.btnEsc.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(36)))), ((int)(((byte)(54)))));
            this.btnEsc.Name = "btnEsc";
            this.btnEsc.UseVisualStyleBackColor = false;
            this.btnEsc.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnEnter
            // 
            resources.ApplyResources(this.btnEnter, "btnEnter");
            this.btnEnter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(52)))), ((int)(((byte)(69)))));
            this.btnEnter.BackgroundImage = global::clients.Properties.Resources.Group_13__1_;
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.UseVisualStyleBackColor = false;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.txtShowChat);
            this.panel1.Controls.Add(this.btnEsc);
            this.panel1.Controls.Add(this.txtChat);
            this.panel1.Name = "panel1";
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(52)))), ((int)(((byte)(69)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Name = "textBox1";
            // 
            // ChessForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackgroundImage = global::clients.Properties.Resources.Chess__2_;
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnEnter);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.pnlBoard);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(52)))), ((int)(((byte)(69)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ChessForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ChessForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ChessForm_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlBoard;
        private System.Windows.Forms.TextBox txtShowChat;
        private System.Windows.Forms.TextBox txtChat;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnEsc;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox1;
    }
}