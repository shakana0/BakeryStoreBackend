using Application.BakeryProduct.Queries.SearchBakeryProduct;
using Application.Tests.Infrastructure;
using Persistence;
using Xunit;

namespace Application.Tests.BakeryStoreTests.BakeryProductTests
{
    [Collection("QueryCollection")]
    public class SearchBakeryProductTests
    {
        private readonly BakeryStoreDbContext _bakeryStoreDbContext;

        public SearchBakeryProductTests(QueryTestFixture queryTestFixture)
        {
            _bakeryStoreDbContext = queryTestFixture.Context;
        }

        [Fact]
        public async Task SearchBakeryProductsQuery_BakeryProductsExists_ShouldReturnBakeryProductsViewModel()
        {
            // Arrange
            var bakeryProduct = _bakeryStoreDbContext.Products.FirstOrDefault();
            if (bakeryProduct == null)
            {
                throw new InvalidOperationException("No bakery products found in the database.");
            }
            var handler = new SearchBakeryProductHandler(_bakeryStoreDbContext);
            var command = new SearchBakeryProductQuery { Name = bakeryProduct.Name };

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Single(result.Results);
            Assert.Equal(10, result.PageSize);
            Assert.Equal(1, result.TotalPages);
            Assert.Equal(1, result.TotalItems);
            Assert.Equal(1, result.CurrentPage);
        }
    }
}