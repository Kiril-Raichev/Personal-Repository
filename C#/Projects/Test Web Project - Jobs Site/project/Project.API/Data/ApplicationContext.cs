using Microsoft.EntityFrameworkCore;
using Project.API.Models;
using Project.API.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.API.Data
{
    public class ApplicationContext : DbContext
    {
        //constuctor
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {

        }

        //dbsets
        public DbSet<User> Users { get; set; }
        public DbSet<Article> Articles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            base.OnModelCreating(modelBuilder);
            //configure relations
            modelBuilder
               .Entity<User>()
               .HasData(
               new User
               {
                   Id = 1,
                   Username = "Ivan Ivanov",
                   Email = "Ivan_Ivanov@abv.bg",
                   Password = "123",
                   Job = ".NET",
                   Position = "Junior",
                   Role = UserRole.Admin,
               },
               new User
               {
                   Id = 2,
                   Username = "Georgi Georgiev",
                   Email = "Georgi_Georgiev@abv.bg",
                   Password = "123",
                   Job = "Java",
                   Position = "Senior",
                   Role = UserRole.Admin,
               }
               );
            modelBuilder
                .Entity<Article>()
                .HasData(
                new Article
                {
                    Id = 1,
                    Body = "",
                    CreatedBy = "Ivan Ivanov",
                    Job = ".NET",
                    Order = 1,
                    Position = "Junior",
                    Tags = new List<string>(),
                    Title = "Hiring .NET Developer",
                    Visibility = Visibility.Registered
                });
        }
    }
}
