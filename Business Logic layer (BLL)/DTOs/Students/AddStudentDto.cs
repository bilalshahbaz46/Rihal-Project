using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_layer__BLL_.DTOs.Students
{
    public class AddStudentDto : Dto
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Guid ClassId { get; set; }
        public Guid CountryId { get; set; }
    }
}
