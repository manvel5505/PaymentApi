using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace WebApplication52.Infrastructure.Database
{
    public class MainDatabaseFactory : IDesignTimeDbContextFactory<MainDatabase>
    {
        public MainDatabase CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false)
            .Build();

            var optionsBuilder = new DbContextOptionsBuilder<MainDatabase>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString(nameof(MainDatabase)));

            return new MainDatabase(optionsBuilder.Options);
        }
    }
}
