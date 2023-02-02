namespace FootballBetting.Data.Configuration
{
    using FootballBetting.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> user)
        {
            user
                .Property(u => u.Username)
                .HasMaxLength(50)
                .IsRequired(true)
                .IsUnicode(true);

            user
                .Property(u => u.Password)
                .HasMaxLength(30)
                .IsRequired(true);

            user
                .Property(u => u.Email)
                .HasMaxLength(50)
                .IsRequired(true);

            user
                .Property(u => u.Name)
                .HasMaxLength(100)
                .IsRequired(true)
                .IsUnicode(true);

            user
                .Property(u => u.Balance)
                .IsRequired(true);
        }
    }
}
