using Application.BakeryCategory.Queries.ViewModels;
using MediatR;

namespace Application.BakeryCategory.Commands.UpdateBakeryCategory
{

    public class UpdateBakeryCategoryCommand : IRequest<BakeryCategoryViewModel>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void SetBakeryCategoryId(int id) => Id = id; // This method is used to set the Id of the bakery category. It is private and not used in this class, but it can be used in other classes that inherit from this class.
    }
}