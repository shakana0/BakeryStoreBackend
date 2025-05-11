using Application.BakeryCategory.Queries.ViewModels;
using Application.BakeryIngredient.Queries.ViewModels;
using Application.BakeryProductIngredient.Queries.ViewModels;

public class BakeryProductDetailsViewModel
{
    public int ProductId { get; set; }
    public required string Name { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public required string Description { get; set; }
    public required BakeryCategoryViewModel Category { get; set; }
    public required List<BakeryIngredientViewModel> Ingredients { get; set; }
    public required List<BakeryProductIngredientViewModel> ProductIngredients
    {
        get; set;
    }
}