using Application.BakeryCategory.Commands.CreateBakeryCategory;
using FluentValidation.TestHelper;
using Xunit;

namespace Application.Tests.BakeryStoreTests.BakeryCategoryTests
{
    public class CreateBakeryCategoryCommandValidatorTests
    {
        private readonly CreateBakeryCategoryCommandValidator _validator;

        public CreateBakeryCategoryCommandValidatorTests()
        {
            _validator = new CreateBakeryCategoryCommandValidator();
        }

        [Fact]
        public void CreateBakeryCategoryCommandValidator_WithoutRequiredFields_ShouldGiveValidationErrors()
        {
            var command = new CreateBakeryCategoryCommand { Name = string.Empty };
            var result = _validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(x => x.Name);
        }
    }
}