using Forum1.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Forum.Db
{
    public class ForumDbContext : DbContext
    {
        public ForumDbContext(DbContextOptions options)
            : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var users = new List<User>();

            users.Add(new User
            {
                Id = 1,
                FirstName = "Ivan",
                LastName = "Todorov",
                Username = "Ivancho",
                Email = "ivan_todorov@yahoo.com",
                Role = Roles.Admin

            });
            users.Add(new User
            {
                Id = 2,
                FirstName = "Peter",
                LastName = "Shulev",
                Username = "Petercho",
                Email = "peter_shulev@yahoo.com",
                Role = Roles.LoggedUser

            });
            users.Add(new User
            {
                Id = 3,
                FirstName = "Stoimen",
                LastName = "Petrov",
                Username = "Stoimencho",
                Email = "stoimen_Petrov@google.com",
                Role = Roles.LoggedUser
            });

            modelBuilder.Entity<User>().HasData(users);

            var posts = new List<Post>();

            posts.Add(new Post
            {
                Id = 1,

                Title = "Vacation",
                Content = "Trip to Burgas",
                UserId = 1,
                Comments = new List<Comment>()
            });
            posts.Add(new Post
            {
                Id = 2,

                Title = "Vacation2",
                Content = "Trip to Varna",
                UserId = 2,
                Comments = new List<Comment>()
            });
            posts.Add(new Post
            {
                Id = 3,

                Title = "Vacation3",
                Content = "Trip to Sozopol",
                UserId = 3,
                Comments = new List<Comment>()
            });

            modelBuilder.Entity<Post>().HasData(posts);

            base.OnModelCreating(modelBuilder);

            //Configure relations
        }
    }
}
