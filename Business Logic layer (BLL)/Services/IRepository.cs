using Business_Logic_layer__BLL_.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_layer__BLL_.Services
{
    public interface IRepository<T,C> 
        where T : Dto
        where C : Dto
    {
        List<T> GetAll();
        T GetById(Guid id);
        void Update(T request);
        void Create(C request);
        void Delete(Guid id);
    }
}
