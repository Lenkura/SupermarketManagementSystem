using CoreBusiness;
using Microsoft.EntityFrameworkCore;

namespace Plugins.DataStore.SQL
{
    public class MarketContext : DbContext
    {
        public MarketContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Transaction> Transaction { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryID);

            //seed data
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryID = 1, Name = "Beverage", Description = "Beverage" },
                new Category { CategoryID = 2, Name = "Bakery", Description = "Bakery" },
                new Category { CategoryID = 3, Name = "Meat", Description = "Meat" } 
            );

            modelBuilder.Entity<Product>().HasData(
                new Product { ProductID = 1, CategoryID = 1, Name = "Iced Tea", Price = 1.99, Quantity = 100 },
                new Product { ProductID = 2, CategoryID = 1, Name = "Ginger Ale", Price = 4.99, Quantity = 200 },
                new Product { ProductID = 3, CategoryID = 2, Name = "Wholemeal Bread", Price = 2.00, Quantity = 300 },
                new Product { ProductID = 4, CategoryID = 2, Name = "White Bread", Price = 1.00, Quantity = 300 },
                new Product { ProductID = 5, CategoryID = 3, Name = "Lamb", Price = 15.00, Quantity = 25 },
                new Product { ProductID = 6, CategoryID = 3, Name = "Beef", Price = 9.50, Quantity = 50 }
            );



        }
    }
}