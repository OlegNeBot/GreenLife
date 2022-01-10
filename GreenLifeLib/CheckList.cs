using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLifeLib
{
    public class CheckList
    {
        public int Id { get; set; }
        public bool ExecStatus { get; set; }
        public string CheckListName { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
        public CheckListMark CheckListMark { get;set; }
        public CheckListHabits CheckListHabits { get; set; }

        public static List<CheckList> GetCheckLists(int id)
        {
            using (ApplicationContext db = new())
            {
                var _checkLists = db.CheckList.Where(p => p.UserId == id).ToList();
                return _checkLists;
            }
        }
    }
}
