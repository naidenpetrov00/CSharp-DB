namespace FootballBetting.Data.Configuration
{
    using FootballBetting.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> game)
        {
            game
                .Property(g => g.HomeTeamGoals)
                .IsRequired(true);

            game
                .Property(g => g.AwayTeamGoals)
                .IsRequired(true);

            game
                .Property(g => g.DateTime)
                .IsRequired(true);

            game
                .Property(g => g.HomeTeamBetRate)
                .IsRequired(true);

            game
                .Property(g => g.AwayTeamBetRate)
                .IsRequired(true);

            game
                .Property(g => g.Result)
                .HasMaxLength(7)
                .IsRequired(true)
                .IsUnicode(true);

            game
               .HasOne(g => g.HomeTeam)
               .WithMany(t => t.HomeGames)
               .HasForeignKey(g => g.HomeTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            game
                .HasOne(g => g.AwayTeam)
                .WithMany(t => t.AwayGames)
                .HasForeignKey(g => g.AwayTeamId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
