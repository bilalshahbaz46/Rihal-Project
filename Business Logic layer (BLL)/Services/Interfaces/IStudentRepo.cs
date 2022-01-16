using Business_Logic_layer__BLL_.DTOs.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_layer__BLL_.Services.Interfaces
{
    public interface IStudentRepo : IRepository<StudentDto, AddStudentDto>
    {
        public Tuple<string,string> GetClassCountryName(Guid id);
        public int AverageAge();
    }
}
