using MediatR;

namespace Application.BakeryIngredient.Commands.CreateBakeryIngredient
{
    public class CreateBakeryIngredientCommand : IRequest<int>
    {
        public required string Name { get; set; }
        public string? Allergens { get; set; }
    }
}