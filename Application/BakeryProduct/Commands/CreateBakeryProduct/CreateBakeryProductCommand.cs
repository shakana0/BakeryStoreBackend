using MediatR;

namespace Application.BakeryProduct.Commands.CreateBakeryProduct
{
	public class CreateBakeryProductCommand : IRequest<int>
	{
		public required string Name { get; set; }
		public required string Description { get; set; }
		public decimal? Price { get; set; }
		public int Stock { get; set; }
		public int CategoryId { get; set; }
	}
}
