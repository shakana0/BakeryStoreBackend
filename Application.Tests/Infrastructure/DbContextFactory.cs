using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Tests.Infrastructure
{
    public class DbContextFactory
    {
        public static BakeryStoreDbContext Create()
        {
            var options = new DbContextOptionsBuilder<BakeryStoreDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new BakeryStoreDbContext(options);

            var bakeryProducts = DataProvider.GetBakeryProducts();
            context.Products.AddRange(bakeryProducts);


            context.SaveChanges();

            return context;
        }

        public static void Destroy(BakeryStoreDbContext context)
        {
            context.Database.EnsureDeleted();

            context.Dispose();
        }
    }
}