using Application.BakeryProduct.Queries.ViewModels;
using Application.Exceptions;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.BakeryProduct.Queries.GetBakeryProduct
{
	public class GetBakeryProductHandler : IRequestHandler<GetBakeryProductQuery, BakeryProductViewModel>
	{
		private readonly BakeryStoreDbContext _bakeryStoreDbContext;
		private readonly IMapper _mapper;

		public GetBakeryProductHandler(BakeryStoreDbContext bakeryStoreDbContext, IMapper mapper)
		{
			_bakeryStoreDbContext = bakeryStoreDbContext;
			_mapper = mapper;
		}

		public async Task<BakeryProductViewModel> Handle(GetBakeryProductQuery request, CancellationToken cancellationToken)
		{
			var bakeryProduct = await _bakeryStoreDbContext.Products
					.AsNoTracking() // Disable change tracking for better performance
					.FirstOrDefaultAsync(product => product.Id == request.Id, cancellationToken); // getting the product from the database context.
			if (bakeryProduct == null) // if the product is not found, throw an exception.
			{
				throw new NotFoundException("Product", $"{request.Id}");

			}
			return _mapper.Map<BakeryProductViewModel>(bakeryProduct);
		}

	}
}
