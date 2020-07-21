using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gym_Management_System
{
    public partial class signinform : Form
    {
        public signinform()
        {
            InitializeComponent();
        }

        private void username_Click(object sender, EventArgs e)
        {
            picUser.BackgroundImage = Properties.Resources.user2;
            panel1.BackColor = Color.DarkTurquoise;
            username.ForeColor = Color.DarkTurquoise;

            picEmail.BackgroundImage = Properties.Resources.email1;
            panel2.BackColor = Color.WhiteSmoke;
            email.ForeColor = Color.WhiteSmoke;

            picPword.BackgroundImage = Properties.Resources.pword2;
            panel3.BackColor = Color.WhiteSmoke;
            pword.ForeColor = Color.WhiteSmoke;
        }

        private void username_Enter(object sender, EventArgs e)
        {
            if (username.Text == "Username")
            {
                username.Text = "";
            }
        }

        private void username_Leave(object sender, EventArgs e)
        {
            if (username.Text == "")
            {
                username.Text = "Username";
            }
        }

        private void email_Click(object sender, EventArgs e)
        {
            picEmail.BackgroundImage = Properties.Resources.email2;
            panel2.BackColor = Color.DarkTurquoise;
            email.ForeColor = Color.DarkTurquoise;

            picUser.BackgroundImage = Properties.Resources.user1;
            panel1.BackColor = Color.WhiteSmoke;
            username.ForeColor = Color.WhiteSmoke;

            picPword.BackgroundImage = Properties.Resources.pword2;
            panel3.BackColor = Color.WhiteSmoke;
            pword.ForeColor = Color.WhiteSmoke;
        }

        private void email_Enter(object sender, EventArgs e)
        {
            if (email.Text == "Email")
            {
                email.Text = "";
            }
        }

        private void email_Leave(object sender, EventArgs e)
        {
            if (email.Text == "")
            {
                email.Text = "Email";
            }
        }

        private void password_Click(object sender, EventArgs e)
        {
            picPword.BackgroundImage = Properties.Resources.pword3;
            panel3.BackColor = Color.DarkTurquoise;
            pword.ForeColor = Color.DarkTurquoise;

            picUser.BackgroundImage = Properties.Resources.user1;
            panel1.BackColor = Color.WhiteSmoke;
            username.ForeColor = Color.WhiteSmoke;

            picEmail.BackgroundImage = Properties.Resources.email1;
            panel2.BackColor = Color.WhiteSmoke;
            email.ForeColor = Color.WhiteSmoke;
        }

        private void pword_Enter(object sender, EventArgs e)
        {
            if (pword.Text == "Password")
            {
                pword.Text = "";
                pword.UseSystemPasswordChar = true;
            }
        }

        private void pword_Leave(object sender, EventArgs e)
        {
            if (pword.Text == "")
            {
                pword.Text = "Password";
                pword.UseSystemPasswordChar = false;
            }
        }
        

        private void register_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please Log In with a current Staff Member in order to create a new Staff Account.");
        }

        //Sign In Button 
        private void signin_MouseHover(object sender, EventArgs e)
        {
            signin.FlatAppearance.MouseOverBackColor = Color.DarkSlateGray;
        }

        private void signin_MouseLeave(object sender, EventArgs e)
        {
            signin.BackColor = Color.Transparent;
        }

        private void signin_MouseDown(object sender, MouseEventArgs e)
        {
            picUser.BackgroundImage = Properties.Resources.user1;
            panel1.BackColor = Color.WhiteSmoke;
            username.ForeColor = Color.WhiteSmoke;

            picEmail.BackgroundImage = Properties.Resources.email1;
            panel2.BackColor = Color.WhiteSmoke;
            email.ForeColor = Color.WhiteSmoke;

            picPword.BackgroundImage = Properties.Resources.pword2;
            panel3.BackColor = Color.WhiteSmoke;
            pword.ForeColor = Color.WhiteSmoke;
        }
    }
}
