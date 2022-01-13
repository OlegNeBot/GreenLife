using System.Collections.Generic;
using System.Linq;

namespace GreenLifeLib
{
    public class Element
    {
        #region [Props]

        public int Id { get; set; }
        public string ElemDescription { get; set; }
        public string ElemRef { get; set; }

        #endregion

        #region [Rels]

        public int PlanetId { get; set; }
        public List<PlanetElement> PlanetElement { get; set; }

        #endregion

        #region [Methods]

        public static List<Element> GetElements()
        {
            using (ApplicationContext db = new())
            {
                var elements = db.Element.ToList();
                return elements;
            }
        }

        #endregion
    }
}
