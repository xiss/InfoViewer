using BikeStore.Models.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace BikeStore.Models
{
	public class Context : DbContext
	{
		public DbSet<Brand> Brands { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Stock> Stocks { get; set; }
		public DbSet<Customer> Customers { get; set; }
		public DbSet<OrderItem> OrderItems { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<Store> Stores { get; set; }
		public DbSet<Staff> Stuffs { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new OrderItemsConfiguration());
			modelBuilder.ApplyConfiguration(new StockConfiguration());
			modelBuilder.ApplyConfiguration(new StuffConfiguration());
			modelBuilder.ApplyConfiguration(new ProductConfiguration());
			modelBuilder.ApplyConfiguration(new OrderConfiguration());
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			ConfigurationBuilder builder = new ConfigurationBuilder();
			builder.SetBasePath(Directory.GetCurrentDirectory());
			builder.AddJsonFile("appsettings.json");
			var config = builder.Build();
			string connectionString = config.GetConnectionString("DefaultConnection"); 

			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer(connectionString);
				optionsBuilder.UseLazyLoadingProxies();
			}
		}
	}
}
