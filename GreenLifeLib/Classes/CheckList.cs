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

        public Type Type { get; set; }

        public CheckListHabits CheckListHabits { get; set; }
        
        public CheckListUser CheckListUser { get; set; }

        #endregion

        #region [Methods]

        public static List<CheckList> GetCheckLists(int id)
        {
            using (ApplicationContext db = new())
            {
                var checkLists = db.CheckList.Where(p => p.CheckListUser.UserId == id).ToList();
                return checkLists;
            }
        }

        #endregion
    }
}
