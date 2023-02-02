namespace FootballBetting.Data.Configuration
{
    using FootballBetting.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PlayerStatisticConfiguration : IEntityTypeConfiguration<PlayerStatistic>
    {
        public void Configure(EntityTypeBuilder<PlayerStatistic> playerStatistic)
        {
            playerStatistic
                .HasKey(ps => new
                {
                    ps.PlayerId,
                    ps.GameId
                });

            playerStatistic
                .Property(ps => ps.ScoredGoals)
                .IsRequired(true);

            playerStatistic
                .Property (ps => ps.Assists)
                .IsRequired(true);

            playerStatistic
                .Property(ps => ps.MinutesPlayed)
                .IsRequired(true);

            playerStatistic
                .HasOne(ps => ps.Game)
                .WithMany(g => g.PlayerStatistics)
                .HasForeignKey(ps => ps.GameId);

            playerStatistic
               .HasOne(ps => ps.Player)
               .WithMany(g => g.PlayerStatistics)
               .HasForeignKey(ps => ps.PlayerId);
        }
    }
}
