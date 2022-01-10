using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLifeLib
{
    public class CheckListMark
    {
        public int Id { get; set; }
        public bool IsMarked { get; set; }

        public int CheckListId { get; set; }
        public CheckList CheckList;

        public static void Mark(int id)
        {
            using (ApplicationContext db = new())
            {
                var _checkList = db.CheckListMark.Include(p => p.CheckList).Where(p => p.CheckListId == id).ToList().First();
                _checkList.IsMarked = true;
                db.CheckListMark.Update(_checkList);
                db.SaveChanges();
            }
        }
    }
}
