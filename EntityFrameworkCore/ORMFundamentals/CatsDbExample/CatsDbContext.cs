namespace CatsDbExample
{
    using CatsDbExample.models;
    using Microsoft.EntityFrameworkCore;

    public class CatsDbContext : DbContext
    {
        public DbSet<Cat> Cats { get; set; }

        public DbSet<Owner> Owners { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-ERAGAG4\\SQLEXPRESS;Database=NewDb;Integrated Security=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Cat>()
                .HasOne(c => c.Owner)
                .WithMany(o => o.Cats)
                .HasForeignKey(c => c.OwnerId);
        }
    }
}
