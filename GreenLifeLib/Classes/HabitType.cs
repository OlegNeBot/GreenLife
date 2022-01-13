using System.Collections.Generic;
using System.Linq;

namespace GreenLifeLib
{
    public class HabitType
    {
        #region [Props]

        public int Id { get; set; }
        public string NameType { get; set; }

        #endregion

        #region [Rels]

        public List<Habit> Habit;

        #endregion

        #region [Methods]

        public static List<Habit> GetHabitsByType(int id)
        {
            using (ApplicationContext db = new())
            {
                var habits = db.Habit.Where(p => p.TypeId == id).ToList();
                return habits;
            }
        }

        #endregion
    }
}
