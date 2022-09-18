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
                    LastName = "Geirgiev",
                    Email = "Georgi_georgiev@abv.bg",
                    Password = "1223",
                    Role = UserRole.Student,
                    Photo= "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Ftse3.mm.bing.net%2Fth%3Fid%3DOIP.BxO--7Fr7JssN9Tj9wII_QHaLG%26pid%3DApi&f=1"
                }) ;

            modelBuilder
                .Entity<Course>()
                .HasData(
                new Course
                {
                    Id = 1,
                    Title = "Course no1",
                    Description = "The best course in here, trust",
                    Duration = 110,
                    ImgSource = "~/img/test1.jpg",
                    Visibility = CourseVisibility.Public,
                    Sections = new List<Section>(),
                    CreatedBy = "Ivan Ivanov"
                },
                  new Course
                  {
                      Id = 2,
                      Title = "Course no2",
                      Description = "The second best course in here, trust",
                      Duration = 155,
                      ImgSource = "~/img/test2.jpg",
                      Visibility = CourseVisibility.Private,
                      Sections = new List<Section>(),
                      CreatedBy = "Ivan Ivanov"
                  },
                  new Course
                  {
                      Id = 3,
                      Title = "Course no3",
                      Description = "The third best course in here, trust",
                      Duration = 198,
                      ImgSource = "https://st.depositphotos.com/1075946/1820/i/450/depositphotos_18206843-stock-photo-group-of-young-in-training.jpg",
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
                    Title = "First test section",
                    Content = "Description of the first test section",
                    Order = 1,
                    CourseId = 1
                },
                 new Section
                 {
                     Id = 2,
                     Title = "Second test section",
                     Content = "Description of the second test section",
                     Order = 2,
                     CourseId = 1
                 },
                  new Section
                  {
                      Id = 3,
                      Title = "Third test section",
                      Content = "Description of the third test section",
                      Order = 3,
                      CourseId = 1
                  }
                );

            modelBuilder.Entity<UserCourse>().HasData(new UserCourse { CourseId = 2, UserId = 2 });

            modelBuilder.Entity<UserCourse>().HasKey(uc => new { uc.CourseId, uc.UserId });
        }
    }
}
