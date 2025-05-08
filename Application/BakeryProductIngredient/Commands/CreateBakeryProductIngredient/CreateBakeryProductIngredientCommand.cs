using MediatR;

namespace Application.BakeryProductIngredient.Commands.CreateBakeryProductIngredient
{
    public class CreateBakeryProductIngredientCommand : IRequest<int>
    {
        public int ProductId { get; set; }
        public int IngredientId { get; set; }
        public decimal Quantity { get; set; }
        public required string Unit { get; set; }
        public required string Description { get; set; }
    }
}