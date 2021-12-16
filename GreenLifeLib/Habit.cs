using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLifeLib
{
    public class Habit
    {
        public int Id { get; set; }
        public int Score { get; set; }

        public Phrase Phrase { get; set; }
        public HabitType HabitType { get; set; }
        public List<CheckList> CheckList { get; set; }
    }
}
