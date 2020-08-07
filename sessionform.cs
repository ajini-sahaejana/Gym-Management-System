﻿using System;
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
    public partial class sessionform : Form
    {
        public sessionform()
        {
            InitializeComponent();
            viewsid();
            fillListbox();
            fillcombobox();
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

        //View Session_Id in the form
        private void viewsid()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ajini Sahejana\source\repos\Gym-Management-System\Database\GMS.mdf;Integrated Security=True;Connect Timeout=30");
                string query = "SELECT ts_id FROM Session WHERE ts_id = (SELECT MAX(ts_id) FROM Session) ";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                SqlDataReader reader;
            
                con.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    id++;
                    ts_idtext.Text = Convert.ToString(id);
                }

                con.Close();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        //View Trainer_Name in the form
        private void fillcombobox()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ajini Sahejana\source\repos\Gym-Management-System\Database\GMS.mdf;Integrated Security=True;Connect Timeout=30");
                string query = "SELECT * from Trainer";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                SqlDataReader reader;

                con.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string id = reader.GetInt32(0).ToString().Trim();
                    string name = reader.GetString(1).Trim();
                    t_namecombo.Items.Add(id + ": " + name);
                }

                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        //Clear text after saving
        private void cleartext()
        {
            t_namecombo.Text = "";
            ts_idtext.Clear();
            ts_nametext.Clear();
            ts_datetext.Value = DateTime.Now;
            ts_notestext.Clear();
            t_details.Clear();
        }

        //Fill Listbox
        private void fillListbox()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ajini Sahejana\source\repos\Gym-Management-System\Database\GMS.mdf;Integrated Security=True;Connect Timeout=30");
            string query = "SELECT * from Session";
            SqlCommand cmd = new SqlCommand(query, con);
            //SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            SqlDataReader reader;
            try
            {
                con.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string id = reader.GetInt32(0).ToString().Trim();
                    string name = reader.GetString(1).Substring(8).Trim();
                    //string date = reader.GetDateTime(2).ToString();
                    lbSession.Items.Add(id + ": " + name);
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
                lbSession.Items.Clear();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            //con.Close();
        }

        //Clear Combobpx
        private void clearCombobox()
        {
            try
            {
                t_namecombo.Items.Clear();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            };
        }

        //Search Staff
        private void searchsession(string values)
        {
            if (searchbyid.Checked == true)
            {
                try {
                    lbSession.SelectedItems.Clear();

                    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ajini Sahejana\source\repos\Gym-Management-System\Database\GMS.mdf;Integrated Security=True;Connect Timeout=30");
                    string query = " SELECT * FROM Session WHERE ts_id LIKE '%" + values + "%' ";
                    con.Open();

                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader reader;

                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string id = reader.GetInt32(0).ToString();
                        string name = reader.GetString(1).Substring(8);
                        //string date = reader.GetDateTime(2).ToString();
                        lbSession.Items.Add(id + ": " + name);
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
                    lbSession.SelectedItems.Clear();

                    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ajini Sahejana\source\repos\Gym-Management-System\Database\GMS.mdf;Integrated Security=True;Connect Timeout=30");
                    string query = " SELECT * FROM Session WHERE trainer_name LIKE '%" + values + "%' ";
                    con.Open();

                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader reader;

                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string id = reader.GetInt32(0).ToString();
                        string name = reader.GetString(1).Substring(8);
                        //string date = reader.GetDateTime(2).ToString();
                        lbSession.Items.Add(id + ": " + name);
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

        private void ts_save_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ajini Sahejana\source\repos\Gym-Management-System\Database\GMS.mdf;Integrated Security=True;Connect Timeout=30");
                string query = "SELECT * from Session";

                con.Open();
                //Fill Dataset
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                DataSet set = new DataSet();
                adapter.Fill(set, "Session");

                //Add new row to database
                DataRow row = set.Tables["Session"].NewRow();
                row["trainer_name"] = this.t_namecombo.Text.Trim();
                row["ts_name"] = this.ts_nametext.Text.Trim();
                row["ts_date"] = this.ts_datetext.Value;
                row["ts_notes"] = this.ts_notestext.Text.Trim();
                row["trainer_details"] = this.t_details.Text.Trim();

                set.Tables["Session"].Rows.Add(row);

                //Updating Database Table
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                adapter.Update(set.Tables["Session"]);

                MessageBox.Show("Training Session Created Successfully!");

                con.Close();

                cleartext();

                clearListbox();

                fillListbox();

                clearCombobox();

                fillcombobox();

                viewsid();

                ts_searchtext.Clear();
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

        private void ts_update_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ajini Sahejana\source\repos\Gym-Management-System\Database\GMS.mdf;Integrated Security=True;Connect Timeout=30");
                string query = "UPDATE Session SET " +
                    "trainer_name = '" + this.t_namecombo.Text.Trim() + "'," +
                    "ts_name = '" + ts_nametext.Text.Trim() + "'," +
                    "ts_date = '" + ts_datetext.Value + "'," +
                    "ts_notes = '" + ts_notestext.Text.Trim() + "'," +
                    "trainer_details = '" + t_details.Text.Trim() + "'" +
                    "WHERE ts_id = '" + ts_idtext.Text.Trim() + "' ";

                con.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                adapter.SelectCommand.ExecuteNonQuery();

                MessageBox.Show("Training Session Updated Successfully!");

                con.Close();

                cleartext();

                clearListbox();

                fillListbox();

                clearCombobox();

                fillcombobox();

                viewsid();

                ts_searchtext.Clear();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void ts_cancel_Click(object sender, EventArgs e)
        {
            cleartext();

            clearListbox();

            fillListbox();

            clearCombobox();

            fillcombobox();

            viewsid();

            ts_searchtext.Clear();
        }

        private void ts_delete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ajini Sahejana\source\repos\Gym-Management-System\Database\GMS.mdf;Integrated Security=True;Connect Timeout=30");
            string query = "DELETE FROM Session WHERE ts_id =  '" + this.ts_idtext.Text + "' ";

            con.Open();

            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            adapter.SelectCommand.ExecuteNonQuery();

            MessageBox.Show("Training Session Deleted Successfully!");

            con.Close();

            cleartext();

            clearListbox();

            fillListbox();

            clearCombobox();

            fillcombobox();

            ts_searchtext.Clear();
        }

        private void lbSession_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string onlyid = lbSession.Text.Substring(0, 6);

                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ajini Sahejana\source\repos\Gym-Management-System\Database\GMS.mdf;Integrated Security=True;Connect Timeout=30");
                string query = "SELECT * FROM Session WHERE ts_id = '" + onlyid + "' ";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader;

                con.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ts_idtext.Text = reader.GetInt32(0).ToString().Trim();
                    t_namecombo.Text = reader.GetString(1).Trim();
                    ts_nametext.Text = reader.GetString(2).Trim();
                    ts_datetext.Value = reader.GetDateTime(3);
                    ts_notestext.Text = reader.GetString(4).Trim();
                    t_details.Text = reader.GetString(5).Trim();
                }

                con.Close();
            }
            catch (Exception)
            {
                //MessageBox.Show("Please Select A Record");
            }
        }

        private void ts_searchtext_TextChanged(object sender, EventArgs e)
        {
            string values = ts_searchtext.Text.ToString().ToLower();
            if (values == "")
            {
                clearListbox();
                fillListbox();
            }
            else
            {
                clearListbox();
                searchsession(values);
            }
        }

        private void t_namecombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string onlyid = t_namecombo.Text.Substring(0, 6);

                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ajini Sahejana\source\repos\Gym-Management-System\Database\GMS.mdf;Integrated Security=True;Connect Timeout=30");
                string query = "SELECT * from Trainer WHERE t_id = '" + onlyid + "' ";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                SqlDataReader reader;

                con.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    t_details.Text =
                        reader.GetString(2).Trim() + "\r\n" +
                        reader.GetDateTime(3).ToShortDateString() + "\r\n" +
                        reader.GetString(4).Trim() + "\r\n" +
                        reader.GetString(5).Trim() + "\r\n" +
                        reader.GetString(6).Trim() + "\r\n" +
                        reader.GetString(7).Trim() + "\r\n" +
                        reader.GetString(9).Trim();
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
