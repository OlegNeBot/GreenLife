using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLifeLib
{
    public class Planet
    {
        public int Id { get; set; }
        public string PlanetRef { get; set; }

        public int StartPageId { get; set; }
        public StartPage StartPage { get; set; }
        public PlanetColors PlanetColors { get; set; }
        public PlanetElement PlanetElement { get; set; }

        public static Planet GetPlanet(int id)
        {
            using (ApplicationContext db = new())
            {
                var _planet = db.Planet.Where(p => p.StartPageId == id).First();
                return _planet;
            }
        }
    }
}
