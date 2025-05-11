using Domain;

namespace Application.BakeryIngredient.Queries.ViewModels
{
    public class BakeryIngredientViewModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Allergens { get; set; }
        public BakeryIngredientViewModel() { }

        public BakeryIngredientViewModel(Ingredient ingredient)
        {
            Id = ingredient.Id;
            Name = ingredient.Name;
            Allergens = ingredient.Allergens;
        }
    }
}