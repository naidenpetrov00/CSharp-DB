namespace CarSystem.Data.Configuration
{
    using CarSystem.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;


    public class MakeConfiguration : IEntityTypeConfiguration<Make>
    {
        public void Configure(EntityTypeBuilder<Make> make)
        {
            make
                .HasIndex(mk => mk.Name)
                .IsUnique();

            make
                 .HasMany(mk => mk.Models)
                 .WithOne(ml => ml.Make)
                 .HasForeignKey(ml => ml.MakeId)
                 .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
