using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace F_unny
{
    public partial class Form5 : Form
    {
        int nr_carrot=0, speed_w1=-8, speed_w2=8, speed_w3=8; bool Game_over;
        public Form5()
        {
            InitializeComponent();
            newGame();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if(nr_carrot==11)
            {
                this.Close();
                Form6 form = new Form6();
                form.Show();
            }
            wolf1.Left += speed_w1;
            if (wolf1.Bounds.IntersectsWith(pictureBox5.Bounds) || wolf1.Bounds.IntersectsWith(pictureBox8.Bounds))
            {
                if (wolf1.Tag.ToString() == "right")
                {
                    wolf1.Image = Properties.Resources.w_left;
                    wolf1.Tag = "left";
                }
                   
                else if (wolf1.Tag.ToString() == "left")
                {
                    wolf1.Image = Properties.Resources.w_right;
                    wolf1.Tag = "right";
                }
                    
                speed_w1 =-speed_w1;
            }
            wolf2.Left += speed_w2;
            if (wolf2.Bounds.IntersectsWith(pictureBox6.Bounds) || wolf2.Bounds.IntersectsWith(pictureBox7.Bounds))
            {
                if (wolf2.Tag.ToString() == "right")
                {
                    wolf2.Image = Properties.Resources.w_left;
                    wolf2.Tag = "left";
                }
                    
                else if (wolf2.Tag.ToString() == "left")
                {
                    wolf2.Image = Properties.Resources.w_right;
                    wolf2.Tag = "right";
                }
                    
                speed_w2 = -speed_w2;                
            }
            wolf3.Left += speed_w3;
            if (wolf3.Bounds.IntersectsWith(pictureBox7.Bounds) || wolf3.Bounds.IntersectsWith(pictureBox9.Bounds))
            {
                if (wolf3.Tag.ToString() == "right")
                {
                    wolf3.Image = Properties.Resources.w_left;
                    wolf3.Tag = "left";
                }
                    
                else if (wolf3.Tag.ToString() == "left")
                {
                    wolf3.Image = Properties.Resources.w_right;
                    wolf3.Tag = "right";
                }
                    
                speed_w3 = -speed_w3;               
            }
        }

        
        private void label4_Click(object sender, EventArgs e)
        {
            newGame();
        }

        private void wolf2_Click(object sender, EventArgs e)
        {

        }

        private void Form5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                fox.Left += -11;
                fox.Image= Properties.Resources.fox_left;
                fox.Width = 150;
                fox.Height = 85;
            }

            if (e.KeyCode == Keys.Right)
            {
                fox.Left += 11;
                fox.Image = Properties.Resources.fox_right;
                fox.Width = 150;
                fox.Height = 85;
            }

            if (e.KeyCode == Keys.Up)
            {
                fox.Top += -11;
                fox.Image = Properties.Resources.fox_up;
                fox.Width = 55;
                fox.Height = 95;
                
            }
                
            if (e.KeyCode == Keys.Down)
            {
                fox.Top += 11;
                fox.Image = Properties.Resources.fox_down;
                fox.Width = 55;
                fox.Height = 95;
               
            }
            foreach (Control x in this.Controls)
                if (x is PictureBox && x.Tag != null && x.Tag.ToString() == "wall")
                    if (fox.Bounds.IntersectsWith(x.Bounds))
                        if (e.KeyCode == Keys.Up)
                            fox.Top += 11;
                        else if (e.KeyCode == Keys.Down)
                            fox.Top -= 11;
                        else if (e.KeyCode == Keys.Left)
                            fox.Left += 11;
                        else if (e.KeyCode == Keys.Right)
                            fox.Left += -11;
            foreach (Control x in this.Controls)
                if (x is PictureBox && x.Tag != null && x.Tag.ToString() == "carrot")
                    if (fox.Bounds.IntersectsWith(x.Bounds))
                    {
                        if (x.Visible == true)
                            nr_carrot++;
                        x.Visible = false;
                        label1.Text = "🥕:" + nr_carrot;
                    }
    
                    if (fox.Bounds.IntersectsWith(wolf1.Bounds) || fox.Bounds.IntersectsWith(wolf2.Bounds) || fox.Bounds.IntersectsWith(wolf3.Bounds))
                    {
                        GameOver();
                    }
           

        }

        private void newGame()
        {
            Message.Visible = false; 

            Game_over = false;

            Timer.Start();

            Message.Location = new Point(87, 130);

            nr_carrot = 0;
            label1.Text = "🥕:" + nr_carrot;

            fox.Location = new Point(76, 82);
            fox.Image = Properties.Resources.fox_right;
            fox.Width = 150;
            fox.Height = 85;

            wolf1.Image = Properties.Resources.w_left;
            wolf1.Location = new Point(772, 157);
            wolf1.Height = 138;
            wolf1.Width = 215;

            wolf2.Image = Properties.Resources.w_right;
            wolf2.Location = new Point(422, 521);
            wolf2.Height = 141;
            wolf2.Width = 239;

            wolf3.Image = Properties.Resources.w_right;
            wolf3.Location = new Point(961, 566);
            wolf3.Height = 96;
            wolf3.Width = 141;

            foreach (Control x in this.Controls) 
            {
                if(x is PictureBox)
                {
                    x.Visible = true;
                }            
            }
            

        }

        private void GameOver()
        {
            Game_over = true;
            Timer.Stop();
            Message.Visible = true;

        }
    }
}
