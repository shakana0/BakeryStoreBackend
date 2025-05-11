using Application.BakeryCategory.Queries.GetBakeryCategory;
using Application.Tests.Infrastructure;
using AutoMapper;
using Persistence;
using Xunit;

namespace Application.Tests.BakeryStoreTests.BakeryCategoryTests
{
    [Collection("QueryCollection")]
    public class GetBakeryCategoryTests
    {
        private readonly BakeryStoreDbContext _bakeryStoreDbContext;
        private readonly IMapper _mapper;
        public GetBakeryCategoryTests(QueryTestFixture queryTestFixture)
        {
            _bakeryStoreDbContext = queryTestFixture.Context;
            _mapper = queryTestFixture.Mapper;
        }
        [Fact]
        public async Task GetBakeryCategory_BakeryCategoryExists_ShouldReturnBakerycategoryViewModel()
        {
            // Arrange
            var bakeryCategory = _bakeryStoreDbContext.Categories.FirstOrDefault();
            if (bakeryCategory == null)
            {
                throw new InvalidOperationException("No bakery category found in the database.");
            }

            var handler = new GetBakeryCategoryHandler(_bakeryStoreDbContext, _mapper);
            var query = new GetBakeryCategoryQuery { Id = bakeryCategory.Id };

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(bakeryCategory.Id, result.Id);
            Assert.Equal(bakeryCategory.Name, result.Name);
        }
    }
}