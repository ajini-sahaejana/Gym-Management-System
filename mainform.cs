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
            Size = new Size(1366, 768);
            viewStaffData();
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

        private void manageMember_Click(object sender, EventArgs e)
        {
            memberform m1 = new memberform();
            m1.Show();
        }

        private void manageTrainer_Click(object sender, EventArgs e)
        {
            trainerform t1 = new trainerform();
            t1.Show();
        }

        private void manageSession_Click(object sender, EventArgs e)
        {
            sessionform s1 = new sessionform();
            s1.Show();
        }

        private void manageMembership_Click(object sender, EventArgs e)
        {
            membershipform mb1 = new membershipform();
            mb1.Show();
        }

        private void managePurchase_Click(object sender, EventArgs e)
        {
            purchaseform p1 = new purchaseform();
            p1.Show();
        }

        private void manageStaff_Click_1(object sender, EventArgs e)
        {
            staffregform srf1 = new staffregform();
            srf1.Show();
        }

        private void logout_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Are you sure you want to exit?", "LogOut", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                Close();
            }
        }

        private void viewStaffData()
        {
            string onlyname = signinform.viewsname;
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\GitHub\Gym-Management-System\Database\GMS.mdf;Integrated Security=True;Connect Timeout=30");
                string query = "SELECT * from staff WHERE s_name = '" + onlyname + "' ";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                SqlDataReader reader;

                con.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    view_current.Text = "Staff Id: " + reader.GetInt32(0).ToString().Trim() + "\r\n\r\n" +
                        "Name: " + reader.GetString(5).Trim() + "\r\n\r\n" +
                        "Email: " + reader.GetString(2).Trim() + "\r\n\r\n" +
                        "Birth Date: " + reader.GetValue(6).ToString().Trim().Substring(0,10) + "\r\n\r\n" +
                        "Age: " + reader.GetString(7).Trim() + "\r\n\r\n" +
                        "Gender: " + reader.GetString(8).Trim() + "\r\n\r\n" +
                        "Address: " + reader.GetString(9).Trim() + "\r\n\r\n" +
                        "Contact No: " + reader.GetString(10).Trim();
                }

                con.Close();
            }
            catch (Exception e2)
            {
                MessageBox.Show(e2.Message);
            }
        }
    }
}
