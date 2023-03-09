using Microsoft.EntityFrameworkCore;
using Poodle_E_Learning_Platform.Models;
using System.Collections.Generic;

namespace Poodle_E_Learning_Platform.Data
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
        public DbSet<Course> Courses { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<UserCourse> UserCourse { get; set; }
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
                    FirstName = "Ivan",
                    LastName = "Ivanov",
                    Email = "Ivan_Ivanov@abv.bg",
                    Password = "123",
                    Role = UserRole.Teacher,
                    Photo = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fstatic.photocdn.pt%2Fimages%2Farticles%2F2019%2F08%2F07%2Fimages%2Farticles%2F2019%2F07%2F31%2Fbest_linkedin_photos.jpg&f=1&nofb=1"
                },
                new User
                {
                    Id = 2,
                    FirstName = "Georgi",
                    LastName = "Georgiev",
                    Email = "Georgi_georgiev@abv.bg",
                    Password = "123",
                    Role = UserRole.Student,
                    Photo = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Ftse3.mm.bing.net%2Fth%3Fid%3DOIP.BxO--7Fr7JssN9Tj9wII_QHaLG%26pid%3DApi&f=1"
                });

            modelBuilder
                .Entity<Course>()
                .HasData(
                new Course
                {
                    Id = 1,
                    Title = "C# Programming Basics",
                    Description = "Interested in programming, but you have no idea where to start? Try out this free short intro course to see if the C# language is for you!",
                    Duration = 30,
                    ImgSource = "https://st.depositphotos.com/1075946/1820/i/450/depositphotos_18206843-stock-photo-group-of-young-in-training.jpg",
                    Visibility = CourseVisibility.Public,
                    Sections = new List<Section>(),
                    CreatedBy = "Ivan Ivanov"
                },
                new Course
                {
                    Id = 2,
                    Title = "Graphic Design",
                    Description = "Sign up now and to learn from our best teacher how to create industry competitive designs that will shock everyone around you!",
                    Duration = 155,
                    ImgSource = "~/img/test2.jpg",
                    Visibility = CourseVisibility.Private,
                    Sections = new List<Section>(),
                    CreatedBy = "Ivan Ivanov"
                },
                new Course
                {
                    Id = 3,
                    Title = "Physical Training",
                    Description = "If your goal is to get in shape and fit then look no more, with a few fast sessions you will have all the information you need to complete your goals!",
                    Duration = 110,
                    ImgSource = "~/img/test1.jpg",
                    Visibility = CourseVisibility.Public,
                    Sections = new List<Section>(),
                    CreatedBy = "Ivan Ivanov"
                }
                );
            modelBuilder
              .Entity<Section>()
              .HasData(
                new Section
                {
                    Id = 1,
                    Title = "Hello World",
                    Content = "In this section you will learn how to install the necessary programs and run your first real code.",
                    Order = 1,
                    CourseId = 1
                },
                 new Section
                 {
                     Id = 2,
                     Title = "Basic Operations",
                     Content = "Learn all the different operations you can put in your code.",
                     Order = 2,
                     CourseId = 1
                 },
                  new Section
                  {
                      Id = 3,
                      Title = "Loops and cycles",
                      Content = "Here you are introduced to the different ways you can use code to create cycles and manipulate them.",
                      Order = 3,
                      CourseId = 1
                  }
                );

            modelBuilder.Entity<UserCourse>().HasData(new UserCourse { CourseId = 2, UserId = 2 });

            modelBuilder.Entity<UserCourse>().HasKey(uc => new { uc.CourseId, uc.UserId });
        }
    }
}
