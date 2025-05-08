using Application.BakeryProductIngredient;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.BakeryProductIngredient.Commands.CreateBakeryProductIngredient
{
    public class CreateBakeryProductIngredientHandler : IRequestHandler<CreateBakeryProductIngredientCommand, int>
    {
        private readonly BakeryStoreDbContext _bakeryStoreDbContext;
        private readonly IMapper _mapper;


        public CreateBakeryProductIngredientHandler(BakeryStoreDbContext bakeryStoreDbContext, IMapper mapper)
        {
            _bakeryStoreDbContext = bakeryStoreDbContext;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateBakeryProductIngredientCommand request, CancellationToken cancellationToken)
        {
            var bakeryProductIngredient = _mapper.Map<ProductIngredient>(request);
            await _bakeryStoreDbContext.ProductIngredients.AddAsync(bakeryProductIngredient, cancellationToken);
            await _bakeryStoreDbContext.SaveChangesAsync(cancellationToken);
            return bakeryProductIngredient.Id;
        }
    }
}