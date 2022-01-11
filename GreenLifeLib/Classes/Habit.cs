using Microsoft.EntityFrameworkCore;
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
        public string HabitName { get; set; }

        public HabitPhrase HabitPhrase { get; set; }
        public int TypeId { get; set; }
        public HabitType HabitType { get; set; }
        public int CheckListId { get; set; }
        public List<CheckListHabits> CheckListHabits { get; set; }

        public static List<Habit> GetHabitsOfCheckList(int id)
        {
            using (ApplicationContext db = new())
            {
                var _habits = db.Habit.Include(p => p.CheckListHabits).Where(p => p.CheckListId == id).ToList();
                return _habits;
            }
        }
    }
}
