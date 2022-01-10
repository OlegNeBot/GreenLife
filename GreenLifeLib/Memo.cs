using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLifeLib
{
    public class Memo
    {
        public int Id { get; set; }
        public string MemoName { get; set; }
        public string MemoRef { get; set; }

        public static List<Memo> GetMemos()
        {
            using (ApplicationContext db = new())
            {
                var _memos = db.Memo.ToList();
                return _memos;
            }
        }
    }
}
