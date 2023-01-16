namespace Demo.Data
{
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;

    public partial class SoftUniContext : DbContext
    {
        public SoftUniContext()
        {
        }

        public SoftUniContext(DbContextOptions<SoftUniContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }

        public virtual DbSet<Department> Departments { get; set; }

        public virtual DbSet<Employee> Employees { get; set; }

        public virtual DbSet<MyFiredEmployee> MyFiredEmployees { get; set; }

        public virtual DbSet<Project> Projects { get; set; }

        public virtual DbSet<Town> Towns { get; set; }

        public virtual DbSet<VEmployeeNameJobTitle> VEmployeeNameJobTitles { get; set; }

        public virtual DbSet<VEmployeesSalaryInfo> VEmployeesSalaryInfos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
            => optionsBuilder.UseSqlServer("Server=DESKTOP-ERAGAG4\\SQLEXPRESS;Database=SoftUni;Integrated Security=True;Encrypt=False");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.AddressId).HasColumnName("AddressID");
                entity.Property(e => e.AddressText)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.TownId).HasColumnName("TownID");

                entity.HasOne(d => d.Town).WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.TownId)
                    .HasConstraintName("FK_Addresses_Towns");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
                entity.Property(e => e.ManagerId).HasColumnName("ManagerID");
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Manager).WithMany(p => p.Departments)
                    .HasForeignKey(d => d.ManagerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Departments_Employees");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable(tb => tb.HasTrigger("tr_SetUpdateOnDate"));

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
                entity.Property(e => e.AddressId).HasColumnName("AddressID");
                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.HireDate).HasColumnType("smalldatetime");
                entity.Property(e => e.JobTitle)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.ManagerId).HasColumnName("ManagerID");
                entity.Property(e => e.MiddleName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Salary).HasColumnType("money");
                entity.Property(e => e.UpdatedOn).HasColumnType("date");

                entity.HasOne(d => d.Address).WithMany(p => p.Employees)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("FK_Employees_Addresses");

                entity.HasOne(d => d.Department).WithMany(p => p.Employees)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employees_Departments");

                entity.HasOne(d => d.Manager).WithMany(p => p.InverseManager)
                    .HasForeignKey(d => d.ManagerId)
                    .HasConstraintName("FK_Employees_Employees");

                entity.HasMany(d => d.Projects).WithMany(p => p.Employees)
                    .UsingEntity<Dictionary<string, object>>(
                        "EmployeesProject",
                        r => r.HasOne<Project>().WithMany()
                            .HasForeignKey("ProjectId")
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FK_EmployeesProjects_Projects"),
                        l => l.HasOne<Employee>().WithMany()
                            .HasForeignKey("EmployeeId")
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FK_EmployeesProjects_Employees"),
                        j =>
                        {
                            j.HasKey("EmployeeId", "ProjectId");
                        });
            });

            modelBuilder.Entity<MyFiredEmployee>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.JobTitle)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");
                entity.Property(e => e.Description).HasColumnType("ntext");
                entity.Property(e => e.EndDate).HasColumnType("smalldatetime");
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.StartDate).HasColumnType("smalldatetime");
            });

            modelBuilder.Entity<Town>(entity =>
            {
                entity.ToTable(tb => tb.HasTrigger("tr_NoEmptyTownsNames"));

                entity.Property(e => e.TownId).HasColumnName("TownID");
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VEmployeeNameJobTitle>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToView("V_EmployeeNameJobTitle");

                entity.Property(e => e.FullName)
                    .HasMaxLength(152)
                    .IsUnicode(false)
                    .HasColumnName("Full Name");
                entity.Property(e => e.JobTitle)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Job Title");
            });

            modelBuilder.Entity<VEmployeesSalaryInfo>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToView("v_EmployeesSalaryInfo");

                entity.Property(e => e.FullName)
                    .HasMaxLength(101)
                    .IsUnicode(false)
                    .HasColumnName("Full Name");
                entity.Property(e => e.Salary).HasColumnType("money");
            });
            modelBuilder.HasSequence<int>("sq_MySequence");
            modelBuilder.HasSequence<int>("sq_MySequence1")
                .StartsAt(10L)
                .IncrementsBy(10)
                .HasMin(10L)
                .HasMax(50L);
            modelBuilder.HasSequence<int>("sq_MySequence2")
                .StartsAt(10L)
                .IncrementsBy(10)
                .HasMin(10L)
                .HasMax(50L)
                .IsCyclic();

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}