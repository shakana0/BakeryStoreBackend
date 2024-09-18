using Application.BakeryProduct.Commands.UpdateBakeryProduct;
using Application.Infrastructure.AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
	public static class RegisterConfigurationExtension
	{
		public static IServiceCollection RegisterApplicationServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
			services.AddValidatorsFromAssemblyContaining<UpdateBakeryProductCommandValidator>();

			services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);
			return services;
		}
	}
}
