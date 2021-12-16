using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLifeLib
{
    public class HabitPerformance
    {
        public int Id { get; set; }
        public string ExecProperty { get; set; }
        public int NumOfExecs { get; set; }
        public DateTime DateOfExec { get; set; }

        public List<Habit> Habit { get; set; }
    }
}
