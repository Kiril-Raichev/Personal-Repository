using Poodle_E_Learning_Platform.Models;
using Microsoft.EntityFrameworkCore;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //configure relations
            modelBuilder
                .Entity<User>()
                .HasData(new User
                {
                    Id = 1,
                    FirstName = "Ivan",
                    LastName = "Ivanov",
                    Email = "Ivan_Ivanov@abv.bg",
                    Password = "123",
                    Role = UserRole.Teacher
                }
                );
        }
    }
}
