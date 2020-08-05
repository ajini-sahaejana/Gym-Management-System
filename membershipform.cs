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
    public partial class membershipform : Form
    {
        public membershipform()
        {
            InitializeComponent();
            viewsid();
            fillListbox();
            MinimumSize = new Size(1366, 768);
            Size = new Size(1366, 768);
        }

        private void goback_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Any unsaved changed wont't be saved. Are you sure?", "Go Back to Homepage", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                Close();
            }
        }

        //View membership_Id in the form
        private void viewsid()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ajini Sahejana\source\repos\Gym-Management-System\Database\GMS.mdf;Integrated Security=True;Connect Timeout=30");
                string query = "SELECT ms_id FROM Membership WHERE ms_id = (SELECT MAX(ms_id) FROM Membership) ";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                SqlDataReader reader;

                con.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    id++;
                    ms_idtext.Text = Convert.ToString(id);
                }

                con.Close();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        //Clear text after saving
        private void cleartext()
        {
            ms_idtext.Clear();
            ms_nametext.Clear();
            ms_periodtext.Clear();
            ms_feetext.Clear();
            ms_notestext.Clear();
        }

        //Fill Listbox
        private void fillListbox()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ajini Sahejana\source\repos\Gym-Management-System\Database\GMS.mdf;Integrated Security=True;Connect Timeout=30");
                string query = "SELECT * from Membership";
                SqlCommand cmd = new SqlCommand(query, con);
                //SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                SqlDataReader reader;

                con.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string id = reader.GetInt32(0).ToString();
                    string name = reader.GetString(1);
                    //string date = reader.GetDateTime(2).ToString();
                    lbMembership.Items.Add(id + ": " + name);
                }

                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        //Clear Listbox
        private void clearListbox()
        {
            try
            {
                lbMembership.Items.Clear();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        //Search Staff
        private void searchmembership(string values)
        {
            if (searchbyid.Checked == true)
            {
                try
                {
                    lbMembership.SelectedItems.Clear();

                    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ajini Sahejana\source\repos\Gym-Management-System\Database\GMS.mdf;Integrated Security=True;Connect Timeout=30");
                    string query = " SELECT * FROM Membership WHERE ms_id LIKE '%" + values + "%' ";
                    con.Open();

                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader reader;

                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string id = reader.GetInt32(0).ToString();
                        string name = reader.GetString(1);
                        
                        lbMembership.Items.Add(id + ": " + name);
                    }

                    con.Close();
                }
                catch (Exception e2)
                {
                    MessageBox.Show(e2.Message);
                }
            }
            else
            {
                try
                {
                    lbMembership.SelectedItems.Clear();

                    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ajini Sahejana\source\repos\Gym-Management-System\Database\GMS.mdf;Integrated Security=True;Connect Timeout=30");
                    string query = " SELECT * FROM Membership WHERE ms_name LIKE '%" + values + "%' ";
                    con.Open();

                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader reader;

                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string id = reader.GetInt32(0).ToString();
                        string name = reader.GetString(1);
                        
                        lbMembership.Items.Add(id + ": " + name);
                    }

                    con.Close();
                }
                catch (Exception e2)
                {
                    MessageBox.Show(e2.Message);
                }
            }
        }

        //------------------------------------SQL-------------------------------------

        private void ms_save_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ajini Sahejana\source\repos\Gym-Management-System\Database\GMS.mdf;Integrated Security=True;Connect Timeout=30");
                string query = "SELECT * from Membership";

                con.Open();
                //Fill Dataset
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                DataSet set = new DataSet();
                adapter.Fill(set, "Membership");

                //Add new row to database
                DataRow row = set.Tables["Membership"].NewRow();
                row["ms_name"] = this.ms_nametext.Text.Trim();
                row["ms_period"] = this.ms_periodtext.Text.Trim();
                row["ms_fee"] = this.ms_feetext.Text.Trim();
                row["ms_notes"] = this.ms_notestext.Text.Trim();

                set.Tables["Membership"].Rows.Add(row);

                //Updating Database Table
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                adapter.Update(set.Tables["Membership"]);

                MessageBox.Show("Membership Created Successfully!");

                con.Close();

                cleartext();

                clearListbox();

                fillListbox();

                viewsid();

                ms_searchtext.Clear();
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

        private void ms_update_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ajini Sahejana\source\repos\Gym-Management-System\Database\GMS.mdf;Integrated Security=True;Connect Timeout=30");
            string query = "UPDATE Membership SET " +
                "ms_name = '" + ms_nametext.Text + "'," +
                "ms_period = '" + ms_periodtext.Text + "', " +
                "ms_fee = '" + ms_feetext.Text + "', " +
                "ms_notes = '" + ms_notestext.Text + "'" +
                "WHERE ms_id = '" + ms_idtext.Text + "' ";

            con.Open();

            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            adapter.SelectCommand.ExecuteNonQuery();

            MessageBox.Show("Membership Updated Successfully!");

            con.Close();

            cleartext();

            clearListbox();

            fillListbox();

            viewsid();

            ms_searchtext.Clear();
        }

        private void ms_cancel_Click(object sender, EventArgs e)
        {
            cleartext();

            clearListbox();

            fillListbox();

            viewsid();

            ms_searchtext.Clear();
        }

        private void ms_delete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ajini Sahejana\source\repos\Gym-Management-System\Database\GMS.mdf;Integrated Security=True;Connect Timeout=30");
            string query = "DELETE FROM Membership WHERE ms_id =  '" + this.ms_idtext.Text + "' ";

            con.Open();

            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            adapter.SelectCommand.ExecuteNonQuery();

            MessageBox.Show("Membership Deleted Successfully!");

            con.Close();

            cleartext();

            clearListbox();

            fillListbox();

            ms_searchtext.Clear();
        }

        private void lbMembership_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string onlyid = lbMembership.Text.Substring(0, 6);

                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ajini Sahejana\source\repos\Gym-Management-System\Database\GMS.mdf;Integrated Security=True;Connect Timeout=30");
                string query = "SELECT * FROM Membership WHERE ms_id = '" + onlyid + "' ";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader;

                con.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ms_idtext.Text = reader.GetInt32(0).ToString().Trim();
                    ms_nametext.Text = reader.GetString(1).Trim();
                    ms_periodtext.Text = reader.GetString(2).Trim();
                    ms_feetext.Text = reader.GetString(3).Trim();
                    ms_notestext.Text = reader.GetString(4).Trim();
                }

                con.Close();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void ms_searchtext_TextChanged(object sender, EventArgs e)
        {
            string values = ms_searchtext.Text.ToString().ToLower();
            if (values == "")
            {
                clearListbox();
                fillListbox();
            }
            else
            {
                clearListbox();
                searchmembership(values);
            }
        }
    }
}
