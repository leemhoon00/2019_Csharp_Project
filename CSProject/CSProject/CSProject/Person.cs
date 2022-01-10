using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSProject
{
    class Person
    {
        public string ID;
        public double score;
        public Person(string ID, double score)
        {
            this.ID = ID;
            this.score = score;
        }
        public override string ToString() //메소드 재정의
        {
            return ID + "," + score;
        }
        public static Person operator + (Person p1, Person p2) //연산자중복
        {
            p1.score = p2.score;
            return p1;
        }
    }
}
