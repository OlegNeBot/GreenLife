using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLifeLib
{
    public class UserAnswer
    {
        public int Id { get; set; }

        public Question Question { get; set; }
        public Answer Answer { get; set; }
    }
}
