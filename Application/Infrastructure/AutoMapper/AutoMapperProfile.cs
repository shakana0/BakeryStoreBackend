using Application.BakeryProduct.Commands.CreateBakeryProduct;
using Application.BakeryProduct.Commands.UpdateBakeryProduct;
using Application.BakeryProduct.Queries.ViewModels;
using AutoMapper;
using Domain;


namespace Application.Infrastructure.AutoMapper
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<CreateBakeryProductCommand, Product>()
							.ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId));
			CreateMap<Product, BakeryProductViewModel>()
			.ConstructUsing(source => new BakeryProductViewModel(source));

			CreateMap<UpdateBakeryProductCommand, Product>();
		}
	}
}
