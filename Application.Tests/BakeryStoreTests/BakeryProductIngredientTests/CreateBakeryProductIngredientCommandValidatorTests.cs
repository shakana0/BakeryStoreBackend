using Application.BakeryProductIngredient.Commands.CreateBakeryProductIngredient;
using FluentValidation.TestHelper;
using Xunit;

namespace Application.Tests.BakeryStoreTests.BakeryProductIngredientTests
{
    public class CreateBakeryProductIngredientCommandValidatorTests
    {
        private readonly CreateBakeryProductIngredientCommandValidator _validator;

        public CreateBakeryProductIngredientCommandValidatorTests()
        {
            _validator = new CreateBakeryProductIngredientCommandValidator();
        }

        [Fact]
        public void CreateBakeryProductIngredientCommandValidator_WithoutRequiredFields_ShouldGiveValidationErrors()
        {
            var command = new CreateBakeryProductIngredientCommand
            {
                ProductId = 0,
                IngredientId = 0,
                Quantity = 0,
                Unit = string.Empty,
                Description = string.Empty
            };
            var result = _validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(x => x.ProductId)
                .WithErrorMessage("ProductId is required.");
            result.ShouldHaveValidationErrorFor(x => x.IngredientId)
                .WithErrorMessage("IngredientId is required.");
            result.ShouldHaveValidationErrorFor(x => x.Quantity)
                .WithErrorMessage("Quantity is required.");
            result.ShouldHaveValidationErrorFor(x => x.Unit)
                .WithErrorMessage("Unit is required.");
            result.ShouldHaveValidationErrorFor(x => x.Description)
                .WithErrorMessage("Description is required.");
        }
    }
}