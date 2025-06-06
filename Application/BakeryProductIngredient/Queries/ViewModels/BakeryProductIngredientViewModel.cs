using Domain;

namespace Application.BakeryProductIngredient.Queries.ViewModels
{
    public class BakeryProductIngredientViewModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int IngredientId { get; set; }
        public decimal Quantity { get; set; }
        public string Unit { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public BakeryProductIngredientViewModel() { } //Required for deserialization

        public BakeryProductIngredientViewModel(ProductIngredient productIngredient)
        {
            Id = productIngredient.Id;
            ProductId = productIngredient.ProductId;
            IngredientId = productIngredient.IngredientId;
            Quantity = productIngredient.Quantity;
            Unit = productIngredient.Unit;
            Description = productIngredient.Description;
        }
    }
}