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
    public partial class Form1 : Form
    {
        public static String oledb = "Data Source=XE;User id=cs;Password=cs;";
        public static OracleConnection conn = new OracleConnection(oledb);
        public static HomeForm f;
        public static Form1 thisform;



        public Form1()
        {
            conn.Open();
            thisform = this;
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            MakeAccountForm f2 = new MakeAccountForm();
            f2.Show();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string sql = "select count(*) from gamer where 아이디='"+textBox1.Text+"'";
            OracleCommand cmd = new OracleCommand();
            
            cmd.Connection = Form1.conn;
            cmd.CommandText = sql;
            
            Int32 a = Convert.ToInt32(cmd.ExecuteScalar());
            if (a==0)
            {
                MessageBox.Show("아이디가 없습니다.", "warning", MessageBoxButtons.OK, (MessageBoxIcon)16);
                textBox1.Text = ""; textBox2.Text = "";
                return;
            }
            cmd.CommandText = "select 비밀번호 from gamer where 아이디='" + textBox1.Text + "'";
            OracleDataReader reader = cmd.ExecuteReader();

            reader.Read();
            string c = (string)reader[0];
            c = c.Trim();
            if (!textBox2.Text.Equals(c))
            {
                MessageBox.Show("비밀번호가 틀립니다.", "warning", MessageBoxButtons.OK, (MessageBoxIcon)16);
                textBox2.Text = "";
                return;
            }

            User user = new User(textBox1.Text,textBox2.Text);

            cmd.CommandText="select * from gamer where 아이디='"+textBox1.Text+"'";
            reader = cmd.ExecuteReader();
            reader.Read();

            user.Score1 = Decimal.ToDouble((Decimal)reader[2]);
            user.Score2 = Decimal.ToDouble((Decimal)reader[3]);
            user.Score3 = Decimal.ToDouble((Decimal)reader[4]);
            user.Score4 = Decimal.ToDouble((Decimal)reader[5]);

            f = new HomeForm(user,this);
            f.Show();
            this.Hide();
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void TextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Button1_Click(sender, e);
            }
        }

        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox2.Focus();
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(1);
        }
    }
}
