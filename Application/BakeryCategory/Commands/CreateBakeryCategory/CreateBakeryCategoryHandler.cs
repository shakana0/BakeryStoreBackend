using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.BakeryCategory.Commands.CreateBakeryCategory
{
    public class CreateBakeryCategoryHandler : IRequestHandler<CreateBakeryCategoryCommand, int>
    {
        private readonly BakeryStoreDbContext _bakeryStoreDbContext;
        private readonly IMapper _mapper;

        public CreateBakeryCategoryHandler(BakeryStoreDbContext bakeryStoreDbContext, IMapper mapper)
        {
            _bakeryStoreDbContext = bakeryStoreDbContext;
            _mapper = mapper;

        }
        public async Task<int> Handle(CreateBakeryCategoryCommand request, CancellationToken cancellationToken)
        {
            var bakeryCategory = _mapper.Map<Category>(request); // mapping the request to the Category entity.
            await _bakeryStoreDbContext.AddAsync(bakeryCategory); // adding the category to the database context.
            await _bakeryStoreDbContext.SaveChangesAsync(cancellationToken); // saving the changes to the database.
            return bakeryCategory.Id;
        }
    }
}