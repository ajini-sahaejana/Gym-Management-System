namespace Gym_Management_System
{
    partial class mainform
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainform));
            this.button1 = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.showdate = new System.Windows.Forms.Label();
            this.showtime = new System.Windows.Forms.Label();
            this.welcometext = new System.Windows.Forms.Label();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(195, 476);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 30);
            this.button1.TabIndex = 0;
            this.button1.Text = "Staff";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.DarkTurquoise;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(1361, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(5, 744);
            this.panel4.TabIndex = 21;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.DarkTurquoise;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 744);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1366, 5);
            this.panel5.TabIndex = 20;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(54)))), ((int)(((byte)(61)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(50, 744);
            this.panel2.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(33)))), ((int)(((byte)(37)))));
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Arial", 11F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(50, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1311, 25);
            this.label1.TabIndex = 23;
            this.label1.Text = "GMS Administration Portal";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(35)))), ((int)(((byte)(40)))));
            this.panel3.Location = new System.Drawing.Point(1001, 291);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(350, 460);
            this.panel3.TabIndex = 26;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(35)))), ((int)(((byte)(40)))));
            this.panel6.Controls.Add(this.showdate);
            this.panel6.Controls.Add(this.showtime);
            this.panel6.Location = new System.Drawing.Point(1001, 94);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(350, 185);
            this.panel6.TabIndex = 0;
            // 
            // showdate
            // 
            this.showdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showdate.Font = new System.Drawing.Font("Arial", 10F);
            this.showdate.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.showdate.Location = new System.Drawing.Point(10, 105);
            this.showdate.Name = "showdate";
            this.showdate.Size = new System.Drawing.Size(330, 45);
            this.showdate.TabIndex = 1;
            this.showdate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // showtime
            // 
            this.showtime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showtime.Font = new System.Drawing.Font("Arial Rounded MT Bold", 39.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showtime.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.showtime.Location = new System.Drawing.Point(10, 10);
            this.showtime.Name = "showtime";
            this.showtime.Size = new System.Drawing.Size(330, 150);
            this.showtime.TabIndex = 0;
            this.showtime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // welcometext
            // 
            this.welcometext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            this.welcometext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.welcometext.Font = new System.Drawing.Font("Arial", 20F);
            this.welcometext.ForeColor = System.Drawing.Color.MediumTurquoise;
            this.welcometext.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.welcometext.Location = new System.Drawing.Point(53, 25);
            this.welcometext.Name = "welcometext";
            this.welcometext.Size = new System.Drawing.Size(1295, 58);
            this.welcometext.TabIndex = 27;
            this.welcometext.Text = "Welcome";
            this.welcometext.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            this.ClientSize = new System.Drawing.Size(1366, 749);
            this.Controls.Add(this.welcometext);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel3);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1364, 736);
            this.Name = "mainform";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.mainform_Load);
            this.panel6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel4;
        public System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label welcometext;
        private System.Windows.Forms.Label showtime;
        private System.Windows.Forms.Label showdate;
    }
}