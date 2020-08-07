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
    public partial class purchaseform : Form
    {
        public purchaseform()
        {
            InitializeComponent();
            fillListbox();
            viewpid();
            fillmembercombobox();
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

        //View Purchase_id in the form
        private void viewpid()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ajini Sahejana\source\repos\Gym-Management-System\Database\GMS.mdf;Integrated Security=True;Connect Timeout=30");
                string query = "SELECT p_id FROM Purchase WHERE p_id = (SELECT MAX(p_id) FROM Purchase) ";
                SqlCommand cmd = new SqlCommand(query, con);

                SqlDataReader reader;

                con.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    id++;
                    p_idtext.Text = Convert.ToString(id);
                }

                con.Close();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        //View Membership_Name in the form
        private void fillmembercombobox()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ajini Sahejana\source\repos\Gym-Management-System\Database\GMS.mdf;Integrated Security=True;Connect Timeout=30");
                string query = "SELECT * from Member";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                SqlDataReader reader;

                con.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string id = reader.GetInt32(0).ToString().Trim();
                    string name = reader.GetString(1).Trim();
                    m_namecombo.Items.Add(id + ": " + name);
                }

                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        //Clear Combobpx
        private void clearCombobox()
        {
            try
            {
                m_namecombo.Items.Clear();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            };
        }

        //Clear text after saving
        private void cleartext()
        {
            p_idtext.Clear();
            m_namecombo.Text = "";
            m_details.Clear();
            ms_type.Clear();
            ms_fee.Clear();
            p_discounttext.Clear();
            p_datetext.Value = DateTime.Now;
            p_discounttext.Clear();
            p_discountamounttext.Text = "";
            p_amount.Clear();
            p_notes.Clear();
        }

        //Fill Listbox
        private void fillListbox()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ajini Sahejana\source\repos\Gym-Management-System\Database\GMS.mdf;Integrated Security=True;Connect Timeout=30");
                string query = "SELECT * from Purchase";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader;

                con.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string id = reader.GetInt32(0).ToString();
                    string name = reader.GetString(1).Substring(8);

                    lbPurchase.Items.Add(id + ": " + name);
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
                lbPurchase.Items.Clear();
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
                    lbPurchase.SelectedItems.Clear();

                    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ajini Sahejana\source\repos\Gym-Management-System\Database\GMS.mdf;Integrated Security=True;Connect Timeout=30");
                    string query = " SELECT * FROM Purchase WHERE p_id LIKE '%" + values + "%' ";
                    con.Open();

                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader reader;

                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {

                        string id = reader.GetInt32(0).ToString();
                        string name = reader.GetString(1).Substring(8);

                        lbPurchase.Items.Add(id + ": " + name);
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
                    lbPurchase.SelectedItems.Clear();

                    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ajini Sahejana\source\repos\Gym-Management-System\Database\GMS.mdf;Integrated Security=True;Connect Timeout=30");
                    string query = " SELECT * FROM Purchase WHERE m_combo LIKE '%" + values + "%' ";
                    con.Open();

                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader reader;

                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string id = reader.GetInt32(0).ToString();
                        string name = reader.GetString(1).Substring(8);

                        lbPurchase.Items.Add(id + ": " + name);
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

        private void p_save_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ajini Sahejana\source\repos\Gym-Management-System\Database\GMS.mdf;Integrated Security=True;Connect Timeout=30");
                string query = "SELECT * from Purchase";

                con.Open();
                //Fill Dataset
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                DataSet set = new DataSet();
                adapter.Fill(set, "Purchase");

                //Add new row to database
                DataRow row = set.Tables["Purchase"].NewRow();
                row["m_combo"] = this.m_namecombo.Text;
                row["m_details"] = this.m_details.Text;
                row["ms_type"] = this.ms_type.Text;
                row["ms_fee"] = this.ms_fee.Text;
                row["p_date"] = this.p_datetext.Value;
                row["p_discount"] = this.p_discounttext.Text;
                row["p_discountamount"] = this.p_discountamounttext.Text;
                row["p_amount"] = this.p_amount.Text;
                row["p_notes"] = this.p_notes.Text;

                set.Tables["Purchase"].Rows.Add(row);

                //Updating Database Table
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                adapter.Update(set.Tables["Purchase"]);

                MessageBox.Show("Purchased Successfully!");

                con.Close();

                cleartext();

                clearListbox();

                fillListbox();

                viewpid();

                p_searchtext.Clear();
            }
            catch (Exception e1)
            {
                Console.WriteLine(e1);
            }
        }

        private void p_update_Click(object sender, EventArgs e)
        {
            try
            {
                string onlyname = m_namecombo.Text.Substring(8);

                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ajini Sahejana\source\repos\Gym-Management-System\Database\GMS.mdf;Integrated Security=True;Connect Timeout=30");
                string query = "UPDATE Purchase SET " +
                    "m_combo = '" + this.m_namecombo.Text + "'," +
                    "m_details = '" + this.m_details.Text + "'," +
                    "ms_type = '" + this.ms_type.Text + "', " +
                    "ms_fee = '" + this.ms_fee.Text + "', " +
                    "p_date = '" + this.p_datetext.Value + "', " +
                    "p_discount = '" + this.p_discounttext.Text + "', " +
                    "p_discountamount = '" + this.p_discountamounttext.Text + "', " +
                    "p_amount = '" + this.p_amount.Text + "', " +
                    "p_notes = '" + this.p_notes.Text + "' " +
                    "WHERE p_id = '" + this.p_idtext.Text + "' ";

                con.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                adapter.SelectCommand.ExecuteNonQuery();

                MessageBox.Show("Purchase Updated Successfully!");

                con.Close();

                cleartext();

                clearListbox();

                fillListbox();

                viewpid();

                p_searchtext.Clear();

            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
                Console.WriteLine(e1);
            }
        }

        private void p_cancel_Click(object sender, EventArgs e)
        {
            cleartext();

            clearListbox();

            fillListbox();

            viewpid();

            p_searchtext.Clear();
        }

        private void p_delete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ajini Sahejana\source\repos\Gym-Management-System\Database\GMS.mdf;Integrated Security=True;Connect Timeout=30");
            string query = "DELETE FROM Purchase WHERE p_id =  '" + this.p_idtext.Text + "' ";

            con.Open();

            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            adapter.SelectCommand.ExecuteNonQuery();

            MessageBox.Show("Purchase Deleted Successfully!");

            con.Close();

            cleartext();

            clearListbox();

            fillListbox();

            p_searchtext.Clear();
        }

        private void lbPurchase_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string onlyid = lbPurchase.Text.Substring(0, 6);

                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ajini Sahejana\source\repos\Gym-Management-System\Database\GMS.mdf;Integrated Security=True;Connect Timeout=30");
                string query = "SELECT * FROM Purchase WHERE p_id = '" + onlyid + "' ";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader;

                con.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    p_idtext.Text = reader.GetInt32(0).ToString().Trim();
                    m_namecombo.Text = reader.GetString(1).Trim();
                    m_details.Text = reader.GetString(2).Trim();
                    ms_type.Text = reader.GetString(3).Trim();
                    ms_fee.Text = reader.GetString(4).Trim();
                    p_datetext.Value = reader.GetDateTime(5);
                    p_discounttext.Text = reader.GetString(6).Trim();
                    p_discountamounttext.Text = reader.GetString(7).Trim();
                    p_amount.Text = reader.GetString(8).Trim();
                    p_notes.Text = reader.GetString(9).Trim();
                }

                con.Close();
            }
            catch (Exception)
            {
                //MessageBox.Show(e1.Message);
            }
        }

        private void p_searchtext_TextChanged(object sender, EventArgs e)
        {
            string values = p_searchtext.Text.ToString().ToLower();
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

        private void m_namecombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string onlyid = m_namecombo.Text.Substring(0, 6);

                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ajini Sahejana\source\repos\Gym-Management-System\Database\GMS.mdf;Integrated Security=True;Connect Timeout=30");
                string query = "SELECT * from Member WHERE m_id = '" + onlyid + "' ";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                SqlDataReader reader;

                con.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    m_details.Text =
                        reader.GetString(2).Trim() + "\r\n" +
                        reader.GetString(6).Trim() + "\r\n" +
                        reader.GetString(7).Trim();
                    ms_type.Text = reader.GetString(10).Substring(8);
                }
            }
            catch (Exception e2)
            {
                MessageBox.Show(e2.Message);
            }
        }
    }
}
