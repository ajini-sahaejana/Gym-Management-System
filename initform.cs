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

        private signinform s1 = new signinform();

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel1.Width += 2;
            if (panel1.Width>=300)
            {
                timerLoad.Stop();
                panel1.BackColor = Color.DarkTurquoise;
                timerSlide1.Start();
            }
            
        }

        private void timerSlide1_Tick(object sender, EventArgs e)
        {
            s1.Left += 10;
            if (s1.Left > 680)
            {
                timerSlide1.Stop();
            }
            this.Left -= 10;
            if (this.Left > 680)
            {
                timerSlide1.Stop();
            }

        }

        private void initform_Load(object sender, EventArgs e)
        {
            s1.Show();
        }
    }
}
