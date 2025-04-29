using Application.BakeryProduct.Commands.UpdateBakeryProduct;
using Application.Tests.Infrastructure;
using AutoMapper;
using Persistence;
using Xunit;

namespace Application.Tests.BakeryProductTests
{
    [Collection("QueryCollection")]
    public class UpdateBakeryProductTests
    {
        private readonly IMapper _mapper;
        private readonly BakeryStoreDbContext _bakeryStoreDbContext;

        public UpdateBakeryProductTests(QueryTestFixture queryTestFixture)
        {
            _mapper = queryTestFixture.Mapper;
            _bakeryStoreDbContext = queryTestFixture.Context;
        }

        [Fact]
        public async Task UpdateBakeryProduct_BakeryProductsExists_ShouldReturnBakeryProductViewModel()
        {
            // Arrange
            var bakeryProduct = _bakeryStoreDbContext.Products.FirstOrDefault();
            if (bakeryProduct == null)
            {
                throw new InvalidOperationException("No bakery products found in the database.");
            }
            var handler = new UpdateBakeryProductHandler(_bakeryStoreDbContext, _mapper);
            var command = new UpdateBakeryProductCommand()
            {
                Id = bakeryProduct.Id,
                Name = "Updated Product",
                Description = "Updated Description",
                Price = 4.50m,
                CategoryId = 2
            };

            //Act 
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            // var UpdateBakeryProduct = _bakeryStoreDbContext.Products.FirstOrDefault(x => x.Id == bakeryProduct.Id);
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