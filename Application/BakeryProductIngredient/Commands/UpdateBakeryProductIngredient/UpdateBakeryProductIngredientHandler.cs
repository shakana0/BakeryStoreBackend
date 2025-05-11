using Application.BakeryProductIngredient.Queries.ViewModels;
using Application.Exceptions;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.BakeryProductIngredient.Commands.UpdatebakeryProductIngredient
{
    public class UpdateBakeryIngredientHandler : IRequestHandler<UpdateBakeryProductIngredientCommand, BakeryProductIngredientViewModel>
    {
        private readonly BakeryStoreDbContext _bakeryStoreDbContext;
        private readonly IMapper _mapper;


        public UpdateBakeryIngredientHandler(BakeryStoreDbContext bakeryStoreDbContext, IMapper mapper)
        {
            _bakeryStoreDbContext = bakeryStoreDbContext;
            _mapper = mapper;
        }

        public async Task<BakeryProductIngredientViewModel> Handle(UpdateBakeryProductIngredientCommand request, CancellationToken cancellationToken)
        {
            var bakeryProductIngredient = await _bakeryStoreDbContext.ProductIngredients.FirstOrDefaultAsync(ProductIngredient => ProductIngredient.Id == request.Id);

            if (bakeryProductIngredient == null)
            {
                throw new NotFoundException("ProductIngredient", $"{request.Id}");
            }

            if (request.ProductId != 0)
            {
                bakeryProductIngredient.ProductId = request.ProductId;
            }
            if (request.IngredientId != 0)
            {
                bakeryProductIngredient.IngredientId = request.IngredientId;
            }
            if (request.Quantity != 0)
            {
                bakeryProductIngredient.Quantity = request.Quantity;
            }
            if (!string.IsNullOrWhiteSpace(request.Unit))
            {
                bakeryProductIngredient.Unit = request.Unit;
            }
            if (!string.IsNullOrWhiteSpace(request.Description))
            {
                bakeryProductIngredient.Description = request.Description;
            }

            await _bakeryStoreDbContext.SaveChangesAsync(cancellationToken);

            return _mapper.Map<BakeryProductIngredientViewModel>(bakeryProductIngredient);
        }
    }
}