using Application.Exceptions;
using AutoMapper;
using MediatR;
using Persistence;

namespace Application.BakeryProductIngredient.Commands.DeleteBakeryProductIngredient
{
    public class DeleteBakeryProductIngredientHandler : IRequestHandler<DeleteBakeryProductIngredientCommand, int>
    {
        private readonly BakeryStoreDbContext _bakeryStoreDbContext;

        public DeleteBakeryProductIngredientHandler(BakeryStoreDbContext bakeryStoreDbContext)
        {
            _bakeryStoreDbContext = bakeryStoreDbContext;
        }

        public async Task<int> Handle(DeleteBakeryProductIngredientCommand request, CancellationToken cancellationToken)
        {
            var bakeryProductIngredient = await _bakeryStoreDbContext.ProductIngredients.FindAsync(request.Id, cancellationToken);
            if (bakeryProductIngredient == null)
            {
                throw new NotFoundException("BakeryProductIngredient", $"{request.Id}");
            }
            _bakeryStoreDbContext.ProductIngredients.Remove(bakeryProductIngredient);
            await _bakeryStoreDbContext.SaveChangesAsync(cancellationToken);
            return bakeryProductIngredient.Id;
        }
    }
}