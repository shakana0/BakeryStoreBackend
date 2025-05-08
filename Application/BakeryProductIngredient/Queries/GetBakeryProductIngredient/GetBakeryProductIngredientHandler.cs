using Application.BakeryProductIngredient.Queries.ViewModels;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.BakeryProductIngredient.Queries.GetBakeryProductIngredient
{
    public class GetBakeryProductIngredientHandler : IRequestHandler<GetBakeryProductIngredientQuery, BakeryProductIngredientViewModel>
    {
        private readonly BakeryStoreDbContext _bakeryStoreDbContext;
        private readonly IMapper _mapper;


        public GetBakeryProductIngredientHandler(BakeryStoreDbContext bakeryStoreDbContext, IMapper mapper)
        {
            _bakeryStoreDbContext = bakeryStoreDbContext;
            _mapper = mapper;
        }

        public async Task<BakeryProductIngredientViewModel> Handle(GetBakeryProductIngredientQuery request, CancellationToken cancellationToken)
        {
            var bakeryProductIngredient = await _bakeryStoreDbContext.ProductIngredients
            .AsNoTracking()
            .FirstOrDefaultAsync(productIngredient => productIngredient.Id == request.Id, cancellationToken);
            return _mapper.Map<BakeryProductIngredientViewModel>(bakeryProductIngredient);
        }
    }
}