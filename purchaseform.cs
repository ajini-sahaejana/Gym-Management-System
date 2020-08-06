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

        private void m_namecombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
