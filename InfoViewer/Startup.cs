using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BikeStore.Repos;
using BikeStore.Models;
using BikeStore.Models.Datalnitialize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfoViewer
{
	public class Startup
	{
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			// Правильно ли добавлять их как синглтон?
			services.AddMvc();
			services.AddSingleton<Context>();
			services.AddSingleton<CategoryRepo>();
			services.AddSingleton<CustomerRepo>();
			services.AddSingleton<OrderItemRepo>();
			services.AddSingleton<OrderRepo>();
			services.AddSingleton<ProductRepo>();
			services.AddSingleton<StockRepo>();
			services.AddSingleton<StoreRepo>();
			services.AddSingleton<StuffRepo>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			// Пересодаем БД
			//TODO Убрать  в Конфиг
			//Datalnitializer datalnitializer = new Datalnitializer(new Context(), @"E:\Dropbox\dev\ITVDN\InfoViewer (ASP.Net)\ExpData");
			//datalnitializer.RecreateDatabase();

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseRouting();
			app.UseStaticFiles();
			
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute("Default", "{Controller=Orders}/{Action=Index}/{id?}");
			});
		}
	}
}
