using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLifeLib
{
    public class CheckListHabits
    {
        public int Id { get; set; }

        public int CheckListId { get; set; }
        public CheckList CheckList { get; set; }
        public List<Habit> Habit { get; set; }

    }
}
