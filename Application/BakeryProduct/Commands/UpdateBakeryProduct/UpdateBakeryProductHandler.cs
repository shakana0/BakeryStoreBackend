using Application.BakeryProduct.Queries.ViewModels;
using Application.Exceptions;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.BakeryProduct.Commands.UpdateBakeryProduct
{
	public class UpdateBakeryProductHandler : IRequestHandler<UpdateBakeryProductCommand, BakeryProductViewModel>
	{
		private readonly BakeryStoreDbContext _bakeryStoreDbContext;
		private readonly IMapper _mapper;

		public UpdateBakeryProductHandler(BakeryStoreDbContext bakeryStoreDbContext, IMapper mapper)
		{
			_bakeryStoreDbContext = bakeryStoreDbContext;
			_mapper = mapper;
		}

		public async Task<BakeryProductViewModel> Handle(UpdateBakeryProductCommand request, CancellationToken cancellationToken)
		{
			var bakeryProduct = await _bakeryStoreDbContext.Products.FirstOrDefaultAsync(Product => Product.Id == request.Id);
			if (bakeryProduct == null)
			{
				throw new NotFoundException("Product", $"{request.Id}");
			}

			if (!string.IsNullOrWhiteSpace(request.Name))
			{
				bakeryProduct.Name = request.Name;
			}
			if (!string.IsNullOrWhiteSpace(request.Description))
			{
				bakeryProduct.Description = request.Description;
			}
			if (request.Price != 0)
			{
				bakeryProduct.Price = request.Price;
			}
			if (request.Stock != 0)
			{
				bakeryProduct.Stock = request.Stock;
			}

			await _bakeryStoreDbContext.SaveChangesAsync(cancellationToken);

			return _mapper.Map<BakeryProductViewModel>(bakeryProduct);
		}
	}
}
