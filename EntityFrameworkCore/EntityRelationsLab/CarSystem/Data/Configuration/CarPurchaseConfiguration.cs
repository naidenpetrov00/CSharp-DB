namespace CarSystem.Data.Configuration
{
    using CarSystem.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CarPurchaseConfiguration : IEntityTypeConfiguration<CarPurchase>
    {
        public void Configure(EntityTypeBuilder<CarPurchase> purchase)
        {
            purchase.HasKey(p => new
            {
                p.CustomerId,
                p.CarId
            });

            purchase
            .HasOne(p => p.Customer)
            .WithMany(c => c.Purchases)
            .HasForeignKey(p => p.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

            purchase
            .HasOne(p => p.Car)
            .WithMany(c => c.Owners)
            .HasForeignKey(p => p.CarId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
