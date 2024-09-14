using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using NSwag;
using NSwag.AspNetCore;
using NSwag.Generation.AspNetCore;

namespace WebAPI.Infrastructure.Swagger
{
	public static class SwaggerDocumentExtensions
	{
		public static IServiceCollection AddOpenApiDocument(this IServiceCollection serviceCollection, string apiName, string version, string urlPath)
		{
			serviceCollection.AddSwaggerDocument(delegate (AspNetCoreOpenApiDocumentGeneratorSettings config)
			{
				config.DocumentName = "v" + urlPath;
				config.ApiGroupNames = new string[1] { urlPath };
				//config.ApiGroupNames = [urlPath];
				config.PostProcess = delegate (OpenApiDocument document)
				{
					document.Info.Title = "Backend " + apiName + " API Version " + version;
					document.Info.Version = version;
					document.Schemes.Add(OpenApiSchema.Https);
					document.Info.Description = "Presentation " + apiName + " Api";
					document.Info.TermsOfService = "None";
					document.BasePath = "/api/v" + urlPath;
				};
			});
			return serviceCollection;
		}

		public static IApplicationBuilder UseSwaggerUiAsRootPath(this IApplicationBuilder app)
		{
			app.UseSwaggerUi(delegate (SwaggerUiSettings config)
			{
				config.TransformToExternalPath = (string internalUiRoute, HttpRequest request) => (internalUiRoute.StartsWith("/") && !internalUiRoute.StartsWith(request.PathBase)) ? (request.PathBase + internalUiRoute) : internalUiRoute;
				config.Path = string.Empty;
			});
			return app;
		}
	}
}