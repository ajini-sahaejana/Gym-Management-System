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
    public partial class staffregform : Form
    {
        public staffregform()
        {
            InitializeComponent();
        }

        private void s_showpword_MouseDown(object sender, MouseEventArgs e)
        {
            s_pwordtext.UseSystemPasswordChar = false;
            s_showpword.BackgroundImage = Properties.Resources.eyeopen;
        }

        private void s_showpword_MouseUp(object sender, MouseEventArgs e)
        {
            s_pwordtext.UseSystemPasswordChar = true;
            s_showpword.BackgroundImage = Properties.Resources.eyeclose;
        }

        private void s_showconpword_MouseDown(object sender, MouseEventArgs e)
        {
            s_conpwordtext.UseSystemPasswordChar = false;
            s_showconpword.BackgroundImage = Properties.Resources.eyeopen;
        }

        private void s_showconpword_MouseUp(object sender, MouseEventArgs e)
        {
            s_conpwordtext.UseSystemPasswordChar = true;
            s_showconpword.BackgroundImage = Properties.Resources.eyeclose;
        }
    }
}
