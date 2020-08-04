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

        //View username in the form
        private void welcomemsg()
        {
            string name = signinform.viewsname;
            welcometext.Text = "Welcome " + name + "!";
        }

        private void mainform_Load(object sender, EventArgs e)
        {
            Timer t = new Timer();
            t.Interval = 1000;
            t.Tick += new EventHandler(this.t_Tick);
            t.Start();
        }

        private void t_Tick(object sender, EventArgs e)
        {
            string time = DateTime.Now.ToLongTimeString();
            string date = DateTime.Now.ToLongDateString();
            showtime.Text = time;
            showdate.Text = date;
        }

        private void manageStaff_Click_1(object sender, EventArgs e)
        {
            staffregform srf1 = new staffregform();
            srf1.Show();
        }

        private void manageMember_Click(object sender, EventArgs e)
        {
            staffregform srf1 = new staffregform();
            srf1.Show();
        }
    }
}
