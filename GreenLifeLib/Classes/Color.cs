using System.Collections.Generic;
using System.Linq;

namespace GreenLifeLib
{
    public class Color
    {
        #region [Props]

        public int Id { get; set; }
        public string ColorName { get; set; }

        #endregion

        #region [Rels]

        public int PlanetId { get; set; }
        public List<PlanetColors> PlanetColors { get; set; }

        #endregion

        #region [Methods]

        public static List<Color> GetColors()
        {
            using (ApplicationContext db = new())
            {
                var colors = db.Color.ToList();
                return colors;
            }
        }

        #endregion
    }
}
