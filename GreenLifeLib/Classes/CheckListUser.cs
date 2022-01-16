using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLifeLib
{
    public class CheckListUser
    {
        #region [Props]

        public int Id { get; set; }

        #endregion

        #region [Rels]

        public int CheckListId { get; set; }
        public CheckList CheckList { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        #endregion
    }
}
