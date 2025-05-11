using Application.BakeryCategory.Commands.UpdateBakeryCategory;
using Application.Tests.Infrastructure;
using AutoMapper;
using Persistence;
using Xunit;

namespace Application.Tests.BakeryStoreTests.BakeryCategoryTests
{
    [Collection("QueryCollection")]
    public class UpdateBakeryCategoryTests
    {
        private readonly BakeryStoreDbContext _bakeryStoreDbContext;
        private readonly IMapper _mapper;
        public UpdateBakeryCategoryTests(QueryTestFixture queryTestFixture)
        {
            _bakeryStoreDbContext = queryTestFixture.Context;
            _mapper = queryTestFixture.Mapper;
        }
        [Fact]
        public async Task UpdateBakeryCategory_BakeryCategoryExists_ShouldReturnBakeryCategoryViewModel()
        {
            // Arrange
            var bakeryCategory = _bakeryStoreDbContext.Categories.FirstOrDefault();
            if (bakeryCategory == null)
            {
                throw new InvalidOperationException("No bakery category found in the database.");
            }

            var handler = new UpdateBakeryCategoryHandler(_bakeryStoreDbContext, _mapper);
            var command = new UpdateBakeryCategoryCommand
            {
                Id = bakeryCategory.Id,
                Name = "Updated Bakery Category",
            };
            // Act
            var result = await handler.Handle(command, CancellationToken.None);
            // Assert
            Assert.NotNull(result);
            Assert.Equal(bakeryCategory.Id, result.Id);
            Assert.Equal(bakeryCategory.Name, result.Name);
        }
    }
}