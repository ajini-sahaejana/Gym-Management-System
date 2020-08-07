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
            fillListbox();
            viewsid(); 
            Size = new Size(1366, 768);
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
                    string uname = reader.GetString(1);
                    //string fullname = reader.GetString(5);
                    lbStaff.Items.Add(id + ": " + uname);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            con.Close();
        }

        //Clear Listbox
        private void clearListbox()
        {
            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ajini Sahejana\source\repos\Gym-Management-System\Database\GMS.mdf;Integrated Security=True;Connect Timeout=30");
            //string query = "SELECT * from Session";
            //SqlCommand cmd = new SqlCommand(query, con);
            //SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            try
            {
                //con.Open();
                lbStaff.Items.Clear();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            //con.Close();
        }

        //Search Staff
        private void searchstaff(string values)
        {
            if (searchbyid.Checked == true)
            {
                lbStaff.SelectedItems.Clear();

                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ajini Sahejana\source\repos\Gym-Management-System\Database\GMS.mdf;Integrated Security=True;Connect Timeout=30");
                string query = " SELECT * FROM Staff WHERE s_id LIKE '%" + values + "%' ";
                con.Open();

                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader;

                try
                {
                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {

                        string id = reader.GetInt32(0).ToString();
                        string uname = reader.GetString(1);
                        //string fullname = reader.GetString(5);
                        lbStaff.Items.Add(id + ": " + uname);
                    }
                }
                catch (Exception e2)
                {
                    MessageBox.Show(e2.Message);
                }

                con.Close();
            }
            else
            {
                lbStaff.SelectedItems.Clear();

                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ajini Sahejana\source\repos\Gym-Management-System\Database\GMS.mdf;Integrated Security=True;Connect Timeout=30");
                string query = " SELECT * FROM Staff WHERE s_name LIKE '%" + values + "%' ";
                con.Open();

                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader;

                try
                {
                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string id = reader.GetInt32(0).ToString();
                        string uname = reader.GetString(1);
                        //string fullname = reader.GetString(5);
                        lbStaff.Items.Add(id + ": " + uname);
                    }
                }
                catch (Exception e2)
                {
                    MessageBox.Show(e2.Message);
                }

                con.Close();
            }

        }

        //---------------------------------------------SQL---------------------------------------------------

        private void s_save_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ajini Sahejana\source\repos\Gym-Management-System\Database\GMS.mdf;Integrated Security=True;Connect Timeout=30");
            string query = "SELECT * from Staff";

            try
            {
                con.Open();
                //Fill Dataset
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                DataSet set = new DataSet();
                adapter.Fill(set, "Staff");

                //Add new row to database
                DataRow row = set.Tables["Staff"].NewRow();
                row["s_name"] = this.s_usernametext.Text;
                row["s_email"] = this.s_emailtext.Text;
                row["s_pword"] = this.s_pwordtext.Text;
                row["s_conpword"] = this.s_conpwordtext.Text;
                row["s_fullname"] = this.s_fullnametext.Text;
                row["s_dob"] = this.s_dobtext.Value;
                row["s_age"] = this.s_agetext.Text;
                row["s_gender"] = this.radiobuttoncheck();
                row["s_address"] = this.s_addresstext.Text;
                row["s_contactno"] = this.s_contactnotext.Text;
                row["s_hireddate"] = this.s_hireddatetext.Value;
                row["s_notes"] = this.s_notestext.Text;

                set.Tables["Staff"].Rows.Add(row);

                //Updating Database Table
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                adapter.Update(set.Tables["Staff"]);

                MessageBox.Show("Staff Account Created Successfully!");
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }

            con.Close();

            cleartext();

            clearListbox();

            fillListbox();

            viewsid();

            s_searchtext.Clear();
        }


        private void s_update_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ajini Sahejana\source\repos\Gym-Management-System\Database\GMS.mdf;Integrated Security=True;Connect Timeout=30");
            string query = "UPDATE Staff SET " +
                "s_name = '"+this.s_usernametext.Text+"'," +
                "s_email = '"+this.s_emailtext.Text+"', " +
                "s_pword = '" + this.s_pwordtext.Text + "', " +
                "s_conpword = '" + this.s_conpwordtext.Text + "', " +
                "s_fullname = '" + this.s_fullnametext.Text + "', " +
                "s_dob = '" + this.s_dobtext.Value + "', " +
                "s_age = '" + this.s_agetext.Text + "', " +
                "s_gender = '" + this.radiobuttoncheck() + "', " +
                "s_address = '" + this.s_addresstext.Text + "', " +
                "s_contactno = '" + this.s_contactnotext.Text + "', " +
                "s_hireddate = '" + this.s_hireddatetext.Value + "', " +
                "s_notes = '" + this.s_notestext.Text + "'" +
                "WHERE s_id = '" + this.s_idtext.Text + "' ";

            con.Open();

            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            adapter.SelectCommand.ExecuteNonQuery();

            MessageBox.Show("Staff Account Updated Successfully!");

            con.Close();

            cleartext();

            clearListbox();

            fillListbox();

            viewsid();

            s_searchtext.Clear();
        }

        private void s_cancel_Click(object sender, EventArgs e)
        {
            cleartext();

            clearListbox();

            fillListbox();

            viewsid();

            s_searchtext.Clear();
        }

        private void s_delete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ajini Sahejana\source\repos\Gym-Management-System\Database\GMS.mdf;Integrated Security=True;Connect Timeout=30");
            string query = "DELETE FROM Staff WHERE s_id =  '" + this.s_idtext.Text + "' ";

            con.Open();

            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            adapter.SelectCommand.ExecuteNonQuery();

            MessageBox.Show("Staff Account Deleted Successfully!");

            con.Close();

            cleartext();

            clearListbox();

            fillListbox();

            s_searchtext.Clear();
        }

        private void lbStaff_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string onlyid = lbStaff.Text.Substring(0, 6);

                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ajini Sahejana\source\repos\Gym-Management-System\Database\GMS.mdf;Integrated Security=True;Connect Timeout=30");
                string query = "SELECT * FROM Staff WHERE s_id = '" + onlyid + "' ";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader;

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

                con.Close();
            }
            catch (Exception er)
            {
                //MessageBox.Show(er.Message);
            }
        }


        private void s_searchtext_TextChanged(object sender, EventArgs e)
        {
            string values = s_searchtext.Text.ToString().ToLower();
            if (values == "")
            {
                clearListbox();
                fillListbox();
            }
            else
            {
                clearListbox();
                searchstaff(values);
            }
        }

        private void goback_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Any unsaved changed wont't be saved. Are you sure?", "Go Back to Homepage", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                Close();
            }
        }
    }
}