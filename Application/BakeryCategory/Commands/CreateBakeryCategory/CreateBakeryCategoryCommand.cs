using MediatR;

namespace Application.BakeryCategory.Commands.CreateBakeryCategory
{
    public class CreateBakeryCategoryCommand : IRequest<int>
    {
        public required string Name { get; set; }

    }
}