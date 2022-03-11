using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Application;
using Domain;
using Web;
using Infrastructure;

namespace Startup
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services
				.AddApplication()
				.AddDomain()
				.AddInfrastructure(Configuration)
				.AddWebComponents();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();

				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Error");
			}

			app
				.UseRouting()
				.UseCors(options => options
					.AllowAnyOrigin()
					.AllowAnyHeader()
					.AllowAnyMethod())
				.UseStaticFiles()
				.UseEndpoints(endpoints => endpoints
				.MapControllers());
		}
	}
}
