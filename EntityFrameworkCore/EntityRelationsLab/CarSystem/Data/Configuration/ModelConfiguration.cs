namespace CarSystem.Data.Configuration
{
    using CarSystem.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ModelConfiguration : IEntityTypeConfiguration<Model>
    {
        public void Configure(EntityTypeBuilder<Model> model)
        {
            model
                .HasMany(ml => ml.Cars)
                .WithOne(c => c.Model)
                .HasForeignKey(c => c.ModelId);
        }
    }
}
