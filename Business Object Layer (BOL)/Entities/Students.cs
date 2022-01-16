using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Object_Layer__BOL_.Entities
{
    public class Students : Entity
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Guid ClassId { get; set; }
        public Guid CountryId { get; set; }
        public Classes Class { get; set; }
        public Countries Country { get; set; }
    }
}
