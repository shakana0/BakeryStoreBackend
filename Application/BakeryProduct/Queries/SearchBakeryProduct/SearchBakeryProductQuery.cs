using Application.BakeryProduct.Queries.ViewModels;
using Application.Common;

namespace Application.BakeryProduct.Queries.SearchBakeryProduct
{
	public class SearchBakeryProductQuery : SearchQuery<BakeryProductViewModel>
	{
		public string? Name { get; set; }
		public string? Description { get; set; }
		public int? CategoryId { get; set; }
	}
}
