namespace PetStore.Data.Configuration
{
	using PetStore.Data.Models;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	public class ToyOrderConfiguration : IEntityTypeConfiguration<ToyOrder>
	{
		public void Configure(EntityTypeBuilder<ToyOrder> builder)
		{
			builder
				.HasKey(to=> new { to.ToyId, to.OrderId });

			builder
				.HasOne(to => to.Toy)
				.WithMany(f => f.Orders)
				.HasForeignKey(f => f.ToyId)
				.OnDelete(DeleteBehavior.Restrict);

			builder
				.HasOne(fo => fo.Order)
				.WithMany(o => o.Toys)
				.HasForeignKey(o => o.OrderId)
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
