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

        public CheckList CheckList;
    }
}
