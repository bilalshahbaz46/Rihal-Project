using Business_Object_Layer__BOL_.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer__DAL_
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite("FileName=studentDB1", option =>
        //    {
        //        option.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
        //    });
        //    base.OnConfiguring(optionsBuilder);
        //}

        public DbSet<Classes> Classes { get; set; }
        public DbSet<Countries> Countries { get; set; }
        public DbSet<Students> Students { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Students>(entity =>
            {
                entity.ToTable("students");
                entity.HasKey(x => x.Id);
                entity.HasOne(x => x.Class).WithMany(x => x.Students).HasForeignKey("class_id");
                entity.HasOne(x => x.Country).WithMany(x => x.Students).HasForeignKey("country_id");

                entity.Property(x => x.Id).HasColumnName("id");
                entity.Property(x => x.Name).HasColumnName("name");
                entity.Property(x => x.DateOfBirth).HasColumnName("date_of_birth");
            });

            modelBuilder.Entity<Classes>(entity =>
            {
                entity.ToTable("classes");
                entity.HasKey(x => x.Id);
                entity.HasMany(x => x.Students).WithOne(x => x.Class);

                entity.Property(x => x.Id).HasColumnName("id");
                entity.Property(x => x.ClassName).HasColumnName("class_name");
            });

            modelBuilder.Entity<Countries>(entity =>
            {
                entity.ToTable("countries");
                entity.HasKey(x => x.Id);
                entity.HasMany(x => x.Students).WithOne(x => x.Country);

                entity.Property(x => x.Id).HasColumnName("id");
                entity.Property(x => x.Name).HasColumnName("name");
            });
        }
    }
}
