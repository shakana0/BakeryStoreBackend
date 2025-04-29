using MediatR;
using Persistence;
using Application.BakeryCategory.Queries.ViewModels;
using AutoMapper;
using Application.Exceptions;
using Microsoft.EntityFrameworkCore;


namespace Application.BakeryCategory.Commands.UpdateBakeryCategory
{
    public class UpdateBakeryCategoryHandler : IRequestHandler<UpdateBakeryCategoryCommand, BakeryCategoryViewModel>
    {
        private readonly BakeryStoreDbContext _bakeryStoreDbContext;
        private readonly IMapper _mapper;

        public UpdateBakeryCategoryHandler(BakeryStoreDbContext bakeryStoreDbContext, IMapper mapper)
        {
            _bakeryStoreDbContext = bakeryStoreDbContext;
            _mapper = mapper;
        }

        public async Task<BakeryCategoryViewModel> Handle(UpdateBakeryCategoryCommand request, CancellationToken cancellationToken)
        {
            var bakeryCategory = await _bakeryStoreDbContext.Categories.FirstOrDefaultAsync(Category => Category.Id == request.Id); // getting the category from the database context.
            if (bakeryCategory == null) // if the category is not found, throw an exception.
            {
                throw new NotFoundException("Category", $"{request.Id}");
            }
            if (!string.IsNullOrWhiteSpace(request.Name))
            {
                bakeryCategory.Name = request.Name;
            }

            await _bakeryStoreDbContext.SaveChangesAsync(cancellationToken);

            return _mapper.Map<BakeryCategoryViewModel>(bakeryCategory);
        }
    }
}