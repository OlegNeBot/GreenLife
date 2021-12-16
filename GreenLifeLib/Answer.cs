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

        public Question Question { get; set; }
        public List<UserAnswer> UserAnswer { get; set; }
    }
}
