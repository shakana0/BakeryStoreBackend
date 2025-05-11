using MediatR;

namespace Application.BakeryProductIngredient.Commands.DeleteBakeryProductIngredient
{
    public class DeleteBakeryProductIngredientCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}