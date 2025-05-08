using Application.BakeryIngredient.UpdateBakeryIngredient;
using Application.Tests.Infrastructure;
using AutoMapper;
using Persistence;
using Xunit;

namespace Application.Tests.BakeryStoreTests.BakeryIngredientTests
{
    [Collection("QueryCollection")]
    public class UpdateBakeryIngredientTests
    {
        private readonly IMapper _mapper;
        private readonly BakeryStoreDbContext _bakeryStoreDbContext;

        public UpdateBakeryIngredientTests(QueryTestFixture queryTestFixture)
        {
            _mapper = queryTestFixture.Mapper;
            _bakeryStoreDbContext = queryTestFixture.Context;
        }

        [Fact]
        public async Task UpdateBakeryIngredient_BakeryIngredientsExists_ShouldReturnBakeryIngredientViewModel()
        {
            // Arrange
            var bakeryIngredient = _bakeryStoreDbContext.Ingredients.FirstOrDefault();
            if (bakeryIngredient == null)
            {
                throw new InvalidOperationException("No bakery ingredients found in the database.");
            }
            var handler = new UpdateBakeryIngredientHandler(_bakeryStoreDbContext, _mapper);
            var command = new UpdateBakeryIngredientCommand()
            {
                Id = bakeryIngredient.Id,
                Name = "Updated Ingredient",
                Allergens = "Updated Allergens"
            };

            //Act 
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(bakeryIngredient.Id, result.Id);
            Assert.Equal(bakeryIngredient.Name, result.Name);
            Assert.Equal(bakeryIngredient.Allergens, result.Allergens);
        }
    }
}