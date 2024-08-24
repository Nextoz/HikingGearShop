using HikingGearShop.Models;
using Microsoft.EntityFrameworkCore;

namespace HikingGearShop.Data
{
    public class ShopDBContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        public ShopDBContext(DbContextOptions<ShopDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasMany(o => o.Items)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            // Configuring a many-to-one relationship between CartItem and Product
            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.Product)
                .WithMany()
                .HasForeignKey(ci => ci.ProductId);

            // Index on Product Name (ensures uniqueness)
            modelBuilder.Entity<Product>()
                .HasIndex(p => p.Name)
                .IsUnique();

            // Composite index on Name and Price in Product
            modelBuilder.Entity<Product>()
                .HasIndex(p => new { p.Name, p.Price });

            // Index on Foreign Key (ProductId) in CartItem for faster lookups
            modelBuilder.Entity<CartItem>()
                .HasIndex(ci => ci.ProductId);


            // Seed Products
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Hiking Boots", Description = "Sturdy boots for mountain trails", Price = 129.99m, Stock = 50 },
                new Product { Id = 2, Name = "Backpack", Description = "Large capacity hiking backpack", Price = 89.99m, Stock = 30 },
                new Product { Id = 3, Name = "Tent", Description = "2-person lightweight tent", Price = 199.99m, Stock = 20 }
            );

            // Seed Orders (example without CartItems for simplicity)
            modelBuilder.Entity<Order>().HasData(
                new Order { Id = 1, OrderDate = DateTime.Now, TotalPrice = 129.99m, CustomerEmail = "customer1@example.com" }
            );

            // Seed CartItems (ensure the ProductId and OrderId match the above seeds)
            modelBuilder.Entity<CartItem>().HasData(
                new CartItem { Id = 1, ProductId = 1, Quantity = 1, Price = 129.99m }
            );

            base.OnModelCreating(modelBuilder);
        }

    }
}
