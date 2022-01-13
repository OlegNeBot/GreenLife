using System.Collections.Generic;

namespace GreenLifeLib
{
    public class User
    {
        #region [Props]

        public int Id { get; set; }
        public int ScoreSum { get; set; }

        #endregion

        #region [Rels]

        public int StartPageId { get; set; }
        public StartPage StartPage { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
        public Role Role { get; set; }

        #endregion

        #region [Methods]

        public void UserStats() 
        { 
            //TODO: Find a tool to create a text/json doc to init the user
        }

        public void UserStats(string stats) 
        { 
            //TODO: Clear that file and add new info
        }

        #endregion
    }
}
