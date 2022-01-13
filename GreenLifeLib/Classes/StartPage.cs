using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GreenLifeLib
{
    public class StartPage
    {
        #region [Props]

        public int Id { get; set; }

        #endregion

        #region [Rels]

        public int PlanetId {get;set;}
        public Planet Planet { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public PagePhrase PagePhrase { get; set; }

        #endregion

        #region [Methods]

        public static StartPage GetPageByUser(int id)
        {
            using (ApplicationContext db = new())
            {
                var page = db.StartPage.Include(p => p.User).Where(p => p.UserId == id).First();
                return page;
            }
        }

        #endregion
    }
}
