namespace Application.BakeryProduct.Queries.ViewModels
{
	public class BakeryProductViewModel
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
		public int Stock { get; set; }
		public int CategoryId { get; set; }
	}
}
