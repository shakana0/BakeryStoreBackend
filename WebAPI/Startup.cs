using Application;
using Application.BakeryProduct.Commands.UpdateBakeryProduct;
using Asp.Versioning;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Persistence;
using WebAPI.Infrastructure.Swagger;



namespace WebAPI
{
	public class Startup
	{
		public IConfiguration Configuration { get; }

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}
		// define the ConfigureServices method
		public void ConfigureServices(IServiceCollection services)
		{
			// Register the application services
			services.RegisterApplicationServices(Configuration);
			services.AddAutofac(); // Ensure Autofac is registered
								   // Register the database context
			services.AddDbContext<BakeryStoreDbContext>(options =>
			{
				options.UseSqlServer(Configuration.GetConnectionString("BakeryStoreDb"));
			});
			services.AddControllers(); // Register the controllers
			services.AddEndpointsApiExplorer(); // To register services that provide metadata about your API endpoints and is needed for the OpenAPI document
												// Adding MediatR to the service collection  
												//RegisterServicesFromAssemblies to scan the specified assemblies for handlers, requests, and other MediatR-related services.
			services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(UpdateBakeryProductCommand).Assembly));
			//Adding a versioning service to the service collection
			var apiVersioningBuilder = services.AddApiVersioning(o =>
			{
				o.ReportApiVersions = true; // configures the application to include information about the available API versions in the response headers
				o.ApiVersionReader = new UrlSegmentApiVersionReader(); // to read the API version from the URL segment
			});
			// Adding tool that helps you explore and test your APIs.
			apiVersioningBuilder.AddApiExplorer(options =>
			{
				options.GroupNameFormat = "VVV"; //sets the format for the group names of your API versions
				options.SubstituteApiVersionInUrl = true; //configures the application to include the API version in the URL
			});
			services.AddOpenApiDocument(Common.ApiVersion.ApiName, Common.ApiVersion.V1, Common.ApiVersion.V1UrlPath); // Register the OpenAPI document
		}
		// define the Configure method
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			// configure different behaviors for your application depending on the environment
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage(); // middleware that displays detailed error information when an exception occurs
			}
			else
			{
				app.UseHsts(); // middleware that adds the Strict-Transport-Security header to the response, only allowing HTTPS connections
				app.UseHttpsRedirection(); // middleware that redirects HTTP requests to HTTPS
			}

			// Ensure Database is created & apply migrations
			using (var scope = app.ApplicationServices.CreateScope())
			{
				var dbContext = scope.ServiceProvider.GetRequiredService<BakeryStoreDbContext>();
				dbContext.Database.Migrate(); // Ensures DB is created
											  // Call the helper method to create the scripts
				SqlScriptRunner.ExecuteDatabaseScripts(dbContext);
			}

			// Adding the Autofac container to the app so that it can manage dependencies between classes
			AutofacContainer = app.ApplicationServices.GetAutofacRoot();

			app.UseRouting(); // for directing requests to the correct endpoint, controllers and actions
			app.UseOpenApi(); // generates and serves the OpenAPI (Swagger) documentation for your API.
			app.UseSwaggerUiAsRootPath(); // serves the Swagger UI as the root path of the application
										  // ensures that the matched endpoint is executed
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
		public ILifetimeScope? AutofacContainer { get; private set; }
	}
}
