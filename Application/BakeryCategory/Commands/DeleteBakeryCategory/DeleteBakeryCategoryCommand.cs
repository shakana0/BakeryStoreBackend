using MediatR;

namespace Application.BakeryCategory.Commands.DeleteBakeryCategory
{
    public class DeleteBakeryCategoryCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}