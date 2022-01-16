using Business_Logic_layer__BLL_.DTOs.Countries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_layer__BLL_.Services.Interfaces
{
    public interface ICountryRepo : IRepository<CountryDto, AddCountryDto>
    {
        public long GetStudentCount(Guid id);
    }
}
