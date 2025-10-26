using Microsoft.EntityFrameworkCore;
using WebApplication52.Domain.Entity;

namespace WebApplication52.Infrastructure.Database
{
    public class MainDatabase : DbContext
    {
        public MainDatabase(DbContextOptions<MainDatabase> options) : base(options)
        {
        }
        public DbSet<Customer> customers { get; set; }
        public DbSet<Product> products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().OwnsOne(c => c.Money);
            modelBuilder.Entity<Product>().OwnsOne(p => p.Money);
        }
    }
}
