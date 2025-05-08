using Application.BakeryIngredient.Queries.ViewModels;
using MediatR;

namespace Application.BakeryIngredient.UpdateBakeryIngredient
{
    public class UpdateBakeryIngredientCommand : IRequest<BakeryIngredientViewModel>
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Allergens { get; set; }
        public void SetBakeryIngredientId(int id) => Id = id;
    }
}