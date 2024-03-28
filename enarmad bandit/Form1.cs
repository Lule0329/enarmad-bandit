using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace enarmad_bandit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.BackColor = SystemColors.Control;
            button2.BackColor = SystemColors.Control;
            label1.Text = "Spins: " + spins;
            pictureBox1.Image = Images[0];
            pictureBox2.Image = Images[0];
            pictureBox3.Image = Images[0];
        }

        Image[] Images = { Properties.Resources._7, Properties.Resources.hjärter, Properties.Resources.ruter, Properties.Resources.spader };
        Image[] Images2 = { Properties.Resources.hjärter, Properties.Resources._7, Properties.Resources.spader, Properties.Resources.ruter };
        Image[] Images3 = { Properties.Resources.ruter, Properties.Resources.hjärter, Properties.Resources.spader, Properties.Resources._7 };
        
        int spins = 100;
        bool multi = false;

        private void timers()
        {
            // Startar Timers
            if (checkBox1.Checked == false)
            {
                timer1.Start();
            }
            else
            {
                timer1.Stop();
            }

            if (checkBox2.Checked == false)
            {
                timer2.Start();
            }
            else
            {
                timer2.Stop();
            }

            if (checkBox3.Checked == false)
            {
                timer3.Start();
            }
            else
            {
                timer3.Stop();
            }

            timer4.Start();
        }
        
        private void checkWin()
        {
            if (pictureBox1.Image == Images[0] && pictureBox2.Image == Images[0] && pictureBox3.Image == Images[0] ||
                pictureBox1.Image == Images[1] && pictureBox2.Image == Images[1] && pictureBox3.Image == Images[1] ||
                pictureBox1.Image == Images[2] && pictureBox2.Image == Images[2] && pictureBox3.Image == Images[2] ||
                pictureBox1.Image == Images[3] && pictureBox2.Image == Images[3] && pictureBox3.Image == Images[3])
            {
                if (multi == true)
                {
                    spins += 10;
                }
                else
                {
                    spins += 5;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Sätter random tid på varje timer (mellan 75 och 125)
            Random random = new Random();
            timer1.Interval = random.Next(75, 125);
            timer2.Interval = random.Next(75, 125);
            timer3.Interval = random.Next(75, 125);

            timers();
            if (multi == true)
            {
                spins -= 2;
            }
            else
            {
                spins -= 1;
            }
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            timer2.Stop();
            timer3.Stop();
            timer4.Stop();
            checkWin();
            label1.Text = "Spins: " + spins;
            multi = false;
            button2.Enabled = true;
            button2.BackColor = SystemColors.Control;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random rng = new Random();
            pictureBox1.Image = Images[rng.Next(0, 4)];
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Random rng = new Random();
            pictureBox2.Image = Images2[rng.Next(0, 4)];
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            Random rng = new Random();
            pictureBox3.Image = Images3[rng.Next(0, 4)];
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                pictureBox1.Enabled = false;
            }
            else if (checkBox1.Checked == false)
            {
                pictureBox1.Enabled = true;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                pictureBox2.Enabled = false;
            }
            else if (checkBox2.Checked == false)
            {
                pictureBox2.Enabled = true;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                pictureBox3.Enabled = false;
            }
            else if (checkBox3.Checked == false)
            {
                pictureBox3.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            multi = true;
            button2.Enabled = true;
            button2.BackColor = Color.DarkGray;
        }
    }
}
