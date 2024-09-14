using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.BakeryProduct.Commands.CreateBakeryProduct
{
	public class CreateBakeryProductHandler : IRequestHandler<CreateBakeryProductCommand, int>
	{
		// declaring dependencies
		private readonly BakeryStoreDbContext _bakeryStoreDbContext;
		private readonly IMapper _mapper;

		// initializing handler with the database context and the mapper.
		public CreateBakeryProductHandler(BakeryStoreDbContext bakeryStoreDbContext, IMapper mapper)
		{
			_bakeryStoreDbContext = bakeryStoreDbContext;
			_mapper = mapper;
		}

		public async Task<int> Handle(CreateBakeryProductCommand request, CancellationToken cancellationToken)
		{
			var bakeryProduct = _mapper.Map<Product>(request); // mapping the request to the Product entity.
			await _bakeryStoreDbContext.AddAsync(bakeryProduct); // adding the product to the database context.
			await _bakeryStoreDbContext.SaveChangesAsync(cancellationToken); // saving the changes to the database.
			return bakeryProduct.Id;
		}
	}
}
