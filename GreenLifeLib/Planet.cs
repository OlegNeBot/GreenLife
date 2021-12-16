using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLifeLib
{
    public class Planet
    {
        public int Id { get; set; }
        public string PlanetRef { get; set; }

        public StartPage StartPage { get; set; }
        public List<Colors> Colors { get; set; }
        public PlanetElem PlanetElem { get; set; }
    }
}
