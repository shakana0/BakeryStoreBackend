using FluentValidation;

namespace Application.BakeryCategory.Commands.CreateBakeryCategory
{
    public class CreateBakeryCategoryCommandValidator : AbstractValidator<CreateBakeryCategoryCommand>
    {
        public CreateBakeryCategoryCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
