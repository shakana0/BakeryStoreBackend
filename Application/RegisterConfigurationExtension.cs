using Application.Infrastructure.AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
	public static class RegisterConfigurationExtension
	{
		public static IServiceCollection RegisterApplicationServices(this IServiceCollection services, IConfiguration configuration)
		{
			//services.RegisterConfiguration<EventTemplateMappings>(configuration);
			//services.AddTransient<IIntegrationEventHandler<UserIntegrationEvent>, NotificationEventHandler>();
			//services.AddTransient<NotificationEventHandler>();

			//services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
			//services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
			//services.AddValidatorsFromAssemblyContaining<UpdateEmergencyMessageCommandValidator>();

			services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);
			return services;
		}
	}
}
