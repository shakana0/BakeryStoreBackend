namespace Domain
{
	public class ProductIngredient
	{
		public int Id { get; set; }
		public int ProductId { get; set; }
		public int IngredientId { get; set; }
		public decimal Quantity { get; set; }
		public string Unit { get; set; }
		public string Description { get; set; }
		public Product Product { get; set; }
		public Ingredient Ingredient { get; set; }
	}
}
