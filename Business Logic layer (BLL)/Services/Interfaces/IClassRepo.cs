using Business_Logic_layer__BLL_.DTOs.Classes;

namespace Business_Logic_layer__BLL_.Services.Interfaces
{
    public interface IClassRepo : IRepository<ClassDto, AddClassDto>
    {
        public long GetStudentCount( Guid id);
    }
}
