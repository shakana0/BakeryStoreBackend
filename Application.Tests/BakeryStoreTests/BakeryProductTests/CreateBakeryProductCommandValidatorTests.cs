using Xunit;
using FluentValidation.TestHelper;
using Application.BakeryProduct.Commands.CreateBakeryProduct;

namespace Application.BakeryProduct.Tests
{
    [Collection("QueryCollection")]
    public class CreateBakeryProductCommandValidatorTests
    {
        private CreateBakeryProductCommandValidator _validator;
        public CreateBakeryProductCommandValidatorTests()
        {
            _validator = new();
        }

        [Fact]
        public void CreateBakeryProductCommandValidator_WithoutRequiredFields_ShouldGiveValidationErrors()
        {
            // Arrange
            var command = new CreateBakeryProductCommand
            {
                Name = "",
                Description = "Test Description",
            };
            // Act
            var result = _validator.TestValidate(command);
            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Name);
            result.ShouldHaveValidationErrorFor(x => x.Price);
            result.ShouldHaveValidationErrorFor(x => x.CategoryId);
        }

        [Fact]
        public void CreateBakeryProductCommandValidator_WithEmptyDescription_ShouldGiveValidationError()
        {
            // Arrange
            var command = new CreateBakeryProductCommand
            {
                Name = "Valid Name",
                Description = "", // Invalid: Description is empty
                Price = 10.0m,
                CategoryId = 1
            };

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Description); // Description is required
        }

        [Fact]
        public void CreateBakeryProductCommandValidator_WithValidFields_ShouldPassValidation()
        {
            // Arrange

            var command = new CreateBakeryProductCommand
            {
                Name = "Chocolate Croissant",
                Description = "A delicious flaky pastry.",
                Price = (decimal?)3.50,
                CategoryId = 4
            };

            // Act
            var result = _validator.TestValidate(command);
            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.Name);
            result.ShouldNotHaveValidationErrorFor(x => x.Description);
            result.ShouldNotHaveValidationErrorFor(x => x.Price);
            result.ShouldNotHaveValidationErrorFor(x => x.CategoryId);
        }
    }
}
