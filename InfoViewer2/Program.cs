using InfoViewer.Models;
using System.Text;

namespace InfoViewer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();
            //app.UseHttpLogging( );
            app.UseErrorHandling();
            app.UseRouting();
            

            //app.Run(async (context) =>
            //{
            //    context.Response.ContentType = "text/plain; charset=utf-8";


            //    await context.Response.WriteAsync(ShowCustomers());
            //});

            app.Run();
        }
    }
	#region
	public class RoutingMiddleware
    {
        private readonly RequestDelegate next;
        public RoutingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            switch (context.Request.Path)
            {
                case "/customers":
                    await context.Response.WriteAsync("Customers");
                    break;
                case "/orders":
                    await context.Response.WriteAsync("Orders");
                    break;
                default:
                    context.Response.StatusCode = 404;
                    break;
            }
        }

    }

    static class RequestExtension
    {
        public static IApplicationBuilder UseRouting (this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RoutingMiddleware>();
        }
    }

    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;
        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync (HttpContext context)
        {
            await next.Invoke(context);
            if (context.Response.StatusCode == 404)
            {
                await context.Response.WriteAsync("Not Found");
            }
           
        }
    }
    public static class ErrorExtension
    {
        public static  IApplicationBuilder UseErrorHandling(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }


	//public class CustomersMiddleware
	//{
	//    private readonly RequestDelegate next;
	//    public CustomersMiddleware(RequestDelegate next)
	//    {
	//        this.next = next;
	//    }

	//    public async Task InvokeAsync(HttpContext context)
	//    {
	//        await context.Response.WriteAsync("Customers");
	//    }
	//}

	//public class HomeMiddleware
	//{
	//    private readonly RequestDelegate next;
	//    public HomeMiddleware(RequestDelegate next)
	//    {
	//        this.next = next;
	//    }
	//    public async Task InvokeAsync(HttpContext context)
	//    {
	//        await context.Response.WriteAsync("Home");
	//    }
	//}
	//public class OrdersMiddleware
	//{
	//    private readonly RequestDelegate next;
	//    public OrdersMiddleware(RequestDelegate next)
	//    {
	//        this.next = next;
	//    }
	//    public async Task InvokeAsync(HttpContext context)
	//    {
	//        await context.Response.WriteAsync("Orders");
	//    }
	//}
	#endregion

}