using Application.BakeryProduct.Commands.CreateBakeryProduct;
using Application.Tests.Infrastructure;
using AutoMapper;
using Persistence;
using Xunit;


namespace Application.Tests.BakeryProductTests
{
    [Collection("QueryCollection")]
    public class CreateBakeryProductTests
    {
        private readonly IMapper _mapper;
        private readonly BakeryStoreDbContext _bakeryStoreDbContext;

        public CreateBakeryProductTests(QueryTestFixture queryTestFixture)
        {
            _mapper = queryTestFixture.Mapper;
            _bakeryStoreDbContext = queryTestFixture.Context;
        }

        [Fact]
        public async Task CreateBakeryProduct_BakeryProductsExists_ShouldReturnBakeryProductId()
        {
            // Arrange
            var handler = new CreateBakeryProductHandler(_bakeryStoreDbContext, _mapper);
            var command = new CreateBakeryProductCommand()
            {
                Name = "Chocolate Croissant",
                Description = "A delicious flaky pastry.",
                Price = (decimal?)3.50,
                CategoryId = 4
            };

            //Act 
            var result = await handler.Handle(command, CancellationToken.None);
            // Assert
            Assert.NotEqual(0, result); // Check if the result is not zero (indicating a successful creation)            
        }
    }
}
