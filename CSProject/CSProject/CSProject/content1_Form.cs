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
    public partial class content1_Form : Form
    {
        string[] wordArray = { "한글", "아리랑", "자바", "씨샵" };
        private int num;
        private int size;
        private double time;
        public content1_Form()
        {
            InitializeComponent();
        }


        private void Content1_Frame_Load(object sender, EventArgs e)
        {
            prevLabel.Text = "";
            nextLabel.Text = wordArray[1];
            wordLabel.Text = wordArray[0];
            num = 0;
            size = wordArray.Length;
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
                if (textBox1.Text.Equals(wordArray[num]))
                {
                    if (num == (size - 1))
                    {
                        if (HomeForm.user.Score1 > time)
                        {
                            OracleCommand cmd = new OracleCommand();
                            cmd.Connection = Form1.conn;
                            cmd.CommandText = "update gamer set 단어점수=" + time + "where 아이디='" + HomeForm.user.ID + "'";
                            HomeForm.user.Score1 = time;
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
                        if (num != (size - 1))
                        {
                            prevLabel.Text = wordArray[num - 1];
                            nextLabel.Text = wordArray[num + 1];
                        }
                        else
                        {
                            prevLabel.Text = wordArray[num - 1];
                            nextLabel.Text = "";
                        }
                        textBox1.Text = "";
                    }
                }
                else
                {
                    textBox1.Text = "";
                }
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1.f.Show();
        }
    }
}
