using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace GreenLifeLib
{
    public class HabitPerformance
    {
        #region [Props]

        public int Id { get; set; }
        public string ExecProperty { get; set; }
        public int NumOfExecs { get; set; }
        public DateTime DateOfExec { get; set; }
        public bool Executed { get; set; }

        #endregion

        #region [Rels]

        public int HabitId { get; set; }
        public Habit Habit { get; set; }
        public Account Account { get; set; }

        #endregion

        #region [Methods]

        public static void NewExecution(int id)
        {
            using (ApplicationContext db = new())
            {
                var habit = db.HabitPerformance.Include(p => p.Habit).Where(p => p.HabitId == id).First();
                int execs = int.Parse(habit.ExecProperty);
                if (!habit.Executed)
                {
                    habit.NumOfExecs++;
                    habit.DateOfExec = DateTime.Now;
                    if (habit.NumOfExecs == execs)
                        habit.Executed = true;
                    db.HabitPerformance.Update(habit);
                    db.SaveChanges();
                }
            }
        }

        public static HabitPerformance GetExecution(int id)
        {
            using (ApplicationContext db = new())
            {
                var _exec = db.HabitPerformance.Include(p => p.Habit).Where(p => p.HabitId == id).First();
                return _exec;
            }
        }

        #endregion
    }
}
