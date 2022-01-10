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
    public partial class content2_Form : Form
    {
        string[] wordArray = { "가는 날이 장날", "가는 말이 고와야 오는 말이 곱다.", "가는 말에 채찍질", "간에 기별도 안 간다." };
        private int num;
        private int size;
        private double time;
        public content2_Form()
        {
            InitializeComponent();
        }

        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox1.Text.Equals(wordArray[num]))
                {
                    if (num == (size - 1))
                    {
                        if (HomeForm.user.Score2 > time)
                        {
                            OracleCommand cmd = new OracleCommand();
                            cmd.Connection = Form1.conn;
                            cmd.CommandText = "update gamer set 짧은글점수=" + time + "where 아이디='" + HomeForm.user.ID + "'";
                            HomeForm.user.Score2 = time;
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
                        wordLabel.Text = wordArray[++num];
                        textBox1.Text = "";
                    }
                }
                else
                {
                    textBox1.Text = "";
                }
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            time += 0.1;
            timeLabel.Text = time.ToString("##.#");
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1.f.Show();
        }

        private void Content2_Frame_Load(object sender, EventArgs e)
        {
            wordLabel.Text = wordArray[0];
            num = 0;
            size = wordArray.Length;
            time = 0;
            timeLabel.Text = time.ToString();
        }
    }
}
