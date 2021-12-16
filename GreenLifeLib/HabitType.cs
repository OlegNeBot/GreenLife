using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLifeLib
{
    public class HabitType
    {
        public int Id { get; set; }
        public string NameType { get; set; }

        public List<Habit> Habit;
    }
}
