using Microsoft.EntityFrameworkCore;
using DAL.Models;

namespace DAL.Data
{
    public class ShoppingContext : DbContext
    {
        public ShoppingContext() : base()
        {
        }
        public ShoppingContext(DbContextOptions<ShoppingContext> options)
           : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<SuperMarket> SuperMarkets { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrdersDetails { get; set; }
        public DbSet<Product> Products { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Customer>().HasKey(c => c.Id);
            builder.Entity<SuperMarket>().HasKey(s => s.Id);
            builder.Entity<Order>().HasKey(o => o.Id);
            builder.Entity<OrderDetail>().HasKey(od => od.Id);
            builder.Entity<Product>().HasKey(p => p.Id);

            builder.Entity<Customer>()
                .HasData(
                new Customer()
                {
                    Id = 1,
                    FName = "Ivan",
                    LName = "Ivanov",
                    Address = "Random st., Test Avenue",
                    Discount = 0,
                });
            builder.Entity<SuperMarket>()
                .HasData(
                new SuperMarket()
                {
                    Id = 1,
                    Name = "Kaufland",
                    Address = "Kaufland st.",
                });
            builder.Entity<Order>()
                .HasData(
                new Order()
                {
                    Id = 1,
                    CustomerId = 1,
                    SuperMarketId = 1,
                    OrderDate = new DateTime(02 / 03 / 2022)
                });
            builder.Entity<OrderDetail>()
                .HasData(
                new OrderDetail()
                {
                    Id = 1,
                    OrderId = 1,
                    ProductId = 1,
                    Quantity = 1,
                });
            builder.Entity<Product>()
                .HasData(
                new Product()
                {
                    Id = 1,
                    Name = "Milk",
                    Price = 1,
                });
            base.OnModelCreating(builder);

            //builder.Entity<UserCourse>().HasData(new UserCourse { CourseId = 2, UserId = 2 });
            //builder.Entity<UserCourse>().HasKey(uc => new { uc.CourseId, uc.UserId });
        }

    }
}