using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLifeLib
{
    public class Colors
    {
        public int Id { get; set; }
        public enum Color { } //Will be added ASAP, waiting for the colors
        public List<Color> PlanetColor { get; set; }

        public List<Planet> Planet { get; set; }

    }
}
