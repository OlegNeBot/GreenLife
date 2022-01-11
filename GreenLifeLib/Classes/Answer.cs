using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLifeLib
{
    public class Answer
    {
        public int Id { get; set; }
        public string AnswerText { get; set; }

        public int QuestionId { get; set; }
        public Question Question { get; set; }
        public List<UserAnswer> UserAnswer { get; set; }

        public static List<Answer> GetAnswersByQuestion(int id)
        {
            using (ApplicationContext db = new())
            {
                var _answers = db.Answer.Include(p => p.Question).Where(p => p.QuestionId == id).ToList();
                return _answers;
            }
        }
    }
}
