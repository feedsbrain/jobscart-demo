using JobsCart.Models;
using Microsoft.EntityFrameworkCore;

namespace JobsCart.DAL {
    public class JobsDbContext : DbContext {
        public JobsDbContext (DbContextOptions<JobsDbContext> options) : base (options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<PriceRule> PriceRules { get; set; }
    }
}