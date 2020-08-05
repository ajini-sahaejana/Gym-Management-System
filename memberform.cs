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
            this.MinimumSize = new System.Drawing.Size(1366, 768);
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
    }
}
