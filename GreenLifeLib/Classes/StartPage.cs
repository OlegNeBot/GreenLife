using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLifeLib
{
    public class StartPage
    {
        public int Id { get; set; }

        public Planet Planet { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public PageAdvice PageAdvice { get; set; }
        public PagePhrase PagePhrase { get; set; }

        public static StartPage GetPageByUser(int id)
        {
            using (ApplicationContext db = new())
            {
                var _page = db.StartPage.Include(p => p.User).Where(p => p.UserId == id).First();
                return _page;
            }
        }
    }
}
