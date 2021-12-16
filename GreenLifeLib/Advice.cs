using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLifeLib
{
    public class Advice
    {
        public int Id { get; set; }
        public string AdviceText { get; set; }

        public List<StartPage> StartPage;
    }
}
