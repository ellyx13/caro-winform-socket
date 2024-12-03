namespace clients
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.joinBtn = new System.Windows.Forms.Button();
            this.createBtn = new System.Windows.Forms.Button();
            this.authorBtn = new System.Windows.Forms.Button();
            this.helpBtn = new System.Windows.Forms.Button();
            this.exitBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // joinBtn
            // 
            this.joinBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.joinBtn.AutoSize = true;
            this.joinBtn.BackColor = System.Drawing.Color.Transparent;
            this.joinBtn.BackgroundImage = global::clients.Properties.Resources.Create_game;
            this.joinBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.joinBtn.FlatAppearance.BorderSize = 0;
            this.joinBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.joinBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.joinBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.joinBtn.ForeColor = System.Drawing.Color.Transparent;
            this.joinBtn.Location = new System.Drawing.Point(347, 367);
            this.joinBtn.Name = "joinBtn";
            this.joinBtn.Size = new System.Drawing.Size(303, 81);
            this.joinBtn.TabIndex = 2;
            this.joinBtn.UseVisualStyleBackColor = false;
            this.joinBtn.Click += new System.EventHandler(this.joinBtn_Click);
            // 
            // createBtn
            // 
            this.createBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.createBtn.AutoSize = true;
            this.createBtn.BackColor = System.Drawing.Color.Transparent;
            this.createBtn.BackgroundImage = global::clients.Properties.Resources.Join_game;
            this.createBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.createBtn.FlatAppearance.BorderSize = 0;
            this.createBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.createBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.createBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createBtn.ForeColor = System.Drawing.Color.Transparent;
            this.createBtn.Location = new System.Drawing.Point(347, 238);
            this.createBtn.Name = "createBtn";
            this.createBtn.Size = new System.Drawing.Size(303, 94);
            this.createBtn.TabIndex = 1;
            this.createBtn.UseVisualStyleBackColor = false;
            this.createBtn.Click += new System.EventHandler(this.createBtn_Click);
            // 
            // authorBtn
            // 
            this.authorBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.authorBtn.AutoSize = true;
            this.authorBtn.BackColor = System.Drawing.Color.Transparent;
            this.authorBtn.BackgroundImage = global::clients.Properties.Resources.Authors;
            this.authorBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.authorBtn.FlatAppearance.BorderSize = 0;
            this.authorBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.authorBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.authorBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.authorBtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.authorBtn.Location = new System.Drawing.Point(347, 484);
            this.authorBtn.Name = "authorBtn";
            this.authorBtn.Size = new System.Drawing.Size(303, 81);
            this.authorBtn.TabIndex = 3;
            this.authorBtn.UseVisualStyleBackColor = false;
            this.authorBtn.Click += new System.EventHandler(this.authorBtn_Click);
            // 
            // helpBtn
            // 
            this.helpBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.helpBtn.AutoSize = true;
            this.helpBtn.BackColor = System.Drawing.Color.Transparent;
            this.helpBtn.BackgroundImage = global::clients.Properties.Resources.Help;
            this.helpBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.helpBtn.FlatAppearance.BorderSize = 0;
            this.helpBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.helpBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.helpBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.helpBtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.helpBtn.Location = new System.Drawing.Point(347, 601);
            this.helpBtn.Name = "helpBtn";
            this.helpBtn.Size = new System.Drawing.Size(303, 81);
            this.helpBtn.TabIndex = 4;
            this.helpBtn.UseVisualStyleBackColor = false;
            this.helpBtn.Click += new System.EventHandler(this.helpBtn_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.exitBtn.AutoSize = true;
            this.exitBtn.BackColor = System.Drawing.Color.Transparent;
            this.exitBtn.BackgroundImage = global::clients.Properties.Resources.Exit;
            this.exitBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.exitBtn.FlatAppearance.BorderSize = 0;
            this.exitBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.exitBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.exitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitBtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.exitBtn.Location = new System.Drawing.Point(347, 718);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(303, 81);
            this.exitBtn.TabIndex = 5;
            this.exitBtn.UseVisualStyleBackColor = false;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::clients.Properties.Resources.Home;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(966, 907);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.helpBtn);
            this.Controls.Add(this.authorBtn);
            this.Controls.Add(this.createBtn);
            this.Controls.Add(this.joinBtn);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button joinBtn;
        private System.Windows.Forms.Button createBtn;
        private System.Windows.Forms.Button authorBtn;
        private System.Windows.Forms.Button helpBtn;
        private System.Windows.Forms.Button exitBtn;
    }
}

