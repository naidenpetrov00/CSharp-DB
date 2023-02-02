namespace FootballBetting.Data.Configuration
{
    using FootballBetting.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PlayerConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> player)
        {
            player
                .Property(e => e.Name)
                .HasMaxLength(50)
                .IsRequired(true)
                .IsUnicode(true);

            player
                .Property(e => e.SquadNumber)
                .HasMaxLength(3)
                .IsRequired(true);

            player
                .Property(e => e.IsInjured)
                .IsRequired(true);

            player
                .HasOne(p => p.Team)
                .WithMany(t => t.Players)
                .HasForeignKey(p => p.TeamId);

            player
                .HasOne(p => p.Position)
                .WithMany(pn => pn.Players)
                .HasForeignKey(p => p.PositionId);
        }
    }
}
