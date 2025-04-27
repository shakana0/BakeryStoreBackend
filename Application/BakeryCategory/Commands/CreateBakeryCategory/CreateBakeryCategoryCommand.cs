using MediatR;

namespace Application.BakeryCategory.Commands.CreateBakeryCategory
{
    public class CreateBakeryCategoryCommand : IRequest<int>
    {
        public string Name { get; set; }

    }
}