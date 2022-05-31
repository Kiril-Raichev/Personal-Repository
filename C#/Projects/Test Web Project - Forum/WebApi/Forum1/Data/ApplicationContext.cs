using Forum1.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Forum1.Data
{
    public class ApplicationContext : DbContext
    {

        //constructor
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
             : base(options)
        {

        }


        //dbsets - таблиците в SQL - уникални елементи в тях
        public DbSet<User> Users { get; set; }
        public DbSet<User> BlockedUsers { get; set; }   
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Reaction> PostReactions { get; set; }

        //override model configuration
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           
            //configure relations
            modelBuilder
                    .Entity<Reaction>()
                    .HasOne(reaction => reaction.Post)
                    .WithMany(post => post.PostReactions)
                    .HasForeignKey(reaction => reaction.PostId)
                    .OnDelete(DeleteBehavior.NoAction);


            modelBuilder
                    .Entity<Reaction>()
                    .HasOne(reaction => reaction.User)
                    .WithMany(user => user.PostReactions)
                    .HasForeignKey(reaction => reaction.UserId)
                    .OnDelete(DeleteBehavior.NoAction);



            modelBuilder
                     .Entity<Comment>()
                     .HasOne(comment => comment.Post)
                     .WithMany(post => post.Comments)
                     .HasForeignKey(comment => comment.PostId)
                     .OnDelete(DeleteBehavior.NoAction);


            modelBuilder
                     .Entity<Comment>()
                     .HasOne(comment => comment.User)
                     .WithMany(user => user.Comments)
                     .HasForeignKey(comment => comment.UserId)
                     .OnDelete(DeleteBehavior.NoAction);
            
            //seed our database
            var users = new List<User>();
            //add users
            users.Add(new User
            {
                Id = 1,
                FirstName = "Ivan",
                LastName = "Todorov",
                Username = "Ivancho",
                Email = "ivan_todorov@yahoo.com",
                Role = Roles.Admin,


            });
            users.Add(new User
            {
                Id = 2,
                FirstName = "Peter",
                LastName = "Shulev",
                Username = "Petercho",
                Email = "peter_shulev@yahoo.com",
                Role = Roles.Registered

            });
            users.Add(new User
            {
                Id = 3,
                FirstName = "Stoimen",
                LastName = "Petrov",
                Username = "Stoimencho",
                Email = "stoimen_Petrov@google.com",
                Role = Roles.Registered
            });
            modelBuilder.Entity<User>().HasData(users);
            //add blockedusers
           
            var blockedUsers = new List<User>();
            blockedUsers.Add(new User
            {
                Id = 4,
                FirstName = "Georgi",
                LastName = "Penev",
                Username = "Gosheto",
                Email = "georgi_penev@yahoo.com",
                Role = Roles.Admin,


            });
            blockedUsers.Add(new User
            {
                Id = 5,
                FirstName = "Todor",
                LastName = "Dragunov",
                Username = "Tosheto",
                Email = "todor_dragunov@yahoo.com",
                Role = Roles.Registered

            });
            blockedUsers.Add(new User
            {
                Id = 6,
                FirstName = "Dancho",
                LastName = "Vazov",
                Username = "Daneto",
                Email = "dancho_vazov@google.com",
                Role = Roles.Registered
            });
            modelBuilder.Entity<User>().HasData(blockedUsers);


            //seed database
            var posts = new List<Post>();

            //add posts
            posts.Add(new Post
            {
                Id = 1,

                Title = "Vacation",
                Content = "Trip to Burgas",
                UserId = 1,
            });
            posts.Add(new Post
            {
                Id = 2,

                Title = "Vacation2",
                Content = "Trip to Varna",
                UserId = 2
            });
            posts.Add(new Post
            {
                Id = 3,

                Title = "Vacation3",
                Content = "Trip to Sozopol",
                UserId = 3
            });
            modelBuilder.Entity<Post>().HasData(posts);

        }




    }
}
