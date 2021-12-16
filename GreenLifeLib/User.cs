using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLifeLib
{
    public class User
    {
        public int Id { get; set; }
        public int ScoreSum { get; set; }

        public StartPage StartPage;
        public Account Account { get; set; }
        public List<CheckList> CheckList { get; set; }
        public Role Role { get; set; }
    }
}
