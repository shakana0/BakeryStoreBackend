using FluentValidation;

namespace Application.BakeryProduct.Commands.CreateBakeryProduct
{
	public class CreateBakeryProductCommandValidator : AbstractValidator<CreateBakeryProductCommand>
	{
		public CreateBakeryProductCommandValidator()
		{
			RuleFor(x => x.Name).NotEmpty();
			RuleFor(x => x.Description).NotEmpty();
			RuleFor(x => x.Price).NotEmpty();
			//RuleFor(x => x.CategoryId).NotEmpty();
		}
	}
}
