using Application.BakeryProductIngredient.Commands.CreateBakeryProductIngredient;
using Application.Tests.Infrastructure;
using AutoMapper;
using Persistence;
using Xunit;

namespace Application.Tests.BakeryStoreTests.BakeryProductIngredientTests
{
    [Collection("QueryCollection")]
    public class CreateBakeryProductIngredientTests
    {
        private readonly IMapper _mapper;
        private readonly BakeryStoreDbContext _bakeryStoreDbContext;
        public CreateBakeryProductIngredientTests(QueryTestFixture queryTestFixture)
        {
            _mapper = queryTestFixture.Mapper;
            _bakeryStoreDbContext = queryTestFixture.Context;
        }

        [Fact]
        public async Task CreateBakeryProductIngredient_BakeryProductIngredientExists_ShouldReturnBakeryProductIngredientId()
        {
            // Arrange
            var handler = new CreateBakeryProductIngredientHandler(_bakeryStoreDbContext, _mapper);
            var command = new CreateBakeryProductIngredientCommand
            {
                ProductId = 1,
                IngredientId = 1,
                Quantity = 100,
                Unit = "grams",
                Description = "Freshly baked"
            };
            // Act
            var result = await handler.Handle(command, CancellationToken.None);
            // Assert
            Assert.NotEqual(0, result);
        }
    }
}