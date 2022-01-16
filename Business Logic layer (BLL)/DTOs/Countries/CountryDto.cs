using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_layer__BLL_.DTOs.Countries
{
    public class CountryDto : Dto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
