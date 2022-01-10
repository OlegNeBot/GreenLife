using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLifeLib
{
    public class PlanetElement
    {
        public int Id { get; set; }

        public List<Element> Element { get; set; }
        public Planet Planet { get; set; }

        public static List<Element> GetElementsByPlanet(int id)
        {
            using (ApplicationContext db = new())
            {
                var _elements = db.Element.Include(p => p.PlanetElement).Where(p => p.PlanetId == id).ToList();
                return _elements;
            }
        }
    }
}
