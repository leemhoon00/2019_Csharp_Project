using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProject
{
    public abstract class User2  
    {
        public string ID { get; set; }  //프로퍼티
        public string Password { get; set; }
        public double Score1 { get; set; }
        public double Score2 { get; set; }
        public double Score3 { get; set; }
        public double Score4 { get; set; }
    }

    public class User : User2  //상속
    {
        public User(string ID, string pw)
        {
            this.ID = ID;
            Password = pw;
        }
        public User(String ID)
        {
            this.ID = ID;
        }
    }
}
