namespace FootballBetting.Data.Configuration
{
    using FootballBetting.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class BetCofiguration : IEntityTypeConfiguration<Bet>
    {
        public void Configure(EntityTypeBuilder<Bet> bet)
        {
            bet
                .Property(b => b.Amount)
                .IsRequired(true);

            bet
                .Property(b => b.Prediction)
                .IsRequired(true);

            bet.Property(b=>b.DateTime)
                .IsRequired(true);

            bet
                .HasOne(b => b.User)
                .WithMany(u => u.Bets)
                .HasForeignKey(b => b.UserId);

            bet
                .HasOne(b => b.Game)
                .WithMany(g => g.Bets)
                .HasForeignKey(b => b.GameId);
        }
    }
}
