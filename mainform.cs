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
    public partial class mainform : Form
    {
        public mainform()
        {
            InitializeComponent();
            welcomemsg();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            staffregform srf1 = new staffregform();
            srf1.Show();
        }

        //View username in the form
        private void welcomemsg()
        {
            string name = signinform.viewsname;
            welcometext.Text = "  Welcome " + name + "!   ";
        }
    }
}
