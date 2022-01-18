using AutoMapper;
using Business_Logic_layer__BLL_.DTOs.Classes;
using Business_Logic_layer__BLL_.Services.Interfaces;
using Business_Object_Layer__BOL_.Entities;
using Data_Access_Layer__DAL_;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_layer__BLL_.Services.Repos
{
    public class ClassRepo : IClassRepo
    {
        private readonly Context _context;
        private IMapper _mapper;
        public ClassRepo(Context context, IMapper _mapper)
        {
            this._context = context;
            this._mapper = _mapper;
        }

        public long GetStudentCount(Guid id)
        {
            var entity = _context.Classes.Include(x => x.Students).FirstOrDefault(x => x.Id == id);
            if (entity != null)
            {
                return entity.Students.Count();
            }
            return 0;
        }

        public void Create(AddClassDto request)
        {
            var entity = _mapper.Map<Classes>(request);
            entity.CreatedTime = DateTime.Now;
            _context.Classes.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var entity = _context.Classes.FirstOrDefault(x => x.Id == id);
            if(entity != null)
            {
                _context.Classes.Remove(entity);
                _context.SaveChanges();
            }
        }

        public List<ClassDto> GetAll()
        {
            var list = _context.Classes.ToList();
            return _mapper.Map<List<ClassDto>>(list);
        }

        public ClassDto GetById(Guid id)
        {
            var entity = _context.Classes.FirstOrDefault(x => x.Id == id);
            return _mapper.Map<ClassDto>(entity);
        }

        public void Update(ClassDto request)
        {
            var entity = _context.Classes.FirstOrDefault(x => x.Id == request.Id);
            entity.ClassName = request.ClassName;
            entity.ModifiedTime = DateTime.Now;
            _context.SaveChanges();

        }
    }
}
