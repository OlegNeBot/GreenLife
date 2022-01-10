using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLifeLib
{
    public class Color
    {
        public int Id { get; set; }
        public string ColorName { get; set; }

        public int PlanetId { get; set; }
        public List<PlanetColors> PlanetColors { get; set; }

        public static List<Color> GetColors()
        {
            using (ApplicationContext db = new())
            {
                var _colors = db.Color.ToList();
                return _colors;
            }
        }
    }
}
