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

        private void bodydata_Click_1(object sender, EventArgs e)
        {
            bodydataform bdf1 = new bodydataform();
            bdf1.Show();
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
                row["m_hireddate"] = this.m_joineddatetext.Value;
                row["m_notes"] = this.m_notestext.Text;

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
                MessageBox.Show(e1.Message);
            }
        }


        private void m_update_Click(object sender, EventArgs e)
        {

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
    }
}
