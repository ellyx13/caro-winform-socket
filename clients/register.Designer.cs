namespace clients
{
    partial class register
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(register));
            this.link_login = new System.Windows.Forms.Button();
            this.btn_register = new System.Windows.Forms.Button();
            this.txt_username = new System.Windows.Forms.TextBox();
            this.txt_fullname = new System.Windows.Forms.TextBox();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // link_login
            // 
            this.link_login.AutoSize = true;
            this.link_login.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(52)))), ((int)(((byte)(69)))));
            this.link_login.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("link_login.BackgroundImage")));
            this.link_login.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.link_login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.link_login.ForeColor = System.Drawing.Color.Black;
            this.link_login.Location = new System.Drawing.Point(720, 930);
            this.link_login.Margin = new System.Windows.Forms.Padding(2);
            this.link_login.Name = "link_login";
            this.link_login.Size = new System.Drawing.Size(504, 20);
            this.link_login.TabIndex = 9;
            this.link_login.UseVisualStyleBackColor = false;
            this.link_login.Click += new System.EventHandler(this.link_login_Click);
            // 
            // btn_register
            // 
            this.btn_register.AutoSize = true;
            this.btn_register.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(52)))), ((int)(((byte)(69)))));
            this.btn_register.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_register.BackgroundImage")));
            this.btn_register.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_register.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_register.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(52)))), ((int)(((byte)(69)))));
            this.btn_register.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_register.Location = new System.Drawing.Point(734, 804);
            this.btn_register.Margin = new System.Windows.Forms.Padding(2);
            this.btn_register.Name = "btn_register";
            this.btn_register.Size = new System.Drawing.Size(475, 110);
            this.btn_register.TabIndex = 8;
            this.btn_register.UseVisualStyleBackColor = false;
            this.btn_register.Click += new System.EventHandler(this.btn_register_Click);
            // 
            // txt_username
            // 
            this.txt_username.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_username.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(36)))), ((int)(((byte)(54)))));
            this.txt_username.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_username.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_username.ForeColor = System.Drawing.Color.White;
            this.txt_username.Location = new System.Drawing.Point(639, 512);
            this.txt_username.Margin = new System.Windows.Forms.Padding(2);
            this.txt_username.Name = "txt_username";
            this.txt_username.Size = new System.Drawing.Size(664, 46);
            this.txt_username.TabIndex = 7;
            // 
            // txt_fullname
            // 
            this.txt_fullname.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_fullname.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(36)))), ((int)(((byte)(54)))));
            this.txt_fullname.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_fullname.Cursor = System.Windows.Forms.Cursors.No;
            this.txt_fullname.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_fullname.ForeColor = System.Drawing.Color.White;
            this.txt_fullname.Location = new System.Drawing.Point(639, 345);
            this.txt_fullname.Margin = new System.Windows.Forms.Padding(2);
            this.txt_fullname.Name = "txt_fullname";
            this.txt_fullname.Size = new System.Drawing.Size(664, 46);
            this.txt_fullname.TabIndex = 6;
            // 
            // txt_password
            // 
            this.txt_password.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_password.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(36)))), ((int)(((byte)(54)))));
            this.txt_password.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_password.ForeColor = System.Drawing.Color.White;
            this.txt_password.Location = new System.Drawing.Point(639, 674);
            this.txt_password.Margin = new System.Windows.Forms.Padding(2);
            this.txt_password.Name = "txt_password";
            this.txt_password.Size = new System.Drawing.Size(664, 46);
            this.txt_password.TabIndex = 10;
            // 
            // register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1942, 1102);
            this.Controls.Add(this.txt_password);
            this.Controls.Add(this.link_login);
            this.Controls.Add(this.btn_register);
            this.Controls.Add(this.txt_username);
            this.Controls.Add(this.txt_fullname);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "register";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "register";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button link_login;
        private System.Windows.Forms.Button btn_register;
        private System.Windows.Forms.TextBox txt_username;
        private System.Windows.Forms.TextBox txt_fullname;
        private System.Windows.Forms.TextBox txt_password;
    }
}