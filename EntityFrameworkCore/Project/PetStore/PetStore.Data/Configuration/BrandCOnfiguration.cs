namespace PetStore.Data.Configuration
{
	using PetStore.Data.Models;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	public class BrandCOnfiguration : IEntityTypeConfiguration<Brand>
	{
		public void Configure(EntityTypeBuilder<Brand> builder)
		{
			builder
				.HasMany(b => b.Food)
				.WithOne(f => f.Brand)
				.HasForeignKey(f => f.BrandId)
				.OnDelete(DeleteBehavior.Restrict);

			builder
			.HasMany(b => b.Toys)
			.WithOne(t => t.Brand)
			.HasForeignKey(t => t.BrandId)
			.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
