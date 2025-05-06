using Application.BakeryProduct.Commands.DeleteBakeryProduct;
using Application.Tests.Infrastructure;
using AutoMapper;
using Persistence;
using Xunit;

namespace Application.Tests.BakeryStoreTests
{
    [Collection("QueryCollection")]
    public class DeleteBakeryProductTests
    {
        private readonly BakeryStoreDbContext _bakeryStoreDbContext;
        public DeleteBakeryProductTests(QueryTestFixture queryTestFixture)
        {
            _bakeryStoreDbContext = queryTestFixture.Context;
        }

        [Fact]
        public async Task DeleteBakeryProduct_BakeryProductsExists_ShouldRemoveProductFromDatabase()
        {
            // Arrange
            var bakeryProduct = _bakeryStoreDbContext.Products.FirstOrDefault();
            if (bakeryProduct == null)
            {
                throw new InvalidOperationException("No bakery products found in the database.");
            }

            var handler = new DeleteBakeryProductHandler(_bakeryStoreDbContext);
            var command = new DeleteBakeryProductCommand { Id = bakeryProduct.Id };

            // Act
            await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.Null(_bakeryStoreDbContext.Products.FirstOrDefault(em => em.Id == bakeryProduct.Id));

        }
    }
}