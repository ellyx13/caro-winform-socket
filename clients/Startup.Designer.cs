namespace clients
{
    partial class Startup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Startup));
            this.startBtn = new System.Windows.Forms.Button();
            this.portLb = new System.Windows.Forms.TextBox();
            this.serverIpLb = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // startBtn
            // 
            this.startBtn.AutoSize = true;
            this.startBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(52)))), ((int)(((byte)(69)))));
            this.startBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("startBtn.BackgroundImage")));
            this.startBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.startBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(52)))), ((int)(((byte)(69)))));
            this.startBtn.Location = new System.Drawing.Point(586, 574);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(380, 88);
            this.startBtn.TabIndex = 13;
            this.startBtn.UseVisualStyleBackColor = false;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // portLb
            // 
            this.portLb.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.portLb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(36)))), ((int)(((byte)(54)))));
            this.portLb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.portLb.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.portLb.ForeColor = System.Drawing.Color.White;
            this.portLb.Location = new System.Drawing.Point(522, 470);
            this.portLb.Name = "portLb";
            this.portLb.Size = new System.Drawing.Size(518, 37);
            this.portLb.TabIndex = 12;
            this.portLb.Text = "5000";
            // 
            // serverIpLb
            // 
            this.serverIpLb.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.serverIpLb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(36)))), ((int)(((byte)(54)))));
            this.serverIpLb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.serverIpLb.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serverIpLb.ForeColor = System.Drawing.Color.White;
            this.serverIpLb.Location = new System.Drawing.Point(522, 338);
            this.serverIpLb.Name = "serverIpLb";
            this.serverIpLb.Size = new System.Drawing.Size(518, 37);
            this.serverIpLb.TabIndex = 11;
            this.serverIpLb.Text = "127.0.0.1";
            // 
            // Startup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1554, 882);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.portLb);
            this.Controls.Add(this.serverIpLb);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Startup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "login";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.TextBox portLb;
        private System.Windows.Forms.TextBox serverIpLb;
    }
}