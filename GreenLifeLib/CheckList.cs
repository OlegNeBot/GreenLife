using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLifeLib
{
    public class CheckList
    {
        public int Id { get; set; }
        public bool ExecStatus { get; set; }

        public User User { get; set; }
        public List<Habit> Habit { get; set; }
        public List<CheckListMark> CheckListMark { get;set; }
    }
}
