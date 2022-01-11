using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLifeLib
{
    public class Element
    {
        public int Id { get; set; }
        public string ElemDescription { get; set; }
        public string ElemRef { get; set; }

        public int PlanetId { get; set; }
        public List<PlanetElement> PlanetElement { get; set; }

        public static List<Element> GetElements()
        {
            using (ApplicationContext db = new())
            {
                var _elements = db.Element.ToList();
                return _elements;
            }
        }
    }
}
