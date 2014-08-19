using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using Lego.Ev3.Core;
using Lego.Ev3.Desktop;

namespace EV3Controller
{
    public partial class Form1 : Form
    {
        static public bool ConnectionState;
        
        private Task Work;
        //Fr                                    //En
        //Changer le ip pour connecter au robot // Change this ip to connect
        private Server EV3 = new Server("10.2.0.59");
        private Thread Execute;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EV3.SendCommand("w");
        }

        private void BtnLeft_Click(object sender, EventArgs e)
        {
            EV3.SendCommand("a");
        }

        private void BtnRight_Click(object sender, EventArgs e)
        {
            EV3.SendCommand("d");
        }

        private void BtnBackward_Click(object sender, EventArgs e)
        {
            EV3.SendCommand("s");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (EV3.GetConnectionStatus())
            {
                progressBar1.Value = 100-EV3.GetLightLevel();
                progressBar2.Value = 100-(EV3.GetDistance());
                progressBar3.Value = EV3.GetTouch();
                label5.Text = "" + EV3.GetDistanceDone() + "cm";
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (EV3.Speed != 100)
            {
                EV3.Speed++;
                label7.Text = ""+EV3.Speed;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (EV3.Speed != 0)
            {
                EV3.Speed--;
                label7.Text = ""+EV3.Speed;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EV3.SendMessage(textBox1.Text);
        }

    }
}
