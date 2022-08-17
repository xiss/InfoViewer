using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BikeStore.Models.Configuration
{
	public class OrderItemsConfiguration : IEntityTypeConfiguration<OrderItem>
	{
		public void Configure(EntityTypeBuilder<OrderItem> builder)
		{
			builder.HasKey(oi => new { oi.OrderId, oi.ItemId });

			builder.HasOne(o => o.Order)
				.WithMany(o => o.OrderItems)
				.HasForeignKey(o => o.OrderId);

			builder.HasOne(o=>o.Product)
				.WithMany(p=>p.OrderItems)
				.HasForeignKey(o=>o.ProductId);
		}
	}
}
