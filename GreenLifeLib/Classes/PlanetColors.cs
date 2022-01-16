using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace GreenLifeLib
{
    public class PlanetColors
    {
        #region [Props]

        public int Id { get; set; }

        #endregion

        #region [Rels]

        public int ColorId { get; set; }
        public List<Color> Color { get; set; }

        public Planet Planet { get; set; }

        #endregion

        #region [Methods]

        public static List<Color> GetColorsByPlanet(int id)
        {
            using (ApplicationContext db = new())
            {
                var allRels = db.PlanetColors.Where(p => p.Planet.Id == id).ToList();
                List<Color> Colors = new();
                foreach (PlanetColors rel in allRels)
                {
                    var color = db.Color.Where(e => e.Id == rel.ColorId).First();
                    Colors.Add(color);
                }
                return Colors;
            }
        } 

        #endregion
    }
}
