using Application.BakeryProductIngredient.Queries.ViewModels;
using MediatR;

namespace Application.BakeryProductIngredient.Queries.GetBakeryProductIngredient
{
    public class GetBakeryProductIngredientQuery : IRequest<BakeryProductIngredientViewModel>
    {
        public int Id { get; set; }
    }
}