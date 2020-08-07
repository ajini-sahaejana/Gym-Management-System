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
    public partial class memberform : Form
    {
        public memberform()
        {
            InitializeComponent();
            fillListbox();
            viewmid();
            fillmembershipcombobox();
            fillsessioncombobox();
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

        //View Member_id in the form
        private void viewmid()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ajini Sahejana\source\repos\Gym-Management-System\Database\GMS.mdf;Integrated Security=True;Connect Timeout=30");
                string query = "SELECT m_id FROM Member WHERE m_id = (SELECT MAX(m_id) FROM Member) ";
                SqlCommand cmd = new SqlCommand(query, con);

                SqlDataReader reader;

                con.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    id++;
                    m_idtext.Text = Convert.ToString(id);
                }

                con.Close();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        //View Membership_Name in the form
        private void fillmembershipcombobox()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ajini Sahejana\source\repos\Gym-Management-System\Database\GMS.mdf;Integrated Security=True;Connect Timeout=30");
                string query = "SELECT * from Membership";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                SqlDataReader reader;

                con.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string id = reader.GetInt32(0).ToString().Trim();
                    string name = reader.GetString(1).Trim();
                    mb_typecombo.Items.Add(id + ": " + name);
                }

                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        //View Membership_Name in the form
        private void fillsessioncombobox()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ajini Sahejana\source\repos\Gym-Management-System\Database\GMS.mdf;Integrated Security=True;Connect Timeout=30");
                string query = "SELECT * from Session";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                SqlDataReader reader;

                con.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string id = reader.GetInt32(0).ToString().Trim();
                    string name = reader.GetString(2).Trim();
                    t_sessioncombo.Items.Add(id + ": " + name);
                }

                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        //Radio Button Selection
        private string radiobuttoncheck()
        {
            if (m_maletext.Checked)
            {
                return m_maletext.Text;
            }
            else if (m_femaletext.Checked)
            {
                return m_femaletext.Text;
            }
            else
            {
                return m_othertext.Text;
            }
        }

        //Clear text after saving
        private void cleartext()
        {
            m_idtext.Clear();
            m_nametext.Clear();
            m_emailtext.Clear();
            m_dobtext.Value = DateTime.Now;
            m_agetext.Clear();
            m_maletext.Checked = false;
            m_femaletext.Checked = false;
            m_othertext.Checked = false;
            m_addresstext.Clear();
            m_contactnotext.Clear();
            m_joineddatetext.Value = DateTime.Now;
            m_notestext.Clear();
            mb_typecombo.Text = "";
            mb_details.Clear();
            t_sessioncombo.Text = "";
            t_details.Clear();
        }

        //Fill Listbox
        private void fillListbox()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ajini Sahejana\source\repos\Gym-Management-System\Database\GMS.mdf;Integrated Security=True;Connect Timeout=30");
                string query = "SELECT * from Member";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader;

                con.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string id = reader.GetInt32(0).ToString();
                    string name = reader.GetString(1);
                    
                    lbMember.Items.Add(id + ": " + name);
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
                lbMember.Items.Clear();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        //Search Member
        private void searchmember(string values)
        {
            if (searchbyid.Checked == true)
            {
                try
                {
                    lbMember.SelectedItems.Clear();

                    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ajini Sahejana\source\repos\Gym-Management-System\Database\GMS.mdf;Integrated Security=True;Connect Timeout=30");
                    string query = " SELECT * FROM Member WHERE m_id LIKE '%" + values + "%' ";
                    con.Open();

                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader reader;

                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {

                        string id = reader.GetInt32(0).ToString();
                        string name = reader.GetString(1);
                        
                        lbMember.Items.Add(id + ": " + name);
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
                    lbMember.SelectedItems.Clear();

                    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ajini Sahejana\source\repos\Gym-Management-System\Database\GMS.mdf;Integrated Security=True;Connect Timeout=30");
                    string query = " SELECT * FROM Member WHERE m_name LIKE '%" + values + "%' ";
                    con.Open();

                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader reader;

                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string id = reader.GetInt32(0).ToString();
                        string name = reader.GetString(1);
                        
                        lbMember.Items.Add(id + ": " + name);
                    }

                    con.Close();
                }
                catch (Exception e2)
                {
                    MessageBox.Show(e2.Message);
                }
            }
        }


        //---------------------------------------------SQL---------------------------------------------------

        private void m_save_Click(object sender, EventArgs e)
        {
            try
            {
                string namecombo = mb_typecombo.Text;
                string stname = t_sessioncombo.Text;

                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ajini Sahejana\source\repos\Gym-Management-System\Database\GMS.mdf;Integrated Security=True;Connect Timeout=30");
                string query = "SELECT * from Member";

                con.Open();
                //Fill Dataset
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                DataSet set = new DataSet();
                adapter.Fill(set, "Member");

                //Add new row to database
                DataRow row = set.Tables["Member"].NewRow();
                row["m_name"] = this.m_nametext.Text;
                row["m_email"] = this.m_emailtext.Text;
                row["m_dob"] = this.m_dobtext.Value;
                row["m_age"] = this.m_agetext.Text;
                row["m_gender"] = this.radiobuttoncheck();
                row["m_address"] = this.m_addresstext.Text;
                row["m_contactno"] = this.m_contactnotext.Text;
                row["m_joineddate"] = this.m_joineddatetext.Value;
                row["m_notes"] = this.m_notestext.Text;
                row["mb_typecombo"] = namecombo.Trim();
                row["mb_details"] = this.mb_details.Text.Trim();
                row["t_sessioncombo"] = stname.Trim();
                row["t_details"] = this.t_details.Text.Trim();

                set.Tables["Member"].Rows.Add(row);

                //Updating Database Table
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                adapter.Update(set.Tables["Member"]);

                MessageBox.Show("Member Account Created Successfully!");

                con.Close();

                cleartext();

                clearListbox();

                fillListbox();

                viewmid();

                m_searchtext.Clear();
            }
            catch (Exception e1)
            {
                //MessageBox.Show(e1.Message);
                Console.WriteLine(e1);
            }
        }


        private void m_update_Click(object sender, EventArgs e)
        {
            try
            {
                string onlyname = mb_typecombo.Text;
                string stname = t_sessioncombo.Text;

                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ajini Sahejana\source\repos\Gym-Management-System\Database\GMS.mdf;Integrated Security=True;Connect Timeout=30");
                string query = "UPDATE Member SET " +
                    "m_name = '" + this.m_nametext.Text + "'," +
                    "m_email = '" + this.m_emailtext.Text + "', " +
                    "m_dob = '" + this.m_dobtext.Value + "', " +
                    "m_age = '" + this.m_agetext.Text + "', " +
                    "m_gender = '" + this.radiobuttoncheck() + "', " +
                    "m_address = '" + this.m_addresstext.Text + "', " +
                    "m_contactno = '" + this.m_contactnotext.Text + "', " +
                    "m_joineddate = '" + this.m_joineddatetext.Value + "', " +
                    "m_notes = '" + this.m_notestext.Text + "'," +
                    "mb_typecombo = '" + onlyname.Trim() + "'," +
                    "mb_details = '" + mb_details.Text + "'," +
                    "t_sessioncombo = '" + stname.Trim() + "'," +
                    "t_details = '" + t_details.Text + "'" +
                    "WHERE m_id = '" + this.m_idtext.Text + "' ";

                con.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                adapter.SelectCommand.ExecuteNonQuery();

                MessageBox.Show("Member Account Updated Successfully!");

                con.Close();

                cleartext();

                clearListbox();

                fillListbox();

                viewmid();

                m_searchtext.Clear();

            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
                Console.WriteLine(e1);
            }
        }

        private void m_cancel_Click(object sender, EventArgs e)
        {
            cleartext();

            clearListbox();

            fillListbox();

            viewmid();

            m_searchtext.Clear();
        }

        private void m_delete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ajini Sahejana\source\repos\Gym-Management-System\Database\GMS.mdf;Integrated Security=True;Connect Timeout=30");
            string query = "DELETE FROM Member WHERE m_id =  '" + this.m_idtext.Text + "' ";

            con.Open();

            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            adapter.SelectCommand.ExecuteNonQuery();

            MessageBox.Show("Member Account Deleted Successfully!");

            con.Close();

            cleartext();

            clearListbox();

            fillListbox();

            m_searchtext.Clear();
        }

        private void lbMember_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string onlyid = lbMember.Text.Substring(0, 6);

                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ajini Sahejana\source\repos\Gym-Management-System\Database\GMS.mdf;Integrated Security=True;Connect Timeout=30");
                string query = "SELECT * FROM Member WHERE m_id = '" + onlyid + "' ";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader;

                con.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    m_idtext.Text = reader.GetInt32(0).ToString().Trim();
                    m_nametext.Text = reader.GetString(1).Trim();
                    m_emailtext.Text = reader.GetString(2).Trim();
                    m_dobtext.Value = reader.GetDateTime(3);
                    m_agetext.Text = reader.GetString(4).Trim();

                    //Radio button check
                    if (reader.GetString(5).Trim() == "Male")
                    {
                        m_maletext.Checked = true;
                    }
                    else if (reader.GetString(5).Trim() == "Female")
                    {
                        m_femaletext.Checked = true;
                    }
                    else
                    {
                        m_othertext.Checked = true;
                    }

                    m_addresstext.Text = reader.GetString(6).Trim();
                    m_contactnotext.Text = reader.GetString(7).Trim();
                    m_joineddatetext.Value = reader.GetDateTime(8);
                    m_notestext.Text = reader.GetString(9).Trim();

                    mb_typecombo.Text = reader.GetString(10).Trim();
                    mb_details.Text = reader.GetString(11);
                    t_sessioncombo.Text = reader.GetString(12).Trim();
                    t_details.Text = reader.GetString(13);
                }

                con.Close();
            }
            catch (Exception)
            {
                //MessageBox.Show(e1.Message);
            }
        }

        private void m_searchtext_TextChanged(object sender, EventArgs e)
        {
            string values = m_searchtext.Text.ToString().ToLower();
            if (values == "")
            {
                clearListbox();
                fillListbox();
            }
            else
            {
                clearListbox();
                searchmember(values);
            }
        }

        private void mb_typecombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string onlyid = mb_typecombo.Text.Substring(0, 6);

                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ajini Sahejana\source\repos\Gym-Management-System\Database\GMS.mdf;Integrated Security=True;Connect Timeout=30");
                string query = "SELECT * from Membership WHERE ms_id = '" + onlyid + "' ";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                SqlDataReader reader;

                con.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    mb_details.Text =
                        reader.GetString(2).Trim() + "\r\n" +
                        reader.GetString(3).Trim() + "\r\n" +
                        reader.GetString(4).Trim();
                }

                con.Close();
            }
            catch (Exception e2)
            {
                MessageBox.Show(e2.Message);
            }
        }


        private void t_sessioncombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string onlyid = t_sessioncombo.Text.Substring(0, 6);

                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ajini Sahejana\source\repos\Gym-Management-System\Database\GMS.mdf;Integrated Security=True;Connect Timeout=30");
                string query = "SELECT * from Session WHERE ts_id = '" + onlyid + "' ";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                SqlDataReader reader;

                con.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    t_details.Text =
                        reader.GetString(1).Trim() + "\r\n" +
                        reader.GetDateTime(3).ToShortDateString() + "\r\n" +
                        reader.GetString(4).Trim() + "\r\n" +
                        reader.GetString(5).Trim();
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
