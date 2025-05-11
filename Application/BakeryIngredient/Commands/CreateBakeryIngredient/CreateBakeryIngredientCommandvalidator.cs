using FluentValidation;

namespace Application.BakeryIngredient.Commands.CreateBakeryIngredient
{
    public class CreateBakeryIngredientCommandvalidator : AbstractValidator<CreateBakeryIngredientCommand>
    {
        public CreateBakeryIngredientCommandvalidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
            // Normalize Allergens
            RuleFor(x => x.Allergens)
                .Custom((value, context) =>
                {
                    if (string.IsNullOrWhiteSpace(value))
                    {
                        context.InstanceToValidate.Allergens = null;
                    }
                });
        }
    }
}