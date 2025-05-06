using Application.BakeryIngredient.Queries.ViewModels;
using MediatR;

namespace Application.BakeryIngredient.Queries.GetBakeryIngredient
{
    public class GetBakeryIngredientQuery : IRequest<BakeryIngredientViewModel>
    {
        public int Id { get; set; }
    }
}