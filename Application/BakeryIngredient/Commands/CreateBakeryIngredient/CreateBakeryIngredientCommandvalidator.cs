using FluentValidation;

namespace Application.BakeryIngredient.Commands.CreateBakeryIngredient
{
    public class CreateBakeryIngredientCommandvalidator : AbstractValidator<CreateBakeryIngredientCommand>
    {
        public CreateBakeryIngredientCommandvalidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
            RuleFor(x => x.Allergens).NotEmpty().WithMessage("Allergens are required.");
        }
    }
}