namespace PetStore.Data.Configuration
{
	using PetStore.Data.Models;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	public class PetConfiguration : IEntityTypeConfiguration<Pet>
	{
		public void Configure(EntityTypeBuilder<Pet> builder)
		{
			builder
				.HasOne(p => p.Breed)
				.WithMany(b => b.Pets)
				.HasForeignKey(b => b.BreedId)
				.OnDelete(DeleteBehavior.Restrict);

			builder
				.HasOne(p => p.Order)
				.WithMany(o => o.Pets)
				.HasForeignKey(o => o.OrderId)
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
