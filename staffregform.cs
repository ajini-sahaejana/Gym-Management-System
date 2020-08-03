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
using System.Security.Cryptography.X509Certificates;

namespace Gym_Management_System
{
    public partial class staffregform : Form
    {
        public staffregform()
        {
            InitializeComponent();
            fillListbox();
            viewsid();
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

        //View Staff_id in the form
        private void viewsid()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ajini Sahejana\source\repos\Gym-Management-System\Database\GMS.mdf;Integrated Security=True;Connect Timeout=30");
            string query = "SELECT s_id FROM Staff WHERE s_id = (SELECT MAX(s_id) FROM Staff) ";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            SqlDataReader reader;
            try
            {
                con.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    id++;
                    s_idtext.Text = Convert.ToString(id);
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
            con.Close();
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

        //Clear text after saving
        private void cleartext()
        {
            s_idtext.Clear();
            s_usernametext.Clear();
            s_emailtext.Clear();
            s_pwordtext.Clear();
            s_conpwordtext.Clear();
            s_fullnametext.Clear();
            s_dobtext.Value = DateTime.Now;
            s_agetext.Clear();
            s_maletext.Checked = false;
            s_femaletext.Checked = false;
            s_othertext.Checked = false;
            s_addresstext.Clear();
            s_contactnotext.Clear();
            s_hireddatetext.Value = DateTime.Now;
            s_notestext.Clear();
        }

        private void s_conpwordtext_Leave(object sender, EventArgs e)
        {
            if (!(s_pwordtext.Text.Equals(s_conpwordtext.Text)))
            {
                label16.ForeColor = Color.Tomato;
            }
            else
            {
                label16.ForeColor = Color.FromArgb(36, 41, 46);
            }
        }
        /*
        //Refresh Listbox
        private void refreshSearch()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ajini Sahejana\source\repos\Gym-Management-System\Database\GMS.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();

            string query = "SELECT s_id, s_name from Staff";

            //Fill Dataset
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            DataTable table = new DataTable();
            adapter.Fill(table);

            //Bind the table to the list box
            lbStaff.DisplayMember = "s_name";
            lbStaff.ValueMember = "s_id";
            lbStaff.DataSource = table;

            con.Close();
        }*/

        //Fill Listbox
        private void fillListbox()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ajini Sahejana\source\repos\Gym-Management-System\Database\GMS.mdf;Integrated Security=True;Connect Timeout=30");
            string query = "SELECT * from Staff";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            SqlDataReader reader;
            try
            {
                con.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string id = reader.GetInt32(0).ToString();
                    string name = reader.GetString(1);
                    lbStaff.Items.Add(id + ": " + name);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        //Clear Listbox
        private void clearListbox()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ajini Sahejana\source\repos\Gym-Management-System\Database\GMS.mdf;Integrated Security=True;Connect Timeout=30");
            string query = "SELECT * from Staff";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            try
            {
                con.Open();
                lbStaff.Items.Clear();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
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

            clearListbox();

            fillListbox();

            viewsid();
        }


        private void s_update_Click(object sender, EventArgs e)
        {
            clearListbox();

            fillListbox();

            viewsid();
        }

        private void s_cancel_Click(object sender, EventArgs e)
        {
            cleartext();

            clearListbox();

            fillListbox();

            viewsid();
        }

        private void s_delete_Click(object sender, EventArgs e)
        {
            clearListbox();

            fillListbox();

            viewsid();
        }

        private void lbStaff_SelectedIndexChanged(object sender, EventArgs e)
        {
            string allid = new String(lbStaff.Text.Where(Char.IsDigit).ToArray());
            string onlyid = allid.Substring(0, 6);
            MessageBox.Show(onlyid);
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ajini Sahejana\source\repos\Gym-Management-System\Database\GMS.mdf;Integrated Security=True;Connect Timeout=30");
            string query = "SELECT * FROM Staff WHERE s_id = '" + onlyid + "' ";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            SqlDataReader reader;
            try
            {
                con.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    s_idtext.Text = reader.GetInt32(0).ToString().Trim();
                    s_usernametext.Text = reader.GetString(1).Trim();
                    s_emailtext.Text = reader.GetString(2).Trim();
                    s_pwordtext.Text = reader.GetString(3).Trim();
                    s_conpwordtext.Text = reader.GetString(4).Trim();
                    s_fullnametext.Text = reader.GetString(5).Trim();
                    s_dobtext.Value = reader.GetDateTime(6);
                    s_agetext.Text = reader.GetString(7).Trim();

                    //Radio button check
                    if (reader.GetString(8).Trim() == "Male")
                    {
                        s_maletext.Checked = true;
                    }
                    else if (reader.GetString(8).Trim() == "Female")
                    {
                        s_femaletext.Checked = true;
                    }
                    else
                    {
                        s_othertext.Checked = true;
                    }

                    s_addresstext.Text = reader.GetString(9).Trim();
                    s_contactnotext.Text = reader.GetString(10).Trim();
                    s_hireddatetext.Value = reader.GetDateTime(11);
                    s_notestext.Text = reader.GetString(12).Trim();
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }
    }
}