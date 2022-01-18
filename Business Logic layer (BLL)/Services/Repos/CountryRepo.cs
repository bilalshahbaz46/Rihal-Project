using AutoMapper;
using Business_Logic_layer__BLL_.DTOs.Countries;
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
    public class CountryRepo : ICountryRepo
    {
        private readonly Context _context;
        private IMapper _mapper;
        public CountryRepo(Context context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public void Create(AddCountryDto request)
        {
            var entity = _mapper.Map<Countries>(request);
            entity.CreatedTime = DateTime.Now;
            _context.Countries.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var entity = _context.Countries.FirstOrDefault(x => x.Id == id);
            if (entity != null)
            {
                _context.Countries.Remove(entity);
                _context.SaveChanges();
            }
        }

        public List<CountryDto> GetAll()
        {
            var list = _context.Countries.ToList();
            return _mapper.Map<List<CountryDto>>(list);
        }

        public CountryDto GetById(Guid id)
        {
            var entity = _context.Countries.FirstOrDefault(x => x.Id == id);
            return _mapper.Map<CountryDto>(entity);
        }

        public long GetStudentCount(Guid id)
        {
            var entity = _context.Countries.Include(x => x.Students).FirstOrDefault(x => x.Id == id);
            if (entity != null)
            {
                return entity.Students.Count();
            }
            return 0;
        }

        public void Update(CountryDto request)
        {
            var entity = _context.Countries.FirstOrDefault(x => x.Id == request.Id);
            entity.Name = request.Name;
            entity.ModifiedTime = DateTime.Now;
            _context.SaveChanges();

        }
    }
}
