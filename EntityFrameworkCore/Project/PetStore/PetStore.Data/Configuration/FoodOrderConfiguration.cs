namespace PetStore.Data.Configuration
{
	using PetStore.Data.Models;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	public class FoodOrderConfiguration : IEntityTypeConfiguration<FoodOrder>
	{
		public void Configure(EntityTypeBuilder<FoodOrder> builder)
		{
			builder
				.HasKey(fo => new { fo.FoodId, fo.OrderId });

			builder
				.HasOne(fo => fo.Food)
				.WithMany(f => f.Orders)
				.HasForeignKey(f => f.FoodId)
				.OnDelete(DeleteBehavior.Restrict);

			builder
				.HasOne(fo => fo.Order)
				.WithMany(o => o.Food)
				.HasForeignKey(o => o.OrderId)
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
