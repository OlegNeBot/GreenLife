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

        public int ElementId { get; set; }
        public List<Element> Element { get; set; }

        public Planet Planet { get; set; }

        #endregion

        #region [Methods]

        public static List<Element> GetElementsByPlanet(int id)
        {
            using (ApplicationContext db = new())
            {
                var allRels = db.PlanetElement.Where(p => p.Planet.Id == id).ToList();
                List<Element> Elements = new();
                foreach (PlanetElement rel in allRels)
                {
                    var element = db.Element.Where(e => e.Id == rel.ElementId).First();
                    Elements.Add(element);
                }
                return Elements;
            }
        }

        #endregion
    }
}
