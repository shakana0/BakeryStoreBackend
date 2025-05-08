using Application.BakeryCategory.Commands.CreateBakeryCategory;
using Application.BakeryCategory.Queries.ViewModels;
using Application.BakeryIngredient.Commands.CreateBakeryIngredient;
using Application.BakeryProduct.Commands.CreateBakeryProduct;
using Application.BakeryProduct.Commands.UpdateBakeryProduct;
using Application.BakeryProduct.Queries.ViewModels;
using Application.BakeryProductIngredient.Commands.CreateBakeryProductIngredient;
using AutoMapper;
using Domain;


namespace Application.Infrastructure.AutoMapper
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{   //Product mappings
			CreateMap<CreateBakeryProductCommand, Product>()
							.ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId));
			CreateMap<Product, BakeryProductViewModel>()
			.ConstructUsing(source => new BakeryProductViewModel(source));
			CreateMap<UpdateBakeryProductCommand, Product>();

			//Category Mappings
			CreateMap<CreateBakeryCategoryCommand, Category>(); //creation --> from CreateBakeryCategoryCommand to Category entity
			CreateMap<Category, BakeryCategoryViewModel>(); // get --> from entity to viewmodel

			//Ingredient mappings
			CreateMap<CreateBakeryIngredientCommand, Ingredient>();
			CreateMap<Ingredient, CreateBakeryIngredientCommand>();

			//ProductIngredient mappings
			CreateMap<CreateBakeryProductIngredientCommand, ProductIngredient>()
				.ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
				.ForMember(dest => dest.IngredientId, opt => opt.MapFrom(src => src.IngredientId));

			CreateMap<ProductIngredient, CreateBakeryProductIngredientCommand>();
		}
	}
}
