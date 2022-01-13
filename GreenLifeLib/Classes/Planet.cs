using System.Linq;

namespace GreenLifeLib
{
    public class Planet
    {
        #region [Props]

        public int Id { get; set; }
        public string PlanetRef { get; set; }

        #endregion

        #region [Rels]

        public int StartPageId { get; set; }
        public StartPage StartPage { get; set; }
        public PlanetColors PlanetColors { get; set; }
        public PlanetElement PlanetElement { get; set; }

        #endregion

        #region [Methods]

        public static Planet GetPlanet(int id)
        {
            using (ApplicationContext db = new())
            {
                var planet = db.Planet.Where(p => p.StartPageId == id).First();
                return planet;
            }
        }

        #endregion
    }
}
