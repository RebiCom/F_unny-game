using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace F_unny
{
    public partial class Form3 : Form 
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox36_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            

        }

        private void label3_Click(object sender, EventArgs e)
        {            
                if (bunny.Bounds.IntersectsWith(portal.Bounds))
            {
                this.Close();
                Form4 form4 = new Form4();
                form4.Show();
            }    
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = true;
            label4.Visible = false;
            portal.Visible = true;
            bunny.Width = 23;
            bunny.Height = 25;
            bunny.Location = new Point(507, 673);
        }

        private void keyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up )
                bunny.Top += -5;
            if (e.KeyCode == Keys.Down)
                bunny.Top +=  5;
            if (e.KeyCode == Keys.Left)
                bunny.Left += -5;
            if (e.KeyCode == Keys.Right)
                bunny.Left += 5;
            foreach (Control x in this.Controls)
                   if (x is PictureBox && x.Tag != null && x.Tag.ToString() == "wall")
                       if (bunny.Bounds.IntersectsWith(x.Bounds))
                            if (e.KeyCode == Keys.Up)
                               bunny.Top += 5;
                            else if (e.KeyCode == Keys.Down)
                               bunny.Top += -5;
                            else if (e.KeyCode == Keys.Left)
                               bunny.Left += +5;
                            else if (e.KeyCode == Keys.Right)
                               bunny.Left += -5;
            if (bunny.Bounds.IntersectsWith(portal.Bounds))
            {
                label3.ForeColor = Color.PeachPuff;
                label3.BackColor = Color.MidnightBlue;
                bunny.Visible = false;
            }
        }

        
    }
    
           
}
