using Microsoft.EntityFrameworkCore;
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
        public int AccountId { get; set; }
        public Account Account { get; set; }

        public static List<UserAnswer> GetUserAnswers(int id)
        {
            using (ApplicationContext db = new())
            {
                var _answers = db.UserAnswer.Include(p => p.Account).Where(p => p.AccountId == id).ToList();
                return _answers;
            }
        }

        public static void AddUserAnswer(UserAnswer answ)
        {
            using (ApplicationContext db = new())
            {
                db.Add(answ);
                db.SaveChanges();
            }
        }
    }
}
