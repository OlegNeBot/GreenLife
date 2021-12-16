using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLifeLib
{
    public class PlanetElem
    {
        public int Id { get; set; }
        public string ElemDescription { get; set; }
        public string ElemRef { get; set; }

        public List<Planet> Planet;
    }
}
