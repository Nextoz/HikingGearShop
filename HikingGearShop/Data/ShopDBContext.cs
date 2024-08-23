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
            modelBuilder.Entity<Product>().HasData(
             //TODO define index and maybe seed data here 
            );
        }

    }
}
