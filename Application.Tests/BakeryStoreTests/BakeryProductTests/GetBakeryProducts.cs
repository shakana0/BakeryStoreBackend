using Application.BakeryProduct.Queries.GetBakeryProduct;
using Application.Tests.Infrastructure;
using AutoMapper;
using Persistence;
using Xunit;

namespace Application.Tests.BakeryProductTests
{

    [Collection("QueryCollection")]
    public class GetBakeryProductsQueryTests
    {
        private readonly IMapper _mapper;
        private readonly BakeryStoreDbContext _bakeryStoreDbContext;

        public GetBakeryProductsQueryTests(QueryTestFixture queryTestFixture)
        {
            _mapper = queryTestFixture.Mapper;
            _bakeryStoreDbContext = queryTestFixture.Context;
        }

        [Fact]
        public async Task GetBakeryProductsQuery_BakeryProductsExists_ShouldReturnBakeryProductsViewModel()
        {
            // Arrange
            var bakeryProduct = _bakeryStoreDbContext.Products.FirstOrDefault();
            if (bakeryProduct == null)
            {
                throw new InvalidOperationException("No bakery products found in the database.");
            }
            var handler = new GetBakeryProductHandler(_bakeryStoreDbContext, _mapper);
            var command = new GetBakeryProductQuery { Id = bakeryProduct.Id };
            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(bakeryProduct.Id, result.Id);
            Assert.Equal(bakeryProduct.Name, result.Name);
            Assert.Equal(bakeryProduct.Description, result.Description);
            Assert.Equal(bakeryProduct.Price, result.Price);
            Assert.Equal(bakeryProduct.Stock, result.Stock);
            Assert.Equal(bakeryProduct.CategoryId, result.CategoryId);
        }
    }
}