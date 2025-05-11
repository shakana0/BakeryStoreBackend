using Application.BakeryCategory.Commands.CreateBakeryCategory;
using Application.Tests.Infrastructure;
using AutoMapper;
using Persistence;
using Xunit;

namespace Application.Tests.BakeryStoreTests.BakeryCategoryTests
{
    [Collection("QueryCollection")]
    public class CreateBakeryCategoryTests
    {
        private readonly IMapper _mapper;
        private readonly BakeryStoreDbContext _bakeryStoreDbContext;
        public CreateBakeryCategoryTests(QueryTestFixture queryTestFixture)
        {
            _mapper = queryTestFixture.Mapper;
            _bakeryStoreDbContext = queryTestFixture.Context;
        }

        [Fact]
        public async Task CreateBakeryCategory_BakeryCategoryExists_ShouldReturnBakeryCategoryId()
        {
            // Arrange
            var handler = new CreateBakeryCategoryHandler(_bakeryStoreDbContext, _mapper);
            var command = new CreateBakeryCategoryCommand
            {
                Name = "Bakery Category",
            };
            // Act
            var result = await handler.Handle(command, CancellationToken.None);
            // Assert
            Assert.NotEqual(0, result);
        }

    }
}
