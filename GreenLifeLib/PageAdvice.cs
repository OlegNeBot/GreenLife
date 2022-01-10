using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLifeLib
{
    public class PageAdvice
    {
        public int Id { get; set; }

        public List<Advice> Advice { get; set; }
        public StartPage StartPage { get; set; }

        public static PageAdvice GetRandomPageAdvice()
        {
            using (ApplicationContext db = new())
            {
                var _advices = db.PageAdvice.ToList();
                int _containing = _advices.Count;
                Random _rnd = new(_containing);
                int _num = _rnd.Next();
                return _advices[_num];
            }
        }
    }
}
