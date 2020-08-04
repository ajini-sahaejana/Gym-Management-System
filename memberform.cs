using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gym_Management_System
{
    public partial class memberform : Form
    {
        public memberform()
        {
            InitializeComponent();
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

        private void bodydata_Click(object sender, EventArgs e)
        {
            bodydataform bdf1 = new bodydataform();
        }
    }
}
