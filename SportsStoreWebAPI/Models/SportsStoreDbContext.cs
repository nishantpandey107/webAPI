using System.Data.Entity;

namespace SportsStoreWebAPI.Models
{
    public class SportsStoreDbContext : DbContext
    {
        public SportsStoreDbContext() : base("MultiDBConnectionString") { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}