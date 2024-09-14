using Application.BakeryProduct.Queries.ViewModels;
using MediatR;

namespace Application.BakeryProduct.Queries.GetBakeryProduct
{
	public class GetBakeryProductQuery : IRequest<BakeryProductViewModel>
	{
		public int Id { get; set; }
	}
}
