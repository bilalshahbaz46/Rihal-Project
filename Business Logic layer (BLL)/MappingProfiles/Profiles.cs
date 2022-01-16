using AutoMapper;
using Business_Logic_layer__BLL_.DTOs.Classes;
using Business_Logic_layer__BLL_.DTOs.Countries;
using Business_Logic_layer__BLL_.DTOs.Students;
using Business_Object_Layer__BOL_.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_layer__BLL_.MappingProfiles
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            //Classes
            CreateMap<Classes, ClassDto>().ReverseMap();
            CreateMap<Classes, AddClassDto>().ReverseMap();

            //Countries
            CreateMap<Countries, CountryDto>().ReverseMap();
            CreateMap<Countries, AddCountryDto>().ReverseMap();

            //Students
            CreateMap<Students, StudentDto>().ReverseMap();
            CreateMap<Students, AddStudentDto>().ReverseMap();
        }

    }
}
