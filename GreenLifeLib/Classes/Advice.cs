using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLifeLib
{
    public class Advice
    {
        public int Id { get; set; }
        public string AdviceText { get; set; }

        public List<PageAdvice> PageAdvice { get; set; }

        public static Advice GetRandomAdvice()
        {
            using (ApplicationContext db = new())
            {
                var _advices = db.Advice.ToList();
                int _containing = _advices.Count;
                Random _rnd = new(_containing);
                int _num = _rnd.Next();
                return _advices[_num];
            }
        }
    }
}
