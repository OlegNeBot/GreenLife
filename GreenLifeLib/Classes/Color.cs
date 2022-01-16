using System.Collections.Generic;
using System.Linq;

namespace GreenLifeLib
{
    public class Color : PlanetParts
    {
        #region [Fields]

        private List<Color> Colors;

        #endregion

        #region [Props]

        public override int Id { get; set; }
        public override string Name { get; set; }
        public override string Content { get; set; }

        #endregion

        #region [Rels]

        public List<PlanetColors> PlanetColors { get; set; }

        #endregion

        #region [Methods]

        internal override void GetAll()
        {
            using (ApplicationContext db = new())
            {
                Colors = db.Color.ToList();
            }
        }

        public static List<Color> GetColors()
        {
            Color clr = new();
            clr.GetAll();
            return clr.Colors;
        }

        #endregion
    }
}
