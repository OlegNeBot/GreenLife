using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace GreenLifeLib
{
    public class PlanetElement
    {
        #region [Props]

        public int Id { get; set; }

        #endregion

        #region [Rels]

        public List<Element> Element { get; set; }
        public int PlanetId { get; set; }
        public Planet Planet { get; set; }

        #endregion

        #region [Methods]

        public static List<Element> GetElementsByPlanet(int id)
        {
            using (ApplicationContext db = new())
            {
                var elements = db.Element.Include(p => p.PlanetElement).Where(p => p.PlanetId == id).ToList();
                return elements;
            }
        }

        #endregion
    }
}
