using Application.Exceptions;
using MediatR;
using Persistence;

namespace Application.BakeryIngredient.Commands.DeleteBakeryIngredient
{
    public class DeleteBakeryIngredientHandler : IRequestHandler<DeleteBakeryIngredientCommand, int>
    {
        private readonly BakeryStoreDbContext _bakeryStoreDbContext;

        public DeleteBakeryIngredientHandler(BakeryStoreDbContext bakeryStoreDbContext)
        {
            _bakeryStoreDbContext = bakeryStoreDbContext;
        }

        public async Task<int> Handle(DeleteBakeryIngredientCommand request, CancellationToken cancellationToken)
        {
            var bakeryIngredient = await _bakeryStoreDbContext.Ingredients.FindAsync(request.Id);

            if (bakeryIngredient == null)
            {
                throw new NotFoundException("Ingredient", $"{request.Id}");
            }
            _bakeryStoreDbContext.Ingredients.Remove(bakeryIngredient);
            await _bakeryStoreDbContext.SaveChangesAsync(cancellationToken);
            return bakeryIngredient.Id;
        }
    }
}