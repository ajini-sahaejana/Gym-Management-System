namespace Gym_Management_System
{
    partial class signinform
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(signinform));
            this.loginusername = new System.Windows.Forms.TextBox();
            this.loginemail = new System.Windows.Forms.TextBox();
            this.loginpword = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.register = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.signin = new System.Windows.Forms.Button();
            this.picPword = new System.Windows.Forms.PictureBox();
            this.picEmail = new System.Windows.Forms.PictureBox();
            this.picUser = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.close = new System.Windows.Forms.Label();
            this.showpword = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picPword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // loginusername
            // 
            this.loginusername.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            this.loginusername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.loginusername.Font = new System.Drawing.Font("Arial", 11F);
            this.loginusername.ForeColor = System.Drawing.Color.White;
            this.loginusername.Location = new System.Drawing.Point(58, 190);
            this.loginusername.Name = "loginusername";
            this.loginusername.Size = new System.Drawing.Size(200, 17);
            this.loginusername.TabIndex = 0;
            this.loginusername.TabStop = false;
            this.loginusername.Text = "Username";
            this.loginusername.Click += new System.EventHandler(this.username_Click);
            this.loginusername.Enter += new System.EventHandler(this.username_Enter);
            this.loginusername.Leave += new System.EventHandler(this.username_Leave);
            // 
            // loginemail
            // 
            this.loginemail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            this.loginemail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.loginemail.Font = new System.Drawing.Font("Arial", 11F);
            this.loginemail.ForeColor = System.Drawing.Color.White;
            this.loginemail.Location = new System.Drawing.Point(58, 240);
            this.loginemail.Name = "loginemail";
            this.loginemail.Size = new System.Drawing.Size(200, 17);
            this.loginemail.TabIndex = 0;
            this.loginemail.TabStop = false;
            this.loginemail.Text = "Email";
            this.loginemail.Click += new System.EventHandler(this.email_Click);
            this.loginemail.Enter += new System.EventHandler(this.email_Enter);
            this.loginemail.Leave += new System.EventHandler(this.email_Leave);
            // 
            // loginpword
            // 
            this.loginpword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            this.loginpword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.loginpword.Font = new System.Drawing.Font("Arial", 11F);
            this.loginpword.ForeColor = System.Drawing.Color.White;
            this.loginpword.Location = new System.Drawing.Point(58, 290);
            this.loginpword.Name = "loginpword";
            this.loginpword.Size = new System.Drawing.Size(200, 17);
            this.loginpword.TabIndex = 0;
            this.loginpword.TabStop = false;
            this.loginpword.Text = "Password";
            this.loginpword.Click += new System.EventHandler(this.password_Click);
            this.loginpword.Enter += new System.EventHandler(this.pword_Enter);
            this.loginpword.Leave += new System.EventHandler(this.pword_Leave);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(28, 214);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(230, 1);
            this.panel1.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(29, 264);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(230, 1);
            this.panel2.TabIndex = 8;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Location = new System.Drawing.Point(29, 314);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(230, 1);
            this.panel3.TabIndex = 9;
            // 
            // register
            // 
            this.register.AutoSize = true;
            this.register.BackColor = System.Drawing.Color.Transparent;
            this.register.Cursor = System.Windows.Forms.Cursors.Hand;
            this.register.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.register.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.register.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.register.Location = new System.Drawing.Point(114, 405);
            this.register.Name = "register";
            this.register.Size = new System.Drawing.Size(54, 15);
            this.register.TabIndex = 0;
            this.register.Text = "Register";
            this.register.Click += new System.EventHandler(this.register_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(121, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 22);
            this.label1.TabIndex = 15;
            this.label1.Text = "GMS";
            // 
            // signin
            // 
            this.signin.BackColor = System.Drawing.Color.Transparent;
            this.signin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.signin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.signin.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.signin.FlatAppearance.BorderColor = System.Drawing.Color.DarkTurquoise;
            this.signin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(33)))), ((int)(((byte)(37)))));
            this.signin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.signin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.signin.Font = new System.Drawing.Font("Arial", 15F);
            this.signin.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.signin.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.signin.Location = new System.Drawing.Point(28, 360);
            this.signin.Margin = new System.Windows.Forms.Padding(1);
            this.signin.Name = "signin";
            this.signin.Size = new System.Drawing.Size(230, 35);
            this.signin.TabIndex = 0;
            this.signin.TabStop = false;
            this.signin.Text = "Sign In";
            this.signin.UseVisualStyleBackColor = false;
            this.signin.Click += new System.EventHandler(this.signin_Click);
            this.signin.MouseDown += new System.Windows.Forms.MouseEventHandler(this.signin_MouseDown);
            this.signin.MouseLeave += new System.EventHandler(this.signin_MouseLeave);
            this.signin.MouseHover += new System.EventHandler(this.signin_MouseHover);
            // 
            // picPword
            // 
            this.picPword.BackColor = System.Drawing.Color.Transparent;
            this.picPword.Image = global::Gym_Management_System.Properties.Resources.pword1;
            this.picPword.Location = new System.Drawing.Point(29, 285);
            this.picPword.Margin = new System.Windows.Forms.Padding(1);
            this.picPword.Name = "picPword";
            this.picPword.Size = new System.Drawing.Size(25, 25);
            this.picPword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPword.TabIndex = 3;
            this.picPword.TabStop = false;
            // 
            // picEmail
            // 
            this.picEmail.BackColor = System.Drawing.Color.Transparent;
            this.picEmail.Image = global::Gym_Management_System.Properties.Resources.email1;
            this.picEmail.Location = new System.Drawing.Point(29, 235);
            this.picEmail.Margin = new System.Windows.Forms.Padding(1);
            this.picEmail.Name = "picEmail";
            this.picEmail.Size = new System.Drawing.Size(25, 25);
            this.picEmail.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picEmail.TabIndex = 2;
            this.picEmail.TabStop = false;
            // 
            // picUser
            // 
            this.picUser.BackColor = System.Drawing.Color.Transparent;
            this.picUser.Image = global::Gym_Management_System.Properties.Resources.user1;
            this.picUser.Location = new System.Drawing.Point(29, 185);
            this.picUser.Margin = new System.Windows.Forms.Padding(1);
            this.picUser.Name = "picUser";
            this.picUser.Size = new System.Drawing.Size(25, 25);
            this.picUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picUser.TabIndex = 1;
            this.picUser.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(68, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(150, 125);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.DarkTurquoise;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(295, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(5, 450);
            this.panel4.TabIndex = 16;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.DarkTurquoise;
            this.panel5.Location = new System.Drawing.Point(0, 445);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(300, 5);
            this.panel5.TabIndex = 17;
            // 
            // close
            // 
            this.close.AutoSize = true;
            this.close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.close.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.close.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.close.Location = new System.Drawing.Point(272, 9);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(17, 16);
            this.close.TabIndex = 0;
            this.close.Text = "X";
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // showpword
            // 
            this.showpword.BackColor = System.Drawing.Color.Transparent;
            this.showpword.BackgroundImage = global::Gym_Management_System.Properties.Resources.eyeclose1;
            this.showpword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.showpword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.showpword.FlatAppearance.BorderSize = 0;
            this.showpword.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.showpword.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.showpword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showpword.Font = new System.Drawing.Font("Arial", 10F);
            this.showpword.Location = new System.Drawing.Point(238, 290);
            this.showpword.Name = "showpword";
            this.showpword.Size = new System.Drawing.Size(20, 20);
            this.showpword.TabIndex = 31;
            this.showpword.TabStop = false;
            this.showpword.UseVisualStyleBackColor = false;
            this.showpword.MouseDown += new System.Windows.Forms.MouseEventHandler(this.showpword_MouseDown);
            this.showpword.MouseUp += new System.Windows.Forms.MouseEventHandler(this.showpword_MouseUp);
            // 
            // signinform
            // 
            this.AcceptButton = this.signin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(300, 450);
            this.Controls.Add(this.showpword);
            this.Controls.Add(this.close);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.signin);
            this.Controls.Add(this.register);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.loginpword);
            this.Controls.Add(this.loginemail);
            this.Controls.Add(this.loginusername);
            this.Controls.Add(this.picPword);
            this.Controls.Add(this.picEmail);
            this.Controls.Add(this.picUser);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "signinform";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "  ";
            ((System.ComponentModel.ISupportInitialize)(this.picPword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox picUser;
        private System.Windows.Forms.PictureBox picEmail;
        private System.Windows.Forms.PictureBox picPword;
        private System.Windows.Forms.TextBox loginusername;
        private System.Windows.Forms.TextBox loginemail;
        private System.Windows.Forms.TextBox loginpword;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label register;
        private System.Windows.Forms.Button signin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel4;
        public System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label close;
        private System.Windows.Forms.Button showpword;
    }
}

