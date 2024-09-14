namespace Domain
{
	public class Product
	{
		public int Id { get; set; }
		public required string Name { get; set; }
		public decimal Price { get; set; }
		public int Stock { get; set; }
		public required string Description { get; set; }
		//public required Category Category { get; set; }
		public required int CategoryId { get; set; }

	}
}
