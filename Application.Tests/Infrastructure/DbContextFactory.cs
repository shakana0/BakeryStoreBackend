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
            var bakeryIngredients = DataProvider.GetBakeryIngredients();
            var bakeryCategory = DataProvider.GetBakeryCategories();
            var bakeryProductIngredient = DataProvider.GetBakeryProductIngredients();
            context.Products.AddRange(bakeryProducts);
            context.Ingredients.AddRange(bakeryIngredients);
            context.Categories.AddRange(bakeryCategory);
            context.ProductIngredients.AddRange(bakeryProductIngredient);

            context.SaveChanges();
            context.ChangeTracker.Clear();

            return context;
        }

        public static void Destroy(BakeryStoreDbContext context)
        {
            context.Database.EnsureDeleted();

            context.Dispose();
        }
    }
}