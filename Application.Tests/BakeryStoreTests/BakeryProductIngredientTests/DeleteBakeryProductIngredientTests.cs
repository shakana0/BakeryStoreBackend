using Application.BakeryProductIngredient.Commands.DeleteBakeryProductIngredient;
using Application.Tests.Infrastructure;
using Persistence;
using Xunit;

namespace Application.Tests.BakeryStoreTests.BakeryProductIngredientTests
{
    [Collection("QueryCollection")]
    public class DeleteBakeryProductIngredientTests
    {
        private readonly BakeryStoreDbContext _bakeryStoreDbContext;
        public DeleteBakeryProductIngredientTests(QueryTestFixture queryTestFixture)
        {
            _bakeryStoreDbContext = queryTestFixture.Context;
        }

        [Fact]
        public async Task DeleteBakeryProductIngredient_BakeryProductIngredientExists_ShouldReturnTrue()
        {
            // Arrange
            var bakeryProductIngredient = _bakeryStoreDbContext.ProductIngredients.FirstOrDefault();
            if (bakeryProductIngredient == null)
            {
                throw new InvalidOperationException("No bakery ingredients found in the database.");
            }
            var handler = new DeleteBakeryProductIngredientHandler(_bakeryStoreDbContext);
            var command = new DeleteBakeryProductIngredientCommand { Id = bakeryProductIngredient.Id };

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.Null(_bakeryStoreDbContext.ProductIngredients.FirstOrDefault(em => em.Id == bakeryProductIngredient.Id));
        }
    }
}