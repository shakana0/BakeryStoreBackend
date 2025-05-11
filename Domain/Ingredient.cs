namespace Domain
{
	public class Ingredient
	{
		public int Id { get; set; }
		public required string Name { get; set; }
		public string? Allergens { get; set; }
	}
}
