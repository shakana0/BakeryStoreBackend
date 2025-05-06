using Application.BakeryIngredient.Queries.GetBakeryIngredient;
using Application.Tests.Infrastructure;
using AutoMapper;
using Persistence;
using Xunit;

namespace Application.Tests.BakeryStoreTests.BakeryIngredientTests
{
    [Collection("QueryCollection")]
    public class GetBakeryIngredientTests
    {
        private readonly IMapper _mapper;
        private readonly BakeryStoreDbContext _bakeryStoreDbContext;

        public GetBakeryIngredientTests(QueryTestFixture queryTestFixture)
        {
            _mapper = queryTestFixture.Mapper;
            _bakeryStoreDbContext = queryTestFixture.Context;
        }

        [Fact]
        public async Task GetBakeryIngredientQuery_BakeryIngredientExists_ShouldReturnBakeryIngredientViewModel()
        {
            // Arrange
            var bakeryIngredient = _bakeryStoreDbContext.Ingredients.Skip(2).FirstOrDefault();
            if (bakeryIngredient == null)
            {
                throw new InvalidOperationException("No bakery ingredients found in the database.");
            }
            var handler = new GetBakeryIngredientHandler(_bakeryStoreDbContext, _mapper);
            var command = new GetBakeryIngredientQuery { Id = bakeryIngredient.Id };

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(bakeryIngredient.Id, result.Id);
            Assert.Equal(bakeryIngredient.Name, result.Name);
            Assert.Equal(bakeryIngredient.Allergens, result.Allergens);
        }
    }
}