using FluentValidation;

namespace Application.BakeryProduct.Commands.UpdateBakeryProduct
{
	public class UpdateBakeryProductCommandValidator : AbstractValidator<UpdateBakeryProductCommand>
	{
		public UpdateBakeryProductCommandValidator()
		{

			//RuleFor(x => x.Id).NotEmpty();
			//RuleFor(x => x.Name).NotEmpty();
			//RuleFor(x => x.Description).NotEmpty();
			//RuleFor(x => x.Price).NotEmpty();
		}
	}
}
