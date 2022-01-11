using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLifeLib
{
    public class Phrase
    {
        public int Id { get; set; }
        public string PhraseText { get; set; }

        public int HabitId { get; set; }
        public List<HabitPhrase> HabitPhrase { get; set; }

        public static Phrase GetPhrase(int id)
        {
            using (ApplicationContext db = new())
            {
                var _phrase = db.Phrase.Where(p => p.HabitId == id).First();
                return _phrase;
            }
        }
    }
}
