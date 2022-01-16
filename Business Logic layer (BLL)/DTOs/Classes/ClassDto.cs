using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_layer__BLL_.DTOs.Classes
{
    public class ClassDto : Dto
    {
        public Guid Id { get; set; }
        public string ClassName { get; set; }
    }
}
