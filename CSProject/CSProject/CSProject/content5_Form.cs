using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.IO.Ports;

namespace CSProject
{
    public partial class content5_Form : Form
    {
       
        int a = 0;
        Panel[] p;
        int count = 0;
        SerialPort port1;


        public content5_Form()
        {
            InitializeComponent();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            port1.Close();
            this.Close();
            Form1.f.Show();
        }

        

        private void Content5_Form_Load(object sender, EventArgs e)
        {
            port1 = new SerialPort("COM3");
            port1.Open();
            countLabel.Text = "맞춘갯수: " + count;
            p = new Panel[] { panel1, panel2, panel3, panel4, panel5, panel6, panel7, panel8, panel9 };
            
            new Thread(() => run()).Start();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            Random random = new Random();
            
            p[random.Next(1, 9)].BackColor = Color.Black;
            p[random.Next(1, 9)].BackColor = Color.Black;
            p[random.Next(1, 9)].BackColor = Color.Black;
            p[random.Next(1,9)].BackColor = Color.Red;
        }

        void run()
        {
            while (true)
            {
                string msg = port1.ReadLine();
                msg = msg.Trim();
                int c = int.Parse(msg);
                try
                {
                    if (p[c-1].BackColor == Color.Red)
                    {
                        count++;
                        countLabel.Text = "맞춘갯수: " + count;
                        p[c-1].BackColor = Color.Black;
                        if (count == 9)
                        {
                            port1.Close();
                            
                            if (MessageBox.Show("Clear!! 계속하시겠습니까?", "Clear!!", MessageBoxButtons.YesNo, (MessageBoxIcon)32) == DialogResult.Yes)
                            {
                                break;
                            }
                            else
                            {
                                System.Environment.Exit(1);
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("dfdf");
                }
            }
            Form1.f.Show();
            this.Close();
        }
    }
}
