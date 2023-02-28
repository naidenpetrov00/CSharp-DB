namespace PetStore.Data.Configuration
{
	using PetStore.Data.Models;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	internal class OrderConfiguration : IEntityTypeConfiguration<Order>
	{
		public void Configure(EntityTypeBuilder<Order> builder)
		{
			builder
				.HasOne(o => o.User)
				.WithMany(u => u.Orders)
				.HasForeignKey(u => u.UserId)
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
