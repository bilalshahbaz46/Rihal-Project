//using Business_Object_Layer__BOL_.Entities;
//using Faker;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Data_Access_Layer__DAL_
//{
//    public class DbInitializer
//    {
//        public static void Initialize(Context context)
//        {
//            context.Database.EnsureCreated();

//            //Classes
//            if (context.Classes.Any())
//            {

//            }
//            else
//            {
//                var classes = new Classes[]
//                {
//                    new Classes(){ Id = 1, ClassName = "Mathematic" },
//                    new Classes(){ Id = 2, ClassName = "Physics" },
//                    new Classes(){ Id = 3, ClassName = "Chemistry" },
//                    new Classes(){ Id = 4, ClassName = "Computer" }
//                };
//                foreach (var c in classes)
//                {
//                    context.Classes.Add(c);
//                }
//                context.SaveChanges();
//            }

//            //Countries
//            if (context.Countries.Any())
//            {

//            }
//            else
//            {
//                var countries = new Countries[]
//                {
//                    new Countries(){ Id = 1, Name = "Oman"},
//                    new Countries(){ Id = 2, Name = "Pakistan"},
//                    new Countries(){ Id = 3, Name = "Canada"}
//                };
//                foreach (var c in countries)
//                {
//                    context.Countries.Add(c);
//                }
//                context.SaveChanges();
//            }

//            //Students
//            if (context.Students.Any())
//            {

//            }
//            else
//            {
//                var students = new Students[]
//                {
//                    new Students(){ Id=1, Name = "Bilal Shahbaz", DateOfBirth = new DateTime(1997, 6, 4),
//                        Class = context.Classes.FirstOrDefault(x => x.Id == 4),
//                        ClassId = context.Classes.FirstOrDefault(x => x.Id==4).Id,
//                        Country = context.Countries.FirstOrDefault(x => x.Id == 2),
//                        CountryId = context.Countries.FirstOrDefault(x => x.Id == 2).Id
//                    },
//                    new Students(){ Id=2, Name = "Zain Toor", DateOfBirth = new DateTime(1998, 2, 14),
//                        Class = context.Classes.FirstOrDefault(x => x.Id == 1),
//                        ClassId = context.Classes.FirstOrDefault(x => x.Id == 1).Id,
//                        Country = context.Countries.FirstOrDefault(x => x.Id == 1),
//                        CountryId = context.Countries.FirstOrDefault(x => x.Id == 1).Id
//                    },
//                    new Students(){ Id=3, Name = "Mustafa Mureed", DateOfBirth = new DateTime(1996, 9, 1),
//                        Class = context.Classes.FirstOrDefault(x => x.Id == 2),
//                        ClassId = context.Classes.FirstOrDefault(x => x.Id == 2).Id,
//                        Country = context.Countries.FirstOrDefault(x => x.Id == 3),
//                        CountryId = context.Countries.FirstOrDefault(x => x.Id == 3).Id
//                    },
//                    new Students(){ Id=4, Name = "Muhammad Rizwan", DateOfBirth = new DateTime(1995, 4, 13),
//                        Class = context.Classes.FirstOrDefault(x => x.Id == 3),
//                        ClassId = context.Classes.FirstOrDefault(x => x.Id == 3).Id,
//                        Country = context.Countries.FirstOrDefault(x => x.Id == 2),
//                        CountryId = context.Countries.FirstOrDefault(x => x.Id == 2).Id
//                    },
//                    new Students(){ Id=5, Name = "Abdul Moez", DateOfBirth = new DateTime(1999, 12, 26),
//                        Class = context.Classes.FirstOrDefault(x => x.Id == 4),
//                        ClassId = context.Classes.FirstOrDefault(x => x.Id == 4).Id,
//                        Country = context.Countries.FirstOrDefault(x => x.Id == 1),
//                        CountryId = context.Countries.FirstOrDefault(x => x.Id == 1).Id
//                    }
//                };
//                foreach (var s in students)
//                {
//                    context.Students.Add(s);
//                }

//                //Adding Students in Classes

//                foreach (var c in context.Classes)
//                {
//                    foreach(var s in context.Students)
//                    {
//                        if(s.Class.Id == c.Id)
//                        {
//                            c.Students.Add(s);
//                        }

//                    }
//                }

//                //Adding Students in Countries

//                foreach (var c in context.Countries)
//                {
//                    foreach (var s in context.Students)
//                    {
//                        if (s.Country.Id == c.Id)
//                        {
//                            c.Students.Add(s);
//                        }

//                    }
//                }


//                context.SaveChanges();
//            }

//            return;

//        }
//    }
//}
