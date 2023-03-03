namespace PetStore.Data.Configuration
{
	using PetStore.Data.Models;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	public class FoodConfiguration : IEntityTypeConfiguration<Food>
	{
		public void Configure(EntityTypeBuilder<Food> builder)
		{
			builder.HasKey(f => f.Id);
		}
	}
}
