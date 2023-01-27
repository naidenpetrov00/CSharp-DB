namespace HospitalDatabase.Data
{
    using HospitalDatabase.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using static DataSettings;

    public class HospitalDbContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Visitation> Visitations { get; set; }
        public DbSet<Diagnose> Diagnoses { get; set; }
        public DbSet<Medicament> Medicament { get; set; }
        public DbSet<PatientMedicament> PatientMedicaments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Patient
            modelBuilder
                .Entity<Patient>(entity =>
            {
                entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(50);

                entity.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(50);

                entity.Property(e => e.Address)
                .HasMaxLength(250);

                entity.Property(e => e.Email)
                .HasMaxLength(80)
                .IsUnicode(false);

                entity.Property(e => e.HasInsurance)
                .IsRequired();
            });

            modelBuilder
                .Entity<Patient>()
                .HasMany(pt => pt.Visitations)
                .WithOne(vs => vs.Patient)
                .HasForeignKey(e => e.PatientId);

            modelBuilder
                .Entity<Patient>()
                .HasMany(pt => pt.Diagnoses)
                .WithOne(d => d.Patient)
                .HasForeignKey(e => e.PatientId);

            //Visitation
            modelBuilder
                .Entity<Visitation>(entity =>
            {
                entity.Property(e => e.Date)
               .IsRequired();

                entity.Property(e => e.Comments)
                .HasMaxLength(250)
                .IsRequired();
            });

            //Diagnose
            modelBuilder
                .Entity<Diagnose>(entity =>
            {
                entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);

                entity.Property(e => e.Comments)
                .HasMaxLength(250);
            });

            //Medicament
            modelBuilder
                .Entity<Medicament>(entity => entity
                .Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50));

            //PatientMedicaments
            modelBuilder
                .Entity<PatientMedicament>()
                .HasKey(pm => new
                {
                    pm.PatientId,
                    pm.MedicamentId
                });

            modelBuilder
                .Entity<PatientMedicament>()
                .HasOne(md => md.Patient)
                .WithMany(pt => pt.Prescriptions)
                .HasForeignKey(md => md.PatientId);

            modelBuilder
               .Entity<PatientMedicament>()
               .HasOne(pt => pt.Medication)
               .WithMany(md => md.Prescriptions)
               .HasForeignKey(pt => pt.MedicamentId);
        }
    }
}
