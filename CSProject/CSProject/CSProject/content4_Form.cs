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
using System.Data.OracleClient;

namespace CSProject
{
    public partial class content4_Form : Form
    {
        Thread t1;
        int totalNum = 9; //9개 맞추면 끝
        double time;
        static string[] array = { "아리랑", "한글", "단어", "자바", "씨샵", "산성비", "두더지", "컴퓨터", "보리", "이지민", "이상락", "빵락", "해병대", "김지성" };
        int size = array.Length;
        int count = 0;
        static Label[] labelArray;
        public content4_Form()
        {
            InitializeComponent();
        }

        private void Content4_Frame_Load(object sender, EventArgs e)
        {
            time = 0;
            timeLabel.Text = time.ToString();
            labelArray = new Label[]{ label1, label2, label3, label4, label5, label6, label7, label8, label9 };
            countLabel.Text = "맞춘갯수: 0";
            RandomThread obj = new RandomThread();
            ThreadStart ts = new ThreadStart(obj.ThreadBody);
            t1 = new Thread(ts);
            t1.Start();
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1.f.Show();
        }

        private void Content4_Frame_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawEllipse(Pens.Black, 90, 20, 100, 100);
            g.DrawEllipse(Pens.Black, 190, 20, 100, 100);
            g.DrawEllipse(Pens.Black, 290, 20, 100, 100);

            g.DrawEllipse(Pens.Black, 90, 120, 100, 100);
            g.DrawEllipse(Pens.Black, 190, 120, 100, 100);
            g.DrawEllipse(Pens.Black, 290, 120, 100, 100);

            g.DrawEllipse(Pens.Black, 90, 220, 100, 100);
            g.DrawEllipse(Pens.Black, 190, 220, 100, 100);
            g.DrawEllipse(Pens.Black, 290, 220, 100, 100);

            
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            time += 0.1;
            timeLabel.Text = time.ToString("##.#");
        }
        class RandomThread
        {
            
            public void ThreadBody()
            {
                Random random = new Random();
                while (true)
                {
                    int a = random.Next(0, 9);
                    int b = random.Next(0, array.Length-1);
                    labelArray[random.Next(0, 9)].Text = "";
                    labelArray[random.Next(0, 9)].Text = "";
                    labelArray[random.Next(0, 9)].Text = "";
                    labelArray[a].Text = array[b];
                    Thread.Sleep(1000);
                    
                }
            }
        }

        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                for(int i = 0; i < 9; i++)
                {
                    if (textBox1.Text.Equals(labelArray[i].Text) && !textBox1.Text.Equals(""))
                    {
                        count++;
                        labelArray[i].Text = "";
                        countLabel.Text = "맞춘갯수: " + count;
                        if (count == totalNum)
                        {
                            t1.Abort();
                            if (HomeForm.user.Score4 > time)
                            {
                                OracleCommand cmd = new OracleCommand();
                                cmd.Connection = Form1.conn;
                                cmd.CommandText = "update gamer set 두더지점수=" + time + "where 아이디='" + HomeForm.user.ID + "'";
                                HomeForm.user.Score4 = time;
                                cmd.ExecuteNonQuery();

                            }
                            if (MessageBox.Show("걸린시간: " + time + "  계속하시겠습니까?", "Clear!!", MessageBoxButtons.YesNo, (MessageBoxIcon)32) == DialogResult.Yes)
                            {
                                Form1.f.Show();
                                this.Close();
                            }
                            else
                            {
                                System.Environment.Exit(1);
                            }
                        }
                        break;
                    }
                }
                textBox1.Text = "";
            }
        }
    }
}
