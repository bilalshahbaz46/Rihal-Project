using Data_Access_Layer__DAL_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class DataFetch
    {
        public void fetch()
        {
            var context = new Context();
            foreach(var s in context.Students)
            {
                Console.WriteLine($"Id: {s.Id}, Name: {s.Name}, DOB: {s.DateOfBirth.ToString()}, ClassId: {s.ClassId}, Class_Name: {s.Class.ClassName}, CountryId: {s.CountryId}, Country_Name: {s.Country.Name}");
            }
        }
    }
}
