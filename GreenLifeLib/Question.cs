using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLifeLib
{
    public class Question
    {
        public int Id { get; set; }
        public String QuestText { get; set; }

        public List<Answer> Answer { get; set; }
        public List<UserAnswer> UserAnswer { get; set; }
    }
}
