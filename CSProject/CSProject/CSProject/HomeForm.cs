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
    public partial class HomeForm : Form
    {
        public static User user;
        public Form prevForm;
        public HomeForm(User user,Form form)
        {
            HomeForm.user = user;
            InitializeComponent();
            prevForm = form;
        }

        private void HomeFrame_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void HomeFrame_Load(object sender, EventArgs e)
        {
            label1.Text = "사용자: " + user.ID;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            content1_Form f3 = new content1_Form();
            f3.Show();
            this.Hide();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            content2_Form f4 = new content2_Form();
            f4.Show();
            this.Hide();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            content3_Form f5 = new content3_Form();
            f5.Show();
            this.Hide();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            content4_Form f6 = new content4_Form();
            f6.Show();
            this.Hide();
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(1);
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            Ranking_Form f7 = new Ranking_Form();
            f7.Show();
            this.Hide();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            content5_Form f8 = new content5_Form();
            f8.Show();
            this.Hide();
        }

        private void 정보수정ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeInformation_Form f9 = new ChangeInformation_Form();
            f9.Show();
            this.Hide();
        }

        private void 회원탈퇴ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = Form1.conn;
            cmd.CommandText = "delete from gamer where 아이디='" + HomeForm.user.ID + "'";
            cmd.ExecuteNonQuery();
            Form1.thisform.Show();
            this.Close();
        }

        private void 로그아웃ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            
            this.Close();
            Form1.thisform.Show();
        }
    }
}
