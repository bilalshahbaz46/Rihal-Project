using Business_Object_Layer__BOL_.Entities;
using Faker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer__DAL_
{
    public class DbSeeder
    {
        public static void Initialize(Context context)
        {
            context.Database.EnsureCreated();
            var random = new Random();

            //Classes
            if (context.Classes.Any())
            {

            }
            else
            {
                var classes = new Classes[]
                {
                    new Classes(){ Id = Guid.NewGuid(), ClassName = "Mathematic", CreatedTime=DateTime.Now },
                    new Classes(){ Id = Guid.NewGuid(), ClassName = "Physics", CreatedTime=DateTime.Now },
                    new Classes(){ Id = Guid.NewGuid(), ClassName = "Chemistry", CreatedTime=DateTime.Now },
                    new Classes(){ Id = Guid.NewGuid(), ClassName = "Computer", CreatedTime=DateTime.Now }
                };
                foreach (var c in classes)
                {
                    context.Classes.Add(c);
                }
                context.SaveChanges();
            }


            //Countries
            if (context.Countries.Any())
            {

            }
            else
            {
                for(int i=0; i<10; i++)
                {
                    context.Countries.Add(new Countries()
                    {
                        Id = Guid.NewGuid(),
                        Name = Faker.Country.Name(),
                        CreatedTime = DateTime.Now
                    });
                }

                context.SaveChanges();
            }




            //Students

            if (context.Students.Any())
            {

            }
            else 
            {
                var classList = context.Classes.ToList();
                var countryList = context.Countries.ToList();

                var studentList = new List<Students>();

                for (int i = 0; i <= 10; i++)
                {
                    var countryIndex = random.Next(countryList.Count);
                    var classIndex = random.Next(classList.Count);

                    studentList.Add(new Students()
                    {
                        Id = new Guid(),
                        Name = Name.FullName(),
                        DateOfBirth = new DateTime(Faker.RandomNumber.Next(1995, 2000), Faker.RandomNumber.Next(1, 12), Faker.RandomNumber.Next(1, 28)),
                        Class = context.Classes.FirstOrDefault(x => x.Id == classList[classIndex].Id),
                        ClassId = classList[classIndex].Id,
                        Country = context.Countries.FirstOrDefault(x => x.Id == countryList[countryIndex].Id),
                        CountryId = countryList[countryIndex].Id,
                        CreatedTime = DateTime.Now
                    });
                }

                foreach (var s in studentList)
                {
                    context.Students.Add(s);
                }

                context.SaveChanges();


                //Adding Student in Classes

                foreach (var c in context.Classes)
                {
                    foreach (var s in context.Students)
                    {
                        if (s.Class.Id == c.Id)
                        {
                            c.Students.Add(s);
                        }

                    }
                }
                context.SaveChanges();

                //Adding Student in Countries

                foreach (var c in context.Countries)
                {
                    foreach (var s in context.Students)
                    {
                        if (s.Country.Id == c.Id)
                        {
                            c.Students.Add(s);
                        }

                    }
                }


                context.SaveChanges();
            }
        }
    }
}
