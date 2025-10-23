using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace F_unny
{
    public partial class Form8 : Form
    {
        int nr_carrot, sec;
        bool death;
        public Form8()
        {
            InitializeComponent();
            newGame();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
       

        private void label5_Click(object sender, EventArgs e)
        {
            this.Close();
            Form10 form10 = new Form10();
            form10.Show();
        }

        private void newGame()
        {
            label2.Location = new Point(650, 600);
            label6.Location = new Point(279, 170);
            bunny.Location = new Point(67, 680);

            death = false;
            nr_carrot = 0;
            Random random = new Random();
            sec = random.Next(230, 330);
            label1.Text = "🥕:" + nr_carrot;
            label3.Text = "⏱: " + sec;
        }

        private void key_down(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                bunny.Top += 10;
            }
            if (e.KeyCode == Keys.Up)
            {
                bunny.Top += -10;
            }
            if (e.KeyCode == Keys.Left)
            {
                bunny.Left += -15;
            }
            if (e.KeyCode == Keys.Right)
            {
                bunny.Left += 15;
            }
            foreach (Control x in this.Controls)
                if (x is PictureBox && x.Tag != null && x.Tag.ToString() == "wall")
                    if (bunny.Bounds.IntersectsWith(x.Bounds))
                        if (e.KeyCode == Keys.Up)
                            bunny.Top += 10;
                        else if (e.KeyCode == Keys.Down)
                            bunny.Top += -10;
                        else if (e.KeyCode == Keys.Left)
                            bunny.Left += 15;
                        else if (e.KeyCode == Keys.Right)
                            bunny.Left += -15;
            foreach (Control x in this.Controls)
                if (x is PictureBox && x.Tag != null && x.Tag.ToString() == "carrot")
                    if (bunny.Bounds.IntersectsWith(x.Bounds))
                    {
                        if (x.Visible == true)
                            nr_carrot++;
                        x.Visible = false;
                        label1.Text = "🥕:" + nr_carrot;
                        //put another carrot
                        Random random = new Random();
                        int k = random.Next(600, 800);
                        x.Location = new Point(1800, k);
                        x.Visible = true;
                    }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void Game_over()
        {
            death = true;
            Timer.Stop();
            this.Close();
            Form10 form10 = new Form10();
            form10.Show();

        }

        

        private void Timer_Tick_1(object sender, EventArgs e)
        {
            sec -= 1;
            label3.Text = "⏱: " + sec;
            int speed = 15;
            fox1.Left += -speed;
            fox2.Left += -speed;
            fox3.Left += -speed;

            foreach (Control x in this.Controls)
                if (x is PictureBox && x.Tag != null && x.Tag.ToString() == "carrot")
                {
                    x.Left += -8;
                    if (wall.Bounds.IntersectsWith(x.Bounds))
                    {
                        Random random = new Random();
                        int k = random.Next(600, 800);
                        x.Location = new Point(1800, k);
                    }
                }

            foreach (Control x in this.Controls)
                if (x is PictureBox && x.Tag != null && x.Tag.ToString() == "enemy")
                    if (bunny.Bounds.IntersectsWith(x.Bounds))
                    {
                        Game_over();
                    }
            foreach (Control x in this.Controls)
                if (x is PictureBox && x.Tag != null && x.Tag.ToString() == "enemy")
                    if (wall.Bounds.IntersectsWith(x.Bounds))
                        {
                            Random random = new Random();
                            int k = random.Next(600, 700);
                            x.Location = new Point(1600, k);
                         }
           if(sec==0)
            {
                Timer.Stop();
                label4.Location = new Point(259, 453);
                label4.Text = "You've got " + nr_carrot + " 🥕";
                label4.Visible = true;
                if(nr_carrot<10)
                    Game_over();

            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click_1(object sender, EventArgs e)
        {
            
          
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            this.Close();
               Form9 form9= new Form9();
               form9.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form8_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            label6.Visible = false;
            label2.Visible = false;
            Timer.Start();
        }
    }
}
