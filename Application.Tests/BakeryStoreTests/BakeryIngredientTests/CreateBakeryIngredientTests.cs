using Application.BakeryIngredient.Commands.CreateBakeryIngredient;
using Application.Tests.Infrastructure;
using AutoMapper;
using Persistence;
using Xunit;

namespace Application.Tests.BakeryStoreTests.BakeryIngredientTests
{
    [Collection("QueryCollection")]
    public class CreateBakeryIngredientTests
    {
        private readonly IMapper _mapper;
        private readonly BakeryStoreDbContext _bakeryStoreDbContext;

        public CreateBakeryIngredientTests(QueryTestFixture queryTestFixture)
        {
            _mapper = queryTestFixture.Mapper;
            _bakeryStoreDbContext = queryTestFixture.Context;
        }

        [Fact]
        public async Task CreateBakeryIngredient_BakeryIngredientExists_ShouldReturnBakeryIngredientId()
        {
            // Arrange
            var handler = new CreateBakeryIngredientHandler(_bakeryStoreDbContext, _mapper);
            var command = new CreateBakeryIngredientCommand()
            {
                Name = "Flour",
                Allergens = "Gluten",
            };

            //Act 
            var result = await handler.Handle(command, CancellationToken.None);
            // Assert
            Assert.NotEqual(0, result);
        }
    }
}