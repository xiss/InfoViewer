using BikeStore.Models;
using BikeStore.Models.Datalnitialize;
using BikeStore.Repos;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace InfoViewer
{
	public class Startup
	{
		public IConfiguration Configuration { get; }

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public void ConfigureServices(IServiceCollection services)
		{
			// Правильно ли добавлять их как Scoped?
			services.AddMvc();
			services.AddScoped<Context>();
			services.AddScoped<CategoryRepo>();
			services.AddScoped<CustomerRepo>();
			services.AddScoped<OrderItemRepo>();
			services.AddScoped<OrderRepo>();
			services.AddScoped<ProductRepo>();
			services.AddScoped<StockRepo>();
			services.AddScoped<StoreRepo>();
			services.AddScoped<StuffRepo>();
			services.Configure<AppOptions>(Configuration.GetSection(AppOptions.App));
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public async void Configure(IApplicationBuilder app, IWebHostEnvironment env, IOptions<AppOptions> options)
		{
			// Пересодаем БД
			if (options.Value.SampleData)
			{
				Datalnitializer datalnitializer = new Datalnitializer(new Context(), options.Value.SampleDataPath);
				datalnitializer.RecreateDatabase();
			}

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseRouting();
			app.UseStaticFiles();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute("Default", "{Controller=Orders}/{Action=Orders}/{id?}");
			});
		}
	}
}