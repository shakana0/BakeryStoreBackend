using MediatR;

namespace Application.BakeryProduct.Queries.GetBakeryProductDetails
{
    public class GetBakeryProductDetailsQuery : IRequest<BakeryProductDetailsViewModel>
    {
        public int ProductId { get; set; }
    }
}