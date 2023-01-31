namespace CarSystem.Data.Configuration
{
    using CarSystem.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> car)
        {
            car
               .HasIndex(c => c.Vin)
               .IsUnique();
        }
    }
}
