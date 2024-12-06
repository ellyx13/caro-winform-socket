namespace clients
{
    partial class CreateGame
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
            this.creatBtn = new System.Windows.Forms.Button();
            this.txtRoomName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // creatBtn
            // 
            this.creatBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.creatBtn.AutoSize = true;
            this.creatBtn.BackColor = System.Drawing.Color.Transparent;
            this.creatBtn.BackgroundImage = global::clients.Properties.Resources.Join_game;
            this.creatBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.creatBtn.FlatAppearance.BorderSize = 0;
            this.creatBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.creatBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.creatBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.creatBtn.Location = new System.Drawing.Point(609, 455);
            this.creatBtn.Name = "creatBtn";
            this.creatBtn.Size = new System.Drawing.Size(386, 97);
            this.creatBtn.TabIndex = 1;
            this.creatBtn.UseVisualStyleBackColor = false;
            this.creatBtn.Click += new System.EventHandler(this.creatBtn_Click);
            // 
            // txtRoomName
            // 
            this.txtRoomName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtRoomName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(36)))), ((int)(((byte)(54)))));
            this.txtRoomName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRoomName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRoomName.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRoomName.ForeColor = System.Drawing.Color.White;
            this.txtRoomName.Location = new System.Drawing.Point(556, 360);
            this.txtRoomName.Name = "txtRoomName";
            this.txtRoomName.Size = new System.Drawing.Size(464, 33);
            this.txtRoomName.TabIndex = 4;
            this.txtRoomName.Text = "213";
            // 
            // CreateGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::clients.Properties.Resources.Create_game_GUI;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1620, 920);
            this.Controls.Add(this.txtRoomName);
            this.Controls.Add(this.creatBtn);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CreateGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CreateGame";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button creatBtn;
        private System.Windows.Forms.TextBox txtRoomName;
    }
}