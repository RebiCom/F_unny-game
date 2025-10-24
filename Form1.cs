using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;
using System.IO;
using System.Reflection; 

namespace F_unny
{
    public partial class Form1 : Form
    {
        WindowsMediaPlayer player=new WindowsMediaPlayer();
        public Form1()
        {
            InitializeComponent();
            player.URL = @"Media\Shakira - Try Everything.mp3";
            player.controls.play();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();  
            form2.Show(); 
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form7 form7 = new Form7();
            form7.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            button1.Visible = true;
            button2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            button3.Visible = false;
            label2.Location = new Point(300, 680);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            player.controls.play();
        }
    }
}
