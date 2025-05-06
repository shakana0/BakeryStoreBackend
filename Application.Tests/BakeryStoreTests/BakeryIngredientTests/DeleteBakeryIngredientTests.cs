using Application.BakeryIngredient.Commands.DeleteBakeryIngredient;
using Application.Tests.Infrastructure;
using Persistence;
using Xunit;

namespace Application.Tests.BakeryStoreTests.BakeryIngredientTests.DeleteBakeryIngredientTests
{
    [Collection("QueryCollection")]
    public class DeleteBakeryIngredientTests
    {
        private readonly BakeryStoreDbContext _bakeryStoreDbContext;
        public DeleteBakeryIngredientTests(QueryTestFixture queryTestFixture)
        {
            _bakeryStoreDbContext = queryTestFixture.Context;
        }

        [Fact]
        public async Task DeleteBakeryIngredient_BakeryIngredientExists_ShouldRemoveIngredientFromDatabase()
        {
            // Arrange
            var bakeryIngredient = _bakeryStoreDbContext.Ingredients.FirstOrDefault();
            if (bakeryIngredient == null)
            {
                throw new InvalidOperationException("No bakery ingredients found in the database.");
            }

            var handler = new DeleteBakeryIngredientHandler(_bakeryStoreDbContext);
            var command = new DeleteBakeryIngredientCommand { Id = bakeryIngredient.Id };

            // Act
            await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.Null(_bakeryStoreDbContext.Ingredients.FirstOrDefault(em => em.Id == bakeryIngredient.Id));
        }
    }
}