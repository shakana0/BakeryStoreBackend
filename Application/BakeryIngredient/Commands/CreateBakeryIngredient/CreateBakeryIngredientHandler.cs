using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.BakeryIngredient.Commands.CreateBakeryIngredient
{

    public class CreateBakeryIngredientHandler : IRequestHandler<CreateBakeryIngredientCommand, int>
    {
        private readonly BakeryStoreDbContext _bakeryStoreDbContext;
        private readonly IMapper _mapper;

        public CreateBakeryIngredientHandler(BakeryStoreDbContext bakeryStoreDbContext, IMapper mapper)
        {
            _bakeryStoreDbContext = bakeryStoreDbContext;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateBakeryIngredientCommand request, CancellationToken cancellationToken)
        {
            var bakeryIngredient = _mapper.Map<Ingredient>(request);
            await _bakeryStoreDbContext.Ingredients.AddAsync(bakeryIngredient);
            await _bakeryStoreDbContext.SaveChangesAsync(cancellationToken);
            return bakeryIngredient.Id;
        }
    }

}