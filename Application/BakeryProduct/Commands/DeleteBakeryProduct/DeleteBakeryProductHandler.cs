using Application.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.BakeryProduct.Commands.DeleteBakeryProduct
{
	public class DeleteBakeryProductHandler : IRequestHandler<DeleteBakeryProductCommand, int>
	{
		private readonly BakeryStoreDbContext _bakeryStoreDbContext;

		public DeleteBakeryProductHandler(BakeryStoreDbContext bakeryStoreDbContext)
		{
			_bakeryStoreDbContext = bakeryStoreDbContext;
		}

		public async Task<int> Handle(DeleteBakeryProductCommand request, CancellationToken cancellationToken)
		{

			var bakeryProduct = await _bakeryStoreDbContext.Products.FirstOrDefaultAsync(product => product.Id == request.Id, cancellationToken); // getting the product from the database context.
			if (bakeryProduct == null)
			{
				throw new NotFoundException("Product", $"{request.Id}");
			}

			_bakeryStoreDbContext.Products.Remove(bakeryProduct);
			await _bakeryStoreDbContext.SaveChangesAsync(cancellationToken);
			return bakeryProduct.Id;
		}
	}
}
