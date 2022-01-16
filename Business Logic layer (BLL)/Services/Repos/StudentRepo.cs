using AutoMapper;
using Business_Logic_layer__BLL_.DTOs.Students;
using Business_Logic_layer__BLL_.Services.Interfaces;
using Business_Object_Layer__BOL_.Entities;
using Data_Access_Layer__DAL_;
using Microsoft.EntityFrameworkCore;

namespace Business_Logic_layer__BLL_.Services.Repos
{
    public class StudentRepo : IStudentRepo
    {
        private readonly Context _context;
        private IMapper _mapper;
        public StudentRepo(Context context, IMapper mapper)
        {
            this._mapper = mapper;
            this._context = context;
        }

        public int AverageAge()
        {
            var students = _context.Students.ToList();
            int StudentCount = students.Count();
            int TotalAge = 0;

            foreach (var student in students)
            {
                TotalAge += GetAge(student.DateOfBirth);
            }

            return TotalAge / StudentCount;
        }

        public void Create(AddStudentDto request)
        {
            var entity = _mapper.Map<Students>(request);
            entity.CreatedTime = DateTime.Now;
            _context.Students.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var entity = _context.Students.FirstOrDefault(x => x.Id == id);
            if (entity != null)
            {
                _context.Students.Remove(entity);
                _context.SaveChanges();
            }
        }

        public List<StudentDto> GetAll()
        {
            var list = _context.Students.ToList();
            return _mapper.Map<List<StudentDto>>(list);
        }

        public StudentDto GetById(Guid id)
        {
            var entity = _context.Students.FirstOrDefault(x => x.Id == id);
            return _mapper.Map<StudentDto>(entity);
        }

        public Tuple<string, string> GetClassCountryName(Guid id)
        {
            var entity = _context.Students.Include(x => x.Class).Include(x => x.Country).FirstOrDefault(x => x.Id == id);
            if (entity != null)
            {
                return new Tuple<string, string>(entity.Class.ClassName, entity.Country.Name);
            }
            return null;
        }

        public void Update(StudentDto request)
        {
            var oldEntity = _context.Students.FirstOrDefault(x => x.Id == request.Id);
            if (oldEntity != null)
            {
                oldEntity = _mapper.Map<Students>(request);
                oldEntity.ModifiedTime = DateTime.Now;
                _context.SaveChanges();
            }
        }

        private int GetAge(DateTime dob)
        {
            int age = 0;
            age = DateTime.Now.Subtract(dob).Days;
            age = age / 365;
            return age;
        }
    }
}
