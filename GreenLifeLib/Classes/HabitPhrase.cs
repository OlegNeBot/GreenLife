using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLifeLib
{
    public class HabitPhrase
    {
        public int Id { get; set; }

        public List<Phrase> Phrase { get; set; }
        public Habit Habit { get; set; }

        public static Phrase GetPhraseOfHabit(int id)
        {
            using (ApplicationContext db = new())
            {
                var _phrase = db.Phrase.Include(p => p.HabitPhrase).Where(p => p.HabitId == id).ToList().First();
                return _phrase;
            }
        }
    }
}
