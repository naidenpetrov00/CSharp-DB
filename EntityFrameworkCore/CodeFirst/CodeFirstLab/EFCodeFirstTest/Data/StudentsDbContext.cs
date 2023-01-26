namespace EFCodeFirstTest.Data
{
    using EFCodeFirstTest.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class StudentsDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentInCourse> StudentsInCourses { get; set; }
        public DbSet<Homework> Homeworks { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(DataSettings.DefaultConnection);

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Student>()
                .HasOne(s => s.Town)
                .WithMany(t => t.Students)
                .HasForeignKey(s => s.TownId);

            modelBuilder
                .Entity<Student>()
                .HasMany(st => st.Homeworks)
                .WithOne(hw => hw.Student)
                .HasForeignKey(hw => hw.StudentId);

            modelBuilder
                .Entity<Course>()
                .HasMany(c => c.Homeworks)
                .WithOne(hw => hw.Course)
                .HasForeignKey(hw => hw.CourseId);

            modelBuilder.Entity<StudentInCourse>()
                .HasKey(sc => new
                {
                    sc.StudentId,
                    sc.CourseId
                });

            modelBuilder
                .Entity<StudentInCourse>()
                .HasOne(sc => sc.Student)
                .WithMany(st => st.Courses)
                .HasForeignKey(sc => sc.StudentId);

            modelBuilder
                .Entity<StudentInCourse>()
                .HasOne(sc => sc.Course)
                .WithMany(c => c.Students)
                .HasForeignKey(sc => sc.CourseId);
        }
    }
}
