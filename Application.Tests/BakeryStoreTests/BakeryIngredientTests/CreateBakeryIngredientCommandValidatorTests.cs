using Application.BakeryIngredient.Commands.CreateBakeryIngredient;
using FluentValidation.TestHelper;
using Xunit;
namespace Application.Tests.BakeryStoreTests.BakeryIngredientTests
{
    public class CreateBakeryIngredientCommandValidatorTests
    {
        private readonly CreateBakeryIngredientCommandvalidator _validator;

        public CreateBakeryIngredientCommandValidatorTests()
        {
            _validator = new CreateBakeryIngredientCommandvalidator();
        }

        [Fact]
        public void CreateBakeryIngredientCommandValidator_WithoutRequiredFields_ShouldGiveValidationErrors()
        {
            var command = new CreateBakeryIngredientCommand { Name = string.Empty };
            var result = _validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(x => x.Name);
        }
    }
}