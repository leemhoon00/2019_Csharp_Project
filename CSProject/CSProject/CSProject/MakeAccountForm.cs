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
    public partial class MakeAccountForm : Form
    {
        

        public MakeAccountForm()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = Form1.conn;
            cmd.CommandText= "select count(*) from gamer where 아이디='" + textBox1.Text + "'";
            Int32 a = Convert.ToInt32(cmd.ExecuteScalar());
            if (a != 0)
            {
                MessageBox.Show("이미 있는 아이디입니다.", "warning", MessageBoxButtons.OK, (MessageBoxIcon)16);
                textBox1.Text = textBox2.Text = textBox3.Text = "";
                textBox1.Focus();
                return;
            }

            if (!textBox2.Text.Equals(textBox3.Text))
            {
                MessageBox.Show("비밀번호가 틀립니다.", "warning", MessageBoxButtons.OK, (MessageBoxIcon)16);
                textBox2.Text = ""; textBox3.Text = "";
                textBox1.Focus();
                return;
            }
            User user = new User(textBox1.Text,textBox2.Text);
            user.Score1 = user.Score2 = user.Score3 = user.Score4 = 3000;
            String sql = "insert into gamer values('" + user.ID + "','" + user.Password + "'," + user.Score1 + "," + user.Score2 + "," + user.Score3 + "," + user.Score4 + ")";
            
            
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            MessageBox.Show("회원가입이 완료되었습니다!", "Success!!", MessageBoxButtons.OK, (MessageBoxIcon)0);
            this.Close();
        }

        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox2.Focus();
            }
        }

        private void TextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox3.Focus();
            }
        }

        private void TextBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Button1_Click(sender, e);
            }
        }
    }
}
