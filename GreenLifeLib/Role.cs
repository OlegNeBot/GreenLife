using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLifeLib
{
    public class Role
    {
        public int Id { get; set; }
        public string UserRole { get; set; }

        public List<User> User { get; set; }
    }
}
