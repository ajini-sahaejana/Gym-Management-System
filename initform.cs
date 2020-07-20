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
    public partial class initform : Form
    {
        public initform()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel1.Width += 2;
            if (panel1.Width>=300)
            {
                timer1.Stop();
                panel1.Hide();
            }
            
        }
    }
}
