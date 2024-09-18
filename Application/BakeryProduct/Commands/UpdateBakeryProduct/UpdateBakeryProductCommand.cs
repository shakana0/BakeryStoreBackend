using Application.BakeryProduct.Queries.ViewModels;
using MediatR;

namespace Application.BakeryProduct.Commands.UpdateBakeryProduct
{
	public class UpdateBakeryProductCommand : IRequest<BakeryProductViewModel>
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public string? Description { get; set; }
		public decimal Price { get; set; }
		public int Stock { get; set; }
		//public int CategoryId { get; set; }
		public void SetBakeryProductId(int id) => Id = id;
	}
}
