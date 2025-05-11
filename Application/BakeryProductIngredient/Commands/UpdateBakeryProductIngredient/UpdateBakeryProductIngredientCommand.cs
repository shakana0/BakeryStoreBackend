using Application.BakeryProductIngredient.Queries.ViewModels;
using MediatR;

namespace Application.BakeryProductIngredient.Commands.UpdatebakeryProductIngredient
{
    public class UpdateBakeryProductIngredientCommand : IRequest<BakeryProductIngredientViewModel>
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int IngredientId { get; set; }
        public decimal Quantity { get; set; }
        public string Unit { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public void SetBakeryProductIngredientId(int id) => Id = id;
    }
}