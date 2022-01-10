using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLifeLib
{
    public class DayPhrase
    {
        public int Id { get; set; }
        public string PhraseText { get; set; }

        public List<PagePhrase> PagePhrase { get; set; }

        public static string GetRandomPhrase()
        {
            using (ApplicationContext db = new())
            {
                var _phrases = db.DayPhrase.ToList();
                int _containing = _phrases.Count;
                Random _rnd = new(_containing);
                int _num = _rnd.Next();
                return _phrases[_num].PhraseText;
            }
        }
    }
}
