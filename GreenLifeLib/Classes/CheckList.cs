using System.Collections.Generic;
using System.Linq;

namespace GreenLifeLib
{
    public class CheckList
    {
        #region [Props]

        public int Id { get; set; }
        public bool ExecStatus { get; set; }
        public string CheckListName { get; set; }

        #endregion

        #region [Rels]

        public int AccountId { get; set; }
        public Account Account { get; set; }
        public CheckListMark CheckListMark { get;set; }
        public CheckListHabits CheckListHabits { get; set; }

        #endregion

        #region [Methods]

        public static List<CheckList> GetCheckLists(int id)
        {
            using (ApplicationContext db = new())
            {
                var checkLists = db.CheckList.Where(p => p.AccountId == id).ToList();
                return checkLists;
            }
        }

        public static List<CheckList> GetCheckLists()
        {
            using (ApplicationContext db = new())
            {
                var checkLists = db.CheckList.Where(p => p.Id == 1 || p.Id == 2).ToList();
                return checkLists;
            }
        }

        #endregion
    }
}
