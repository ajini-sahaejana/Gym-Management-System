using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

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
            picUser.BackgroundImage = Properties.Resources.user;
            panel1.BackColor = Color.DarkTurquoise;
            loginusername.ForeColor = Color.DarkTurquoise;

            picEmail.BackgroundImage = Properties.Resources.email1;
            panel2.BackColor = Color.WhiteSmoke;
            loginemail.ForeColor = Color.WhiteSmoke;

            picPword.BackgroundImage = Properties.Resources.pword1;
            panel3.BackColor = Color.WhiteSmoke;
            loginpword.ForeColor = Color.WhiteSmoke;

            showpword.BackgroundImage = Properties.Resources.eyeclose1;
        }

        private void username_Enter(object sender, EventArgs e)
        {
            if (loginusername.Text == "Username")
            {
                loginusername.Text = "";
            }
        }

        private void username_Leave(object sender, EventArgs e)
        {
            if (loginusername.Text == "")
            {
                loginusername.Text = "Username";
            }
        }

        private void email_Click(object sender, EventArgs e)
        {
            picEmail.BackgroundImage = Properties.Resources.email;
            panel2.BackColor = Color.DarkTurquoise;
            loginemail.ForeColor = Color.DarkTurquoise;

            picUser.BackgroundImage = Properties.Resources.user1;
            panel1.BackColor = Color.WhiteSmoke;
            loginusername.ForeColor = Color.WhiteSmoke;

            picPword.BackgroundImage = Properties.Resources.pword1;
            panel3.BackColor = Color.WhiteSmoke;
            loginpword.ForeColor = Color.WhiteSmoke;

            showpword.BackgroundImage = Properties.Resources.eyeclose1;
        }

        private void email_Enter(object sender, EventArgs e)
        {
            if (loginemail.Text == "Email")
            {
                loginemail.Text = "";
            }
        }

        private void email_Leave(object sender, EventArgs e)
        {
            if (loginemail.Text == "")
            {
                loginemail.Text = "Email";
            }
        }

        private void password_Click(object sender, EventArgs e)
        {
            picPword.BackgroundImage = Properties.Resources.pword;
            panel3.BackColor = Color.DarkTurquoise;
            loginpword.ForeColor = Color.DarkTurquoise;

            picUser.BackgroundImage = Properties.Resources.user1;
            panel1.BackColor = Color.WhiteSmoke;
            loginusername.ForeColor = Color.WhiteSmoke;

            picEmail.BackgroundImage = Properties.Resources.email1;
            panel2.BackColor = Color.WhiteSmoke;
            loginemail.ForeColor = Color.WhiteSmoke;
        }

        private void pword_Enter(object sender, EventArgs e)
        {
            if (loginpword.Text == "Password")
            {
                loginpword.Text = "";
                loginpword.UseSystemPasswordChar = true;
            }
        }

        private void pword_Leave(object sender, EventArgs e)
        {
            if (loginpword.Text == "")
            {
                loginpword.Text = "Password";
                loginpword.UseSystemPasswordChar = false;
            }
        }
        

        private void register_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please Log In with a current Staff Member in order to create a new Staff Account.");
        }

        //Sign In Button
        private void signin_MouseLeave(object sender, EventArgs e)
        {
            signin.BackColor = Color.Transparent;
        }

        private void signin_MouseDown(object sender, MouseEventArgs e)
        {
            picUser.BackgroundImage = Properties.Resources.user1;
            panel1.BackColor = Color.WhiteSmoke;
            loginusername.ForeColor = Color.WhiteSmoke;

            picEmail.BackgroundImage = Properties.Resources.email1;
            panel2.BackColor = Color.WhiteSmoke;
            loginemail.ForeColor = Color.WhiteSmoke;

            picPword.BackgroundImage = Properties.Resources.pword1;
            panel3.BackColor = Color.WhiteSmoke;
            loginpword.ForeColor = Color.WhiteSmoke;

            showpword.BackgroundImage = Properties.Resources.eyeclose1;
        }

        private void close_Click(object sender, EventArgs e)
        {
            Close();
            ActiveForm.Close();
        }
                        
        //---------------------------------------SQL---------------------------------------------//
        private void signin_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ajini Sahejana\source\repos\Gym-Management-System\Database\GMS.mdf;Integrated Security=True;Connect Timeout=30");
            string query = "SELECT * FROM Staff WHERE s_name = '" + loginusername.Text.Trim() + "' AND s_email='" + loginemail.Text.Trim() + "' AND s_pword='" + loginpword.Text.Trim() + "'";
            SqlDataAdapter s1 = new SqlDataAdapter(query, con);
            DataTable dtbl1 = new DataTable();
            s1.Fill(dtbl1);
            if (dtbl1.Rows.Count == 1)
            {
                mainform mf1 = new mainform();
                this.Hide();
                ActiveForm.Hide();
                mf1.Show();
            }
            else
            {
                MessageBox.Show("The details you have entered is not a match. Please try again.");
            }
        }

        private void showpword_MouseDown(object sender, MouseEventArgs e)
        {
            loginpword.UseSystemPasswordChar = false;
            showpword.BackgroundImage = Properties.Resources.eyeopen;
        }
        private void showpword_MouseUp(object sender, MouseEventArgs e)
        {
            loginpword.UseSystemPasswordChar = true;
            showpword.BackgroundImage = Properties.Resources.eyeclose;
        }

    }
}
