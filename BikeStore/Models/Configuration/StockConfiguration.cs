using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BikeStore.Models.Configuration
{
	public class StockConfiguration : IEntityTypeConfiguration<Stock>
	{
		public void Configure(EntityTypeBuilder<Stock> builder)
		{
			builder.HasKey(s => new { s.StoreId, s.ProductId });

			builder.HasOne(s=>s.Product)
				.WithMany(p=>p.Stocks)
				.HasForeignKey(s => s.ProductId);

			builder.HasOne(s=>s.Store)
				.WithMany(s=>s.Stocks)
				.HasForeignKey(s=>s.StoreId);
		}
	}
}