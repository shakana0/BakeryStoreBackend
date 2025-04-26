using Autofac.Extensions.DependencyInjection;

namespace WebAPI
{
	public class Program
	{
		public static void Main(string[] args)
		{
			CreateHostBuilder(args).Build().Run(); // calls and runs the CreateHostBuilder method
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args) //Creates a default host builder with pre-configured settings.
				.UseServiceProviderFactory(new AutofacServiceProviderFactory()) //Specifies that Autofac will be used as the dependency injection container.
			.ConfigureWebHostDefaults(webBuilder =>
			{
				webBuilder.UseStartup<Startup>(); //Configures the web host with default settings and specifies Startup as the class that will configure the application�s services and request pipeline.
			}).ConfigureAppConfiguration((context, configuration) => //Configures the application�s configuration settings.
			{
				//configuration.AddAzureKeyVaultAppSettings();
			});
	}
}
