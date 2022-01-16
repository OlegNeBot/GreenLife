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
        public int NumsNeeded { get; set; }
        public string ExecProperty { get; set; }

        #endregion

        #region [Rels]
        
        public HabitPhrase HabitPhrase { get; set; }

        public Type Type { get; set; }

        public List<CheckListHabits> CheckListHabits { get; set; }

        public List<HabitPerformance> HabitPerformance { get; set; }

        #endregion

        #region [Methods]
        public static List<Habit> GetHabitsOfCheckList(int id)
        {
            using (ApplicationContext db = new())
            {
                var allRels = db.CheckListHabits.Where(p => p.CheckListId == id).ToList();
                List<Habit> Habits = new();
                foreach (CheckListHabits rel in allRels)
                {
                    var habit = db.Habit.Where(p => p.Id == rel.HabitId).First();
                    Habits.Add(habit);
                } 
                return Habits; 
            }
        } 

        #endregion
    }
}
