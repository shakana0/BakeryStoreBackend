using Application.BakeryIngredient.Queries.ViewModels;
using Application.Exceptions;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.BakeryIngredient.UpdateBakeryIngredient
{
    public class UpdateBakeryIngredientHandler : IRequestHandler<UpdateBakeryIngredientCommand, BakeryIngredientViewModel>
    {
        private readonly BakeryStoreDbContext _bakeryStoreDbContext;
        private readonly IMapper _mapper;

        public UpdateBakeryIngredientHandler(BakeryStoreDbContext bakeryStoreDbContext, IMapper mapper)
        {
            _bakeryStoreDbContext = bakeryStoreDbContext;
            _mapper = mapper;

        }

        public async Task<BakeryIngredientViewModel> Handle(UpdateBakeryIngredientCommand request, CancellationToken cancellationToken)
        {
            var bakeryIngredient = await _bakeryStoreDbContext.Ingredients.FirstOrDefaultAsync(Ingredient => Ingredient.Id == request.Id);

            if (bakeryIngredient == null)
            {
                throw new NotFoundException("Ingredient", $"{request.Id}");
            }

            if (!string.IsNullOrWhiteSpace(request.Name))
            {
                bakeryIngredient.Name = request.Name;
            }
            if (!string.IsNullOrWhiteSpace(request.Allergens))
            {
                bakeryIngredient.Allergens = request.Allergens;
            }

            await _bakeryStoreDbContext.SaveChangesAsync(cancellationToken);

            return _mapper.Map<BakeryIngredientViewModel>(bakeryIngredient);
        }
    }
}