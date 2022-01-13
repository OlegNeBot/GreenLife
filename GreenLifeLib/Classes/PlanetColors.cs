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

        public List<Color> Color { get; set; }
        public int PlanetId { get; set; }
        public Planet Planet { get; set; }

        #endregion

        #region [Methods]

        public static List<Color> GetColorsByPlanet(int id)
        {
            using (ApplicationContext db = new())
            {
                var colors = db.Color.Include(p => p.PlanetColors).Where(p => p.PlanetId == id).ToList();
                return colors;
            }
        }

        #endregion
    }
}
