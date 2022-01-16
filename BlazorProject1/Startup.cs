using AutoMapper;
using Business_Logic_layer__BLL_.MappingProfiles;
using Business_Logic_layer__BLL_.Services.Interfaces;
using Business_Logic_layer__BLL_.Services.Repos;
using Data_Access_Layer__DAL_;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BlazorProject1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddDbContext<Context>(opt => opt.UseSqlite("FileName=studentDB1", option =>
            {
                option.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
            }));

            var mapConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new Profiles());
            });
            IMapper mapper = mapConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddTransient<IClassRepo, ClassRepo>();
            services.AddTransient<ICountryRepo, CountryRepo>();
            services.AddTransient<IStudentRepo, StudentRepo>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
