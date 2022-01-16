using BlazorProject1.Data;
using Data_Access_Layer__DAL_;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace BlazorProject1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            //Adding Seeder Data
            CreateDbIfNotExists(host);

            host.Run();

            //using var dbcontext = new Context();

            //var student = dbcontext.Students.ToList();
            //var classes = dbcontext.Classes.ToList();
            //var countries = dbcontext.Countries.ToList();

            //foreach (var s in dbcontext.Students)
            //{
            //    Console.WriteLine($"StudentID: {s.Id}, StudentName: {s.Name}, DOB: {s.DateOfBirth.ToString()}, ClassName: {s.Class.ClassName}, CountryName: {s.Country.Name}");
            //}
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });


        private static void CreateDbIfNotExists(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<Context>();
                    DbSeeder.Initialize(context);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occured creating the DB.");
                }
            }
        }
    }
}
