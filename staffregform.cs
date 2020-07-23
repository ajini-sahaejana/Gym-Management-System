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
    public partial class staffregform : Form
    {
        public staffregform()
        {
            InitializeComponent();
        }

        private void s_showpword_MouseDown(object sender, MouseEventArgs e)
        {
            s_pwordtext.UseSystemPasswordChar = false;
            s_showpword.BackgroundImage = Properties.Resources.eyeopen;
        }

        private void s_showpword_MouseUp(object sender, MouseEventArgs e)
        {
            s_pwordtext.UseSystemPasswordChar = true;
            s_showpword.BackgroundImage = Properties.Resources.eyeclose;
        }

        private void s_showconpword_MouseDown(object sender, MouseEventArgs e)
        {
            s_conpwordtext.UseSystemPasswordChar = false;
            s_showconpword.BackgroundImage = Properties.Resources.eyeopen;
        }

        private void s_showconpword_MouseUp(object sender, MouseEventArgs e)
        {
            s_conpwordtext.UseSystemPasswordChar = true;
            s_showconpword.BackgroundImage = Properties.Resources.eyeclose;
        }

        //Radio Button Selection
        private string radiobuttoncheck()
        {
            if (s_maletext.Checked)
            {
                return s_maletext.Text;
            }
            else if (s_femaletext.Checked)
            {
                return s_femaletext.Text;
            }
            else
            {
                return s_othertext.Text;
            }
        }
        

        //---------------------------------------------SQL---------------------------------------------------

        private void s_save_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ajini Sahejana\source\repos\Gym-Management-System\Database\GMS.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            string query = "SELECT * from Staff";

            //Fill Dataset
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            DataSet set = new DataSet();
            adapter.Fill(set, "Staff");

            //Add new row to database
            DataRow row = set.Tables["Staff"].NewRow();
            row["s_name"] = s_usernametext.Text;
            row["s_email"] = s_emailtext.Text;
            row["s_pword"] = s_pwordtext.Text;
            row["s_conpword"] = s_conpwordtext.Text;
            row["s_fullname"] = s_fullnametext.Text;
            row["s_dob"] = s_dobtext.Value;
            row["s_age"] = s_agetext.Text;
            row["s_gender"] = radiobuttoncheck();
            row["s_address"] = s_addresstext.Text;
            row["s_contactno"] = s_contactnotext.Text;
            row["s_hireddate"] = s_hireddatetext.Value;
            row["s_notes"] = s_notestext.Text;

            set.Tables["Staff"].Rows.Add(row);

            //Updating Database Table
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            adapter.Update(set.Tables["Staff"]);

            MessageBox.Show("Staff Account Created Successfully!");

            con.Close();

            cleartext();
        }
    }
}
