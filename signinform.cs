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
            username.Clear();
            picUser.BackgroundImage = Properties.Resources.user2;
            panel1.BackColor = Color.FromArgb(0, 171, 255);
            username.ForeColor = Color.FromArgb(0, 171, 255);

            picEmail.BackgroundImage = Properties.Resources.email1;
            panel2.BackColor = Color.WhiteSmoke;
            email.ForeColor = Color.WhiteSmoke;

            picPword.BackgroundImage = Properties.Resources.pword2;
            panel3.BackColor = Color.WhiteSmoke;
            pword.ForeColor = Color.WhiteSmoke;
        }

        private void email_Click(object sender, EventArgs e)
        {
            email.Clear();
            picEmail.BackgroundImage = Properties.Resources.email2;
            panel2.BackColor = Color.FromArgb(0, 171, 255);
            email.ForeColor = Color.FromArgb(0, 171, 255);

            picUser.BackgroundImage = Properties.Resources.user1;
            panel1.BackColor = Color.WhiteSmoke;
            username.ForeColor = Color.WhiteSmoke;

            picPword.BackgroundImage = Properties.Resources.pword2;
            panel3.BackColor = Color.WhiteSmoke;
            pword.ForeColor = Color.WhiteSmoke;
        }

        private void password_Click(object sender, EventArgs e)
        {
            pword.Clear();
            pword.PasswordChar = '*';
            picPword.BackgroundImage = Properties.Resources.pword3;
            panel3.BackColor = Color.FromArgb(0, 171, 255);
            pword.ForeColor = Color.FromArgb(0, 171, 255);

            picUser.BackgroundImage = Properties.Resources.user1;
            panel1.BackColor = Color.WhiteSmoke;
            username.ForeColor = Color.WhiteSmoke;

            picEmail.BackgroundImage = Properties.Resources.email1;
            panel2.BackColor = Color.WhiteSmoke;
            email.ForeColor = Color.WhiteSmoke;
        }

        private void signin_MouseHover(object sender, EventArgs e)
        {
            signin.BackColor = Color.FromArgb(0, 171, 255);
        }

        private void signin_MouseLeave(object sender, EventArgs e)
        {
            signin.BackColor = Color.FromArgb(50,50,50);
        }

        private void register_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please Log In with a current Staff Member in order to create a new Staff Account.");
        }
    }
}
