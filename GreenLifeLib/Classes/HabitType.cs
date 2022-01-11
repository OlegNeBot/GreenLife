using Microsoft.EntityFrameworkCore;
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

        public static List<Habit> GetHabitsByType(int id)
        {
            using (ApplicationContext db = new())
            {
                var _habits = db.Habit.Where(p => p.TypeId == id).ToList();
                return _habits;
            }
        }
    }
}
