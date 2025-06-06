using Application.BakeryCategory.Queries.ViewModels;
using Application.BakeryIngredient.Queries.ViewModels;
using Application.BakeryProductIngredient.Queries.ViewModels;
using Application.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.BakeryProduct.Queries.GetBakeryProductDetails
{
    public class GetBakeryProductDetailsHandler : IRequestHandler<GetBakeryProductDetailsQuery, BakeryProductDetailsViewModel>
    {
        private readonly BakeryStoreDbContext _bakeryStoreDbContext;

        public GetBakeryProductDetailsHandler(BakeryStoreDbContext bakeryStoreDbContext)
        {
            _bakeryStoreDbContext = bakeryStoreDbContext;
        }

        public async Task<BakeryProductDetailsViewModel> Handle(GetBakeryProductDetailsQuery request, CancellationToken cancellationToken)
        {
            // Validate the request
            var product = await _bakeryStoreDbContext.Products
                .FirstOrDefaultAsync(p => p.Id == request.ProductId, cancellationToken);
            // Check if the product exists
            if (product == null)
            {
                throw new NotFoundException("Product", request.ProductId.ToString());
            }
            //fetch the category seprately
            var category = await _bakeryStoreDbContext.Categories
                .FirstOrDefaultAsync(c => c.Id == product.CategoryId, cancellationToken);

            var productIngredients = await _bakeryStoreDbContext.ProductIngredients
                .Where(pi => pi.ProductId == request.ProductId && pi.Ingredient != null) // Ensure Ingredient isn't null
                .Include(pi => pi.Ingredient)
                .ToListAsync(cancellationToken);

            return new BakeryProductDetailsViewModel
            {
                ProductId = product.Id,
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock,
                Description = product.Description,
                Category = new BakeryCategoryViewModel
                {
                    Id = product.CategoryId,
                    Name = category?.Name ?? "Unknown"
                },

                ProductIngredients = productIngredients.Select(pi => new BakeryProductIngredientViewModel(pi)).ToList(),
                Ingredients = productIngredients
                .Where(pi => pi.Ingredient != null)
                .Select(pi => new BakeryIngredientViewModel
                {
                    Id = pi.Ingredient?.Id ?? 0,
                    Name = pi.Ingredient?.Name ?? "Unknown",
                    Allergens = pi.Ingredient?.Allergens ?? "Unknown"
                }).ToList()
            };
        }
    }
}
