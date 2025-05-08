using FluentValidation;

namespace Application.BakeryProductIngredient.Commands.CreateBakeryProductIngredient
{
    public class CreateBakeryProductIngredientCommandValidator : AbstractValidator<CreateBakeryProductIngredientCommand>
    {
        public CreateBakeryProductIngredientCommandValidator()
        {
            RuleFor(x => x.ProductId).NotEmpty().WithMessage("ProductId is required.");
            RuleFor(x => x.IngredientId).NotEmpty().WithMessage("IngredientId is required.");
            RuleFor(x => x.Quantity).NotEmpty().WithMessage("Quantity is required.");
            RuleFor(x => x.Unit).NotEmpty().WithMessage("Unit is required.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required.");
        }
    }
}