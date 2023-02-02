namespace FootballBetting.Data.Configuration
{
    using FootballBetting.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> country)
        {
            country
                .Property(e => e.Name)
                .HasMaxLength(50)
                .IsRequired(true)
                .IsUnicode(true);
        }
    }
}
