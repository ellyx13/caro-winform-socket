﻿namespace clients
{
    partial class JoinGame
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
            this.joinBtn = new System.Windows.Forms.Button();
            this.txt_roomcode = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.lb_money = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // joinBtn
            // 
            this.joinBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.joinBtn.AutoSize = true;
            this.joinBtn.BackColor = System.Drawing.Color.Transparent;
            this.joinBtn.BackgroundImage = global::clients.Properties.Resources.Create;
            this.joinBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.joinBtn.FlatAppearance.BorderSize = 0;
            this.joinBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.joinBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.joinBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.joinBtn.ForeColor = System.Drawing.Color.Transparent;
            this.joinBtn.Location = new System.Drawing.Point(745, 567);
            this.joinBtn.Margin = new System.Windows.Forms.Padding(4);
            this.joinBtn.Name = "joinBtn";
            this.joinBtn.Size = new System.Drawing.Size(452, 91);
            this.joinBtn.TabIndex = 2;
            this.joinBtn.UseVisualStyleBackColor = false;
            this.joinBtn.Click += new System.EventHandler(this.joinBtn_Click);
            // 
            // txt_roomcode
            // 
            this.txt_roomcode.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_roomcode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(36)))), ((int)(((byte)(54)))));
            this.txt_roomcode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_roomcode.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_roomcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_roomcode.ForeColor = System.Drawing.Color.White;
            this.txt_roomcode.Location = new System.Drawing.Point(645, 423);
            this.txt_roomcode.Margin = new System.Windows.Forms.Padding(4);
            this.txt_roomcode.Name = "txt_roomcode";
            this.txt_roomcode.Size = new System.Drawing.Size(637, 46);
            this.txt_roomcode.TabIndex = 3;
            this.txt_roomcode.Text = "213";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(61, 4);
            // 
            // lb_money
            // 
            this.lb_money.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lb_money.AutoSize = true;
            this.lb_money.BackColor = System.Drawing.Color.Transparent;
            this.lb_money.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_money.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lb_money.Location = new System.Drawing.Point(914, 865);
            this.lb_money.Name = "lb_money";
            this.lb_money.Padding = new System.Windows.Forms.Padding(1);
            this.lb_money.Size = new System.Drawing.Size(147, 50);
            this.lb_money.TabIndex = 4;
            this.lb_money.Text = "Money";
            this.lb_money.Click += new System.EventHandler(this.lb_money_Click);
            // 
            // JoinGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::clients.Properties.Resources.Join_Game_Background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1942, 1102);
            this.Controls.Add(this.lb_money);
            this.Controls.Add(this.txt_roomcode);
            this.Controls.Add(this.joinBtn);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "JoinGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.JoinGame_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button joinBtn;
        private System.Windows.Forms.TextBox txt_roomcode;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.Label lb_money;
    }
}