using Core.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Product>()
            .HasOne(p => p.Category)
            .WithMany(t => t.Products)
            .HasForeignKey(p => p.CategoryId);

            builder.Entity<User>().HasData(
                new User { Id = 1, Password = "1234", Email = "basya" }
                );

            builder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Bakery", CreatedAt = DateTime.Now },
                new Category { Id = 2, Name = "Dairy", CreatedAt = DateTime.Now },
                new Category { Id = 3, Name = "Cereals", CreatedAt = DateTime.Now },
                new Category { Id = 4, Name = "Alcohol", CreatedAt = DateTime.Now }
                );

            builder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Bread", Number = 10, Price = 15, CategoryId = 1, CreatedAt = DateTime.Now },
                new Product { Id = 2, Name = "Bun", Number = 8, Price = 25, CategoryId = 1, CreatedAt = DateTime.Now },
                new Product { Id = 3, Name = "Eggs", Number = 100, Price = 2, CategoryId = 2, CreatedAt = DateTime.Now },
                new Product { Id = 4, Name = "Milk", Number = 20, Price = 35, CategoryId = 2, CreatedAt = DateTime.Now },
                new Product { Id = 5, Name = "Oatmeal", Number = 14, Price = 40, CategoryId = 3, CreatedAt = DateTime.Now },
                new Product { Id = 6, Name = "Buckwheat", Number = 12, Price = 35, CategoryId = 3, CreatedAt = DateTime.Now },
                new Product { Id = 7, Name = "Poridge", Number = 6, Price = 39, CategoryId = 3, CreatedAt = DateTime.Now },
                new Product { Id = 8, Name = "Brandy", Number = 15, Price = 200, CategoryId = 4, CreatedAt = DateTime.Now },
                new Product { Id = 9, Name = "Wodka", Number = 11, Price = 100, CategoryId = 4, CreatedAt = DateTime.Now },
                new Product { Id = 10, Name = "Wine", Number = 17, Price = 150, CategoryId = 4, CreatedAt = DateTime.Now },
                new Product { Id = 11, Name = "Beer", Number = 40, Price = 50, CategoryId = 4, CreatedAt = DateTime.Now }
                );
        }
    }
}
