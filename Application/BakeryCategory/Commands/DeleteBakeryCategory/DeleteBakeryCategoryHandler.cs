using Application.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.BakeryCategory.Commands.DeleteBakeryCategory
{
    public class DeleteBakeryCategoryHandler : IRequestHandler<DeleteBakeryCategoryCommand, int>
    {
        private readonly BakeryStoreDbContext _bakeryStoreDbContext;

        public DeleteBakeryCategoryHandler(BakeryStoreDbContext bakeryStoreDbContext)
        {
            _bakeryStoreDbContext = bakeryStoreDbContext;
        }

        public async Task<int> Handle(DeleteBakeryCategoryCommand request, CancellationToken cancellationToken)
        {
            var bakeryCategory = await _bakeryStoreDbContext.Categories.FirstOrDefaultAsync(category => category.Id == request.Id, cancellationToken); // getting the category from the database context.
            if (bakeryCategory == null)
            {
                throw new NotFoundException("Category", $"{request.Id}");

            }
            _bakeryStoreDbContext.Categories.Remove(bakeryCategory);
            await _bakeryStoreDbContext.SaveChangesAsync(cancellationToken);
            return bakeryCategory.Id;
        }
    }
}
