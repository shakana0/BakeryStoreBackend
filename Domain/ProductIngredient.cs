namespace Domain
{
	public class ProductIngredient
	{
		public int Id { get; set; }
		public int ProductId { get; set; }
		public int IngredientId { get; set; }
		public decimal Quantity { get; set; }
		public required string Unit { get; set; }
		public required string Description { get; set; }
		public Product? Product { get; set; } //Navigation property to Product
		public Ingredient? Ingredient { get; set; } //Navigation property to Ingredient
	}
}
