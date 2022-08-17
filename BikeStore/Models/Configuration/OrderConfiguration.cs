using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BikeStore.Models.Configuration
{
	public class OrderConfiguration : IEntityTypeConfiguration<Order>
	{
		public void Configure(EntityTypeBuilder<Order> builder)
		{
			builder.HasOne(o => o.Customer)
				.WithMany(c => c.Orders)
				.HasForeignKey(o => o.CustomerId)
				.OnDelete(DeleteBehavior.Cascade);

			builder.HasOne(o => o.Store)
				.WithMany(s => s.Orders)
				.HasForeignKey(o => o.StoreId)				
				.OnDelete(DeleteBehavior.Cascade);

			builder.HasOne(o => o.Stuff)
				.WithMany(s => s.Orders)
				.HasForeignKey(o => o.StuffId)
				.OnDelete(DeleteBehavior.NoAction);
		}
	}
}
