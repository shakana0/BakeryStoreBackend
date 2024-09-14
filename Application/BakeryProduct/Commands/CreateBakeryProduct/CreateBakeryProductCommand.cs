using MediatR;

namespace Application.BakeryProduct.Commands.CreateBakeryProduct
{
	public class CreateBakeryProductCommand : IRequest<int>
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
		public int Stock { get; set; }
		//public CategoryDto CategoryId { get; set; }
		public int CategoryId { get; set; }
	}
}
