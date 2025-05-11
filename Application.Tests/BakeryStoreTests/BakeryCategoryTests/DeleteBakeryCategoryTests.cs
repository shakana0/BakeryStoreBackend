using Application.BakeryCategory.Commands.DeleteBakeryCategory;
using Application.Tests.Infrastructure;
using Persistence;
using Xunit;

namespace Application.Tests.BakeryStoreTests.BakeryCategoryTests
{
    [Collection("QueryCollection")]
    public class DeleteBakeryCategoryTests
    {
        private readonly BakeryStoreDbContext _bakeryStoreDbContext;
        public DeleteBakeryCategoryTests(QueryTestFixture queryTestFixture)
        {
            _bakeryStoreDbContext = queryTestFixture.Context;
        }

        [Fact]
        public async Task DeleteBakeryCategory_BakeryCategoryExists_ShouldRemoveCategoryFromDatabase()
        {
            // Arrange
            var bakeryCategory = _bakeryStoreDbContext.Categories.FirstOrDefault();
            if (bakeryCategory == null)
            {
                throw new InvalidOperationException("No bakery category found in the database.");
            }

            var handler = new DeleteBakeryCategoryHandler(_bakeryStoreDbContext);
            var command = new DeleteBakeryCategoryCommand { Id = bakeryCategory.Id };

            // Act
            await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.Null(_bakeryStoreDbContext.Categories.FirstOrDefault(em => em.Id == bakeryCategory.Id));
        }
    }
}