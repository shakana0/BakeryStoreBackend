using Domain;

namespace Application.BakeryProduct.Queries.ViewModels
{
	public class BakeryProductViewModel
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public string? Description { get; set; }
		public decimal Price { get; set; }
		public int Stock { get; set; }
		public int CategoryId { get; set; }

		// Parameterless constructor for JSON deserialization
		public BakeryProductViewModel() { }
		public BakeryProductViewModel(Product search)
		{
			Id = search.Id;
			Name = search.Name;
			Description = search.Description;
			Price = search.Price;
			Stock = search.Stock;
			CategoryId = search.CategoryId;
		}
	}
}
