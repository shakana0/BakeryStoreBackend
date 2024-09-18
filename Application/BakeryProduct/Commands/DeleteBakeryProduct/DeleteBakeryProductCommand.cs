using MediatR;

namespace Application.BakeryProduct.Commands.DeleteBakeryProduct
{
	public class DeleteBakeryProductCommand : IRequest<int>
	{
		public int Id { get; set; }
	}
}
