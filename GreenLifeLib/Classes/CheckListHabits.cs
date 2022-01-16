﻿using System.Collections.Generic;

namespace GreenLifeLib
{
    public class CheckListHabits
    {
        #region [Props]

        public int Id { get; set; }

        #endregion

        #region [Rels]

        public int CheckListId { get; set; }
        public CheckList CheckList { get; set; }

        public int HabitId { get; set; }
        public List<Habit> Habit { get; set; }

        #endregion

    }
}
