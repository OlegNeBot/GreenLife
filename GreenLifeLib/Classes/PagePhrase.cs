using System;
using System.Collections.Generic;
using System.Linq;

namespace GreenLifeLib
{
    public class PagePhrase
    {
        #region [Props]

        public int Id { get; set; }

        #endregion

        #region [Rels]

        public List<DayPhrase> DayPhrase { get; set; }
        public int StartPageId { get; set; }
        public StartPage StartPage { get; set; }

        #endregion

        #region [Methods]

        public static PagePhrase GetRandomPagePhrase()
        {
            using (ApplicationContext db = new())
            {
                int cnt = db.PagePhrase.Count();
                Random rnd = new();
                int num = rnd.Next(cnt);
                var contains = db.PagePhrase.Where(p => p.Id == num + 1).First();
                return contains;
            }
        }

        #endregion
    }
}
