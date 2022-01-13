using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GreenLifeLib
{
    public class CheckListMark
    {
        #region [Props]

        public int Id { get; set; }
        public bool IsMarked { get; set; }

        #endregion

        #region [Rels]

        public int CheckListId { get; set; }
        public CheckList CheckList;

        #endregion

        #region [Methods]

        public static void Mark(int id)
        {
            using (ApplicationContext db = new())
            {
                var checkList = db.CheckListMark.Include(p => p.CheckList).Where(p => p.CheckListId == id).ToList().First();
                checkList.IsMarked = true;
                db.CheckListMark.Update(checkList);
                db.SaveChanges();
            }
        }

        #endregion
    }
}
