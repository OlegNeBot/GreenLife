using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLifeLib
{
    public class PagePhrase
    {
        public int Id { get; set; }

        public List<DayPhrase> DayPhrase { get; set; }
        public StartPage StartPage { get; set; }

        public static PagePhrase GetRandomPagePhrase()
        {
            using (ApplicationContext db = new())
            {
                var _phrases = db.PagePhrase.ToList();
                int _containing = _phrases.Count;
                Random _rnd = new(_containing);
                int _num = _rnd.Next();
                return _phrases[_num];
            }
        }
    }
}
