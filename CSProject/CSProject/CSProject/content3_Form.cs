using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OracleClient;

namespace CSProject
{
    public partial class content3_Form : Form
    {
        string[] wordArray = { "동해물과 백두산이 마르고 닳도록", "하느님이 보우하사 우리나라 만세", "무궁화 삼천리 화려 강산", "대한 사람 대한으로 길이 보전하세" };
        double time;
        public content3_Form()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1.f.Show();
        }

        private void Content3_Frame_Load(object sender, EventArgs e)
        {
            label1.Text = wordArray[0];
            label2.Text = wordArray[1];
            label3.Text = wordArray[2];
            label4.Text = wordArray[3];
            time = 0;
            timeLabel.Text = time.ToString();

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            time += 0.1;
            timeLabel.Text = time.ToString("##.#");
        }

        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox1.Text.Equals(wordArray[0]))
                {
                    textBox2.Focus();
                }
                else
                {
                    textBox1.Text = "";
                }
            }
        }

        private void TextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox2.Text.Equals(wordArray[1]))
                {
                    textBox3.Focus();
                }
                else
                {
                    textBox2.Text = "";
                }
            }
        }

        private void TextBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox3.Text.Equals(wordArray[2]))
                {
                    textBox4.Focus();
                }
                else
                {
                    textBox3.Text = "";
                }
            }
        }

        private void TextBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox4.Text.Equals(wordArray[3]))
                {
                    if (HomeForm.user.Score3 > time)
                    {
                        OracleCommand cmd = new OracleCommand();
                        cmd.Connection = Form1.conn;
                        cmd.CommandText = "update gamer set 긴글점수=" + time + "where 아이디='" + HomeForm.user.ID + "'";
                        HomeForm.user.Score3 = time;
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
                else
                {
                    textBox4.Text = "";
                }
            }
        }
    }
}
