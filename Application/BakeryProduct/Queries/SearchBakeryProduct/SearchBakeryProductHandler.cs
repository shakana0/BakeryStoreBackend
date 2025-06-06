using Application.BakeryProduct.Queries.ViewModels;
using Application.Common.Extension;
using Application.Common.ViewModel;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.BakeryProduct.Queries.SearchBakeryProduct
{
	public class SearchBakeryProductHandler : IRequestHandler<SearchBakeryProductQuery, PagedResponseViewModel<BakeryProductViewModel>>
	{
		private readonly BakeryStoreDbContext _bakeryStoreDbContext;
		public SearchBakeryProductHandler(BakeryStoreDbContext bakeryStoreDbContext)
		{
			_bakeryStoreDbContext = bakeryStoreDbContext;
		}

		public async Task<PagedResponseViewModel<BakeryProductViewModel>> Handle(SearchBakeryProductQuery request, CancellationToken cancellationToken)
		{
			IQueryable<Product> query = _bakeryStoreDbContext.Products
					.AsNoTracking()
					.AsQueryable();

			if (!string.IsNullOrEmpty(request.Name))
			{
				query = query.Where(x => x.Name.ToLower().Contains(request.Name.ToLower()));
			}
			if (!string.IsNullOrEmpty(request.Description))
			{
				query = query.Where(x => x.Description.ToLower().Contains(request.Description.ToLower()));
			}
			if (request.CategoryId.HasValue)
			{
				query = query.Where(x => x.CategoryId.Equals(request.CategoryId));
			}

			var bakeryStoreProducts = query.Select(x => new BakeryProductViewModel(x));
			return await bakeryStoreProducts.GetPagedAsync(request.PageNumber, request.PageSize, cancellationToken);
		}

	}
}
