using Application.BakeryCategory.Queries.ViewModels;
using MediatR;

namespace Application.BakeryCategory.Queries.GetBakeryCategory
{
    public class GetBakeryCategoryQuery : IRequest<BakeryCategoryViewModel>
    {
        public int Id { get; set; }
    }
}
