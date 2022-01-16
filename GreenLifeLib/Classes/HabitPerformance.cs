using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace GreenLifeLib
{
    public class HabitPerformance
    {
        #region [Props]

        public int Id { get; set; }
        public int NumOfExecs { get; set; }
        public DateTime DateOfExec { get; set; }
        public bool Executed { get; set; }

        #endregion

        #region [Rels]

        public Habit Habit { get; set; }

        public User User { get; set; }

        #endregion

        #region [Methods]

        public static void NewExecution(int habitId, int userId)
        {
            using (ApplicationContext db = new())
            {
                var habit = db.Habit.Where(p => p.Id == habitId).First();
                var account = db.Account.Where(p => p.User.Id == userId).First();
                var habitPerf = db.HabitPerformance
                    .Where(p => p.Habit.Id == habit.Id)
                    .Where(p => p.User.Id == userId)
                    .First();
                if (!habitPerf.Executed)
                {
                    if ((DateTime.Now - Convert.ToDateTime(habitPerf)).TotalHours > 24)
                    {
                        habitPerf.NumOfExecs++;
                        habitPerf.DateOfExec = DateTime.Now;
                        if (habitPerf.NumOfExecs == habit.NumsNeeded)
                        {
                            habitPerf.Executed = true;
                            account.ScoreSum += habit.Score;
                        }
                        db.HabitPerformance.Update(habitPerf);
                        db.Account.Update(account);
                        db.SaveChanges();
                    }
                }
            }
        }

        public static HabitPerformance GetExecution(int habitId, int userId)
        {
            using (ApplicationContext db = new())
            {
                var _exec = db.HabitPerformance
                    .Where(p => p.Habit.Id == habitId)
                    .Where(p => p.User.Id == userId)
                    .First();
                return _exec;
            }
        }

        #endregion
    }
}
