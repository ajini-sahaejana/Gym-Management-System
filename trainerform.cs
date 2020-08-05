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
    public partial class trainerform : Form
    {
        public trainerform()
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

        //View Trainer_Id in the form
        private void viewsid()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ajini Sahejana\source\repos\Gym-Management-System\Database\GMS.mdf;Integrated Security=True;Connect Timeout=30");
            string query = "SELECT t_id FROM Trainer WHERE t_id = (SELECT MAX(t_id) FROM Trainer) ";
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
                    t_idtext.Text = Convert.ToString(id);
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
            if (t_maletext.Checked)
            {
                return t_maletext.Text;
            }
            else if (t_femaletext.Checked)
            {
                return t_femaletext.Text;
            }
            else
            {
                return t_othertext.Text;
            }
        }

        //Clear text after saving
        private void cleartext()
        {
            t_idtext.Clear();
            t_nametext.Clear();
            t_emailtext.Clear();
            t_dobtext.Value = DateTime.Now;
            t_agetext.Clear();
            t_maletext.Checked = false;
            t_femaletext.Checked = false;
            t_othertext.Checked = false;
            t_addresstext.Clear();
            t_contactnotext.Clear();
            t_joineddatetext.Value = DateTime.Now;
            t_notestext.Clear();
        }

        //Fill Listbox
        private void fillListbox()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ajini Sahejana\source\repos\Gym-Management-System\Database\GMS.mdf;Integrated Security=True;Connect Timeout=30");
            string query = "SELECT * from Trainer";
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
                    //string fullname = reader.GetString(5);
                    lbTrainer.Items.Add(id + ": " + name);
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
                lbTrainer.Items.Clear();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            //con.Close();
        }

        //Search Staff
        private void searchtrainer(string values)
        {
            if (searchbyid.Checked == true)
            {
                lbTrainer.SelectedItems.Clear();

                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ajini Sahejana\source\repos\Gym-Management-System\Database\GMS.mdf;Integrated Security=True;Connect Timeout=30");
                string query = " SELECT * FROM Trainer WHERE t_id LIKE '%" + values + "%' ";
                con.Open();

                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader;

                try
                {
                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {

                        string id = reader.GetInt32(0).ToString();
                        string name = reader.GetString(1);
                        //string fullname = reader.GetString(5);
                        lbTrainer.Items.Add(id + ": " + name);
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
                lbTrainer.SelectedItems.Clear();

                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ajini Sahejana\source\repos\Gym-Management-System\Database\GMS.mdf;Integrated Security=True;Connect Timeout=30");
                string query = " SELECT * FROM Trainer WHERE t_name LIKE '%" + values + "%' ";
                con.Open();

                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader;

                try
                {
                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string id = reader.GetInt32(0).ToString();
                        string name = reader.GetString(1);
                        //string fullname = reader.GetString(5);
                        lbTrainer.Items.Add(id + ": " + name);
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

        private void t_save_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ajini Sahejana\source\repos\Gym-Management-System\Database\GMS.mdf;Integrated Security=True;Connect Timeout=30");
            string query = "SELECT * from Trainer";

            try
            {
                con.Open();
                //Fill Dataset
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                DataSet set = new DataSet();
                adapter.Fill(set, "Trainer");

                //Add new row to database
                DataRow row = set.Tables["Trainer"].NewRow();
                row["t_name"] = this.t_nametext.Text;
                row["t_email"] = this.t_emailtext.Text;
                row["t_dob"] = this.t_dobtext.Value;
                row["t_age"] = this.t_agetext.Text;
                row["t_gender"] = this.radiobuttoncheck();
                row["t_address"] = this.t_addresstext.Text;
                row["t_contactno"] = this.t_contactnotext.Text;
                row["t_joineddate"] = this.t_joineddatetext.Value;
                row["t_notes"] = this.t_notestext.Text;

                set.Tables["Trainer"].Rows.Add(row);

                //Updating Database Table
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                adapter.Update(set.Tables["Trainer"]);

                MessageBox.Show("Trainer Account Created Successfully!");
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

            t_searchtext.Clear();
        }


        private void t_update_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ajini Sahejana\source\repos\Gym-Management-System\Database\GMS.mdf;Integrated Security=True;Connect Timeout=30");
            string query = "UPDATE Trainer SET " +
                "t_name = '" + t_nametext.Text + "'," +
                "t_email = '" + t_emailtext.Text + "', " +
                "t_dob = '" + t_dobtext.Value + "', " +
                "t_age = '" + t_agetext.Text + "', " +
                "t_gender = '" + radiobuttoncheck() + "', " +
                "t_address = '" + t_addresstext.Text + "', " +
                "t_contactno = '" + t_contactnotext.Text + "', " +
                "t_joineddate = '" + t_joineddatetext.Value + "', " +
                "t_notes = '" + t_notestext.Text + "'" +
                "WHERE t_id = '" + t_idtext.Text + "' ";

            con.Open();

            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            adapter.SelectCommand.ExecuteNonQuery();

            MessageBox.Show("Trainer Account Updated Successfully!");

            con.Close();

            cleartext();

            clearListbox();

            fillListbox();

            viewsid();

            t_searchtext.Clear();
        }

        private void t_cancel_Click(object sender, EventArgs e)
        {
            cleartext();

            clearListbox();

            fillListbox();

            viewsid();

            t_searchtext.Clear();
        }

        private void t_delete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ajini Sahejana\source\repos\Gym-Management-System\Database\GMS.mdf;Integrated Security=True;Connect Timeout=30");
            string query = "DELETE FROM Trainer WHERE t_id =  '" + this.t_idtext.Text + "' ";

            con.Open();

            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            adapter.SelectCommand.ExecuteNonQuery();

            MessageBox.Show("Trainer Account Deleted Successfully!");

            con.Close();

            cleartext();

            clearListbox();

            fillListbox();

            t_searchtext.Clear();
        }

        private void lbTrainer_SelectedIndexChanged(object sender, EventArgs e)
        {
            string onlyid = lbTrainer.Text.Substring(0, 6);

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ajini Sahejana\source\repos\Gym-Management-System\Database\GMS.mdf;Integrated Security=True;Connect Timeout=30");
            string query = "SELECT * FROM Trainer WHERE t_id = '" + onlyid + "' ";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader;
            try
            {
                con.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    t_idtext.Text = reader.GetInt32(0).ToString().Trim();
                    t_nametext.Text = reader.GetString(1).Trim();
                    t_emailtext.Text = reader.GetString(2).Trim();
                    t_dobtext.Value = reader.GetDateTime(3);
                    t_agetext.Text = reader.GetString(4).Trim();

                    //Radio button check
                    if (reader.GetString(5).Trim() == "Male")
                    {
                        t_maletext.Checked = true;
                    }
                    else if (reader.GetString(5).Trim() == "Female")
                    {
                        t_femaletext.Checked = true;
                    }
                    else
                    {
                        t_othertext.Checked = true;
                    }

                    t_addresstext.Text = reader.GetString(6).Trim();
                    t_contactnotext.Text = reader.GetString(7).Trim();
                    t_joineddatetext.Value = reader.GetDateTime(8);
                    t_notestext.Text = reader.GetString(9).Trim();
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }

            con.Close();
        }

        private void t_searchtext_TextChanged(object sender, EventArgs e)
        {
            string values = t_searchtext.Text.ToString().ToLower();
            if (values == "")
            {
                clearListbox();
                fillListbox();
            }
            else
            {
                clearListbox();
                searchtrainer(values);
            }
        }
    }
}
