using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLifeLib
{
    public class PlanetColors
    {
        public int Id { get; set; }

        public List<Color> Color { get; set; }
        public Planet Planet { get; set; }

        public static List<Color> GetColorsByPlanet(int id)
        {
            using (ApplicationContext db = new())
            {
                var _colors = db.Color.Include(p => p.PlanetColors).Where(p => p.PlanetId == id).ToList();
                return _colors;
            }
        }
    }
}
