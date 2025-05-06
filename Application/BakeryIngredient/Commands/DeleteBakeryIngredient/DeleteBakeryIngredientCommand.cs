using MediatR;

namespace Application.BakeryIngredient.Commands.DeleteBakeryIngredient
{
    public class DeleteBakeryIngredientCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}