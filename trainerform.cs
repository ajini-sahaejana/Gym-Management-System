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
        }

        private void goback_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Any unsaved changed wont't be saved. Are you sure?", "Go Back to Homepage", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                this.Hide();
                mainform m1 = new mainform();
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
    }
}
