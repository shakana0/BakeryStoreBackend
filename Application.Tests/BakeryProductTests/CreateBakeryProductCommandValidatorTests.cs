using Xunit;
using FluentValidation;
using FluentValidation.TestHelper;
using Application.BakeryProduct.Commands.CreateBakeryProduct;

public class CreateBakeryProductCommandValidatorTests
{
    private readonly CreateBakeryProductCommandValidator _validator;

    public CreateBakeryProductCommandValidatorTests()
    {
        _validator = new CreateBakeryProductCommandValidator();
    }

    [Fact]
    public void CreateBakeryProductCommandValidator_WithoutName_ShouldGiveValidationErrors()
    {
        var model = new CreateBakeryProductCommand { Name = "" };
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.Name);
    }

    [Fact]
    public void CreateBakeryProductCommandValidator_WithoutDescription_ShouldGiveValidationErrors()
    {
        var model = new CreateBakeryProductCommand { Description = "" };
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.Description);
    }

    [Fact]
    public void CreateBakeryProductCommandValidator_WithoutPrice_ShouldGiveValidationErrors()
    {
        var model = new CreateBakeryProductCommand { Price = null };
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.Price);
    }

    [Fact]
    public void CreateBakeryProductCommandValidator_WithInvalidCategoryId_ShouldGiveValidationErrors()
    {
        var model = new CreateBakeryProductCommand { CategoryId = 0 };
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.CategoryId);
    }

    [Fact]
    public void CreateBakeryProductCommandValidator_WithValidFields_ShouldPassValidation()
    {
        var model = new CreateBakeryProductCommand
        {
            Name = "Chocolate Croissant",
            Description = "A delicious flaky pastry.",
            Price = 3.50m,
            CategoryId = 4
        };

        var result = _validator.TestValidate(model);
        result.ShouldNotHaveValidationErrorFor(x => x.Name);
        result.ShouldNotHaveValidationErrorFor(x => x.Description);
        result.ShouldNotHaveValidationErrorFor(x => x.Price);
        result.ShouldNotHaveValidationErrorFor(x => x.CategoryId);
    }
}
