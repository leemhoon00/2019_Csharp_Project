using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSProject
{
    public partial class ChangeInformation_Form : Form
    {
        public ChangeInformation_Form()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1.f.Show();
        }

        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox2.Focus();
            }
        }

        private void ChangeInformation_Form_Load(object sender, EventArgs e)
        {
            
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
                Button2_Click(sender, e);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();

            cmd.Connection = Form1.conn;
            cmd.CommandText = "select 비밀번호 from gamer where 아이디='" + HomeForm.user.ID + "'";
            OracleDataReader reader = cmd.ExecuteReader();

            reader.Read();
            string c = (string)reader[0];
            c = c.Trim();

            if (!textBox1.Text.Equals(c))
            {
                MessageBox.Show("비밀번호가 틀립니다.", "warning", MessageBoxButtons.OK, (MessageBoxIcon)16);
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox1.Focus();
                return;
            }

            if (!textBox2.Text.Equals(textBox3.Text))
            {
                MessageBox.Show("비밀번호 재확인이 틀립니다.", "warning", MessageBoxButtons.OK, (MessageBoxIcon)16);
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox1.Focus();
                return;
            }
            cmd.CommandText = "update gamer set 비밀번호='" + textBox2.Text + "' where 아이디='" + HomeForm.user.ID + "'";
            HomeForm.user.Password = textBox2.Text;
            cmd.ExecuteNonQuery();

            MessageBox.Show("비밀번호 변경이 완료 되었습니다!", "Success!!", MessageBoxButtons.OK, (MessageBoxIcon)0);
            this.Close();
            Form1.f.Show();
        }
    }
}
