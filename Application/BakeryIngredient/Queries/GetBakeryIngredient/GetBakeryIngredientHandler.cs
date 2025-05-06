using Application.BakeryIngredient.Queries.ViewModels;
using Application.Exceptions;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.BakeryIngredient.Queries.GetBakeryIngredient
{
    public class GetBakeryIngredientHandler : IRequestHandler<GetBakeryIngredientQuery, BakeryIngredientViewModel>
    {
        private readonly BakeryStoreDbContext _bakeryStoreDbContext;
        private readonly IMapper _mapper;

        public GetBakeryIngredientHandler(BakeryStoreDbContext bakeryStoreDbContext, IMapper mapper)
        {
            _bakeryStoreDbContext = bakeryStoreDbContext;
            _mapper = mapper;
        }

        public async Task<BakeryIngredientViewModel> Handle(GetBakeryIngredientQuery request, CancellationToken cancellationToken)
        {
            var bakeryIngredient = await _bakeryStoreDbContext.Ingredients
                    .AsNoTracking()
                    .FirstOrDefaultAsync(ingredient => ingredient.Id == request.Id, cancellationToken); // getting the ingredient from the database context.
            if (bakeryIngredient == null)
            {
                throw new NotFoundException("Ingredient", $"{request.Id}");
            }
            return _mapper.Map<BakeryIngredientViewModel>(bakeryIngredient);
        }
    }
}