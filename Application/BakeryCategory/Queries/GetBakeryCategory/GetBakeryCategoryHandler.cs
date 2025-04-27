using Application.BakeryCategory.Queries.ViewModels;
using Application.Exceptions;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.BakeryCategory.Queries.GetBakeryCategory
{
    public class GetBakeryCategoryHandler : IRequestHandler<GetBakeryCategoryQuery, BakeryCategoryViewModel>
    {
        private readonly BakeryStoreDbContext _bakeryStoreDbContext;
        private readonly IMapper _mapper;

        public GetBakeryCategoryHandler(BakeryStoreDbContext bakeryStoreDbContext, IMapper mapper)
        {
            _bakeryStoreDbContext = bakeryStoreDbContext;
            _mapper = mapper;
        }

        public async Task<BakeryCategoryViewModel> Handle(GetBakeryCategoryQuery request, CancellationToken cancellationToken)
        {
            var bakeryCategory = await _bakeryStoreDbContext.Categories.FirstOrDefaultAsync(category => category.Id == request.Id, cancellationToken); // getting the category from the database context.
            if (bakeryCategory == null) // if the category is not found, throw an exception.
            {
                throw new NotFoundException("Category", $"{request.Id}");

            }
            return _mapper.Map<BakeryCategoryViewModel>(bakeryCategory);
        }

    }
}
