using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Persistence
{
    public class BakeryStoreDbContextFactory : IDesignTimeDbContextFactory<BakeryStoreDbContext>
    {
        public BakeryStoreDbContext CreateDbContext(string[] args)
        {
            // Build configuration
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../WebAPI")) // Path to WebAPI project
                .AddJsonFile("appsettings.json")
                .Build();

            // Get the connection string
            var connectionString = configuration.GetConnectionString("BakeryStoreDb");

            // Configure DbContext options
            var optionsBuilder = new DbContextOptionsBuilder<BakeryStoreDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new BakeryStoreDbContext(optionsBuilder.Options);
        }
    }
}