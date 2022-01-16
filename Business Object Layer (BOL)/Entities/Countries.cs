using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Object_Layer__BOL_.Entities
{
    public class Countries : Entity
    {
        public string Name { get; set; }
        public ICollection<Students> Students { get; set; }
    }
}
