using Microsoft.EntityFrameworkCore;
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

        public int HabitId { get; set; }
        public List<Habit> Habit { get; set; }
        public User User { get; set; }

        public static void NewExecution(int id)
        {
            using (ApplicationContext db = new())
            {
                var _habit = db.HabitPerformance.Include(p => p.Habit).Where(p => p.HabitId == id).First();
                _habit.NumOfExecs++;
                _habit.DateOfExec = DateTime.Now;
                db.HabitPerformance.Update(_habit);
                db.SaveChanges();
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
    }
}
