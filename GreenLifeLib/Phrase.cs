using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLifeLib
{
    public class Phrase
    {
        public int Id { get; set; }
        public string PhraseText { get; set; }

        public List<Habit> Habit;
    }
}
