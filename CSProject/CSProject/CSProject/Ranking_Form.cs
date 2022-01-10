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
    
    public partial class Ranking_Form : Form
    {
        SortedSet<Person> sset = new SortedSet<Person>(new interfaceclass());
        public Ranking_Form()
        {
            InitializeComponent();
        }

        class interfaceclass : IComparer<Person> //인터페이스
        {
            public int Compare(Person a, Person b)
            {
                if (a.score > b.score)
                {
                    return 1;
                }
                
                else
                    return -1;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1.f.Show();
        }

        private void Ranking_Form_Load(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = Form1.conn;
            cmd.CommandText = "select count(*) from gamer";
            Int32 a = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.CommandText = "select 아이디, 단어점수 from gamer";
            OracleDataReader reader = cmd.ExecuteReader();
            for(int i = 0; i < a; i++)
            {
                reader.Read();
                string c = (string)reader[0];
                c = c.Trim();
                double score= Decimal.ToDouble((Decimal)reader[1]);
                if (score == 3000)
                    continue;
                sset.Add(new Person(c, score));
            }
            int j = 1;
            foreach(Person p in sset)
            {
                ListViewItem item;
                item = new ListViewItem(j.ToString());
                j++;
                item.SubItems.Add(p.ID);
                item.SubItems.Add(p.score.ToString());
                listView1.Items.Add(item);
            }
            listView1.BringToFront();
            sset.Clear();



            cmd.CommandText = "select 아이디, 짧은글점수 from gamer";
            reader = cmd.ExecuteReader();
            for (int i = 0; i < a; i++)
            {
                reader.Read();
                string c = (string)reader[0];
                c = c.Trim();
                double score = Decimal.ToDouble((Decimal)reader[1]);
                if (score == 3000)
                    continue;
                sset.Add(new Person(c, score));
            }
            j = 1;
            foreach (Person p in sset)
            {
                ListViewItem item;
                item = new ListViewItem(j.ToString());
                j++;
                item.SubItems.Add(p.ID);
                item.SubItems.Add(p.score.ToString());
                listView2.Items.Add(item);
            }
            sset.Clear();


            cmd.CommandText = "select 아이디, 긴글점수 from gamer";
            reader = cmd.ExecuteReader();
            for (int i = 0; i < a; i++)
            {
                reader.Read();
                string c = (string)reader[0];
                c = c.Trim();
                double score = Decimal.ToDouble((Decimal)reader[1]);
                if (score == 3000)
                    continue;
                sset.Add(new Person(c, score));
            }
            j = 1;
            foreach (Person p in sset)
            {
                ListViewItem item;
                item = new ListViewItem(j.ToString());
                j++;
                item.SubItems.Add(p.ID);
                item.SubItems.Add(p.score.ToString());
                listView3.Items.Add(item);
            }
            sset.Clear();


            cmd.CommandText = "select 아이디, 두더지점수 from gamer";
            reader = cmd.ExecuteReader();
            for (int i = 0; i < a; i++)
            {
                reader.Read();
                string c = (string)reader[0];
                c = c.Trim();
                double score = Decimal.ToDouble((Decimal)reader[1]);
                if (score == 3000)
                    continue;
                sset.Add(new Person(c, score));
            }
            j = 1;
            foreach (Person p in sset)
            {
                ListViewItem item;
                item = new ListViewItem(j.ToString());
                j++;
                item.SubItems.Add(p.ID);
                item.SubItems.Add(p.score.ToString());
                listView4.Items.Add(item);
            }
            sset.Clear();
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            listView1.BringToFront();
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            listView2.BringToFront();
        }

        private void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            listView3.BringToFront();
        }

        private void RadioButton4_CheckedChanged(object sender, EventArgs e)
        {
            listView4.BringToFront();
        }
    }
}
