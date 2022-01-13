using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace GreenLifeLib
{
    public class Habit
    {
        #region [Props]

        public int Id { get; set; }
        public int Score { get; set; }
        public string HabitName { get; set; }

        #endregion

        #region [Rels]
        
        public HabitPhrase HabitPhrase { get; set; }
        public int TypeId { get; set; }
        public HabitType HabitType { get; set; }
        public int CheckListId { get; set; }
        public List<CheckListHabits> CheckListHabits { get; set; }
        public List<HabitPerformance> HabitPerformance { get; set; }

        #endregion

        #region [Methods]

        public static List<Habit> GetHabitsOfCheckList(int id)
        {
            using (ApplicationContext db = new())
            {

                var allHabits = db.Habit.Where(p => p.CheckListId == id).ToList();
                //var allHabits = db.Habit.ToList();

                List<Habit> habits = new();
                foreach (Habit h in allHabits)
                {
                    var perf = db.HabitPerformance.Include(p => p.Habit).Where(p => p.HabitId == h.Id).First();
                    if (!perf.Executed)
                        habits.Add(h);
                } 
                return habits; 
                //return allHabits;
            }
        }

        #endregion
    }
}
