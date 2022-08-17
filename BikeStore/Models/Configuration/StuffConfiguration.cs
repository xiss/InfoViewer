using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BikeStore.Models.Configuration
{
	public class StuffConfiguration : IEntityTypeConfiguration<Staff>
	{
		public void Configure(EntityTypeBuilder<Staff> builder)
		{
			builder.HasOne(s => s.Manager)
				.WithMany(s => s.Subordinates)
				.HasForeignKey(s => s.ManagerId);

			builder.HasOne(s => s.Store)
				.WithMany(s => s.Stuffs)
				.HasForeignKey(s => s.StoreId);

			builder.HasIndex(s => s.Email)
				.IsUnique();
		}
	}
}
