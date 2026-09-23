using Microsoft.EntityFrameworkCore;
using TrainingCenter.Api.Entities;

namespace TrainingCenter.Api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<TrainingTrack> TrainingTracks { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Payment> Payments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Relationships and configurations for entities

            modelBuilder.Entity<Student>()
                .HasKey(s => s.StudentId);

            modelBuilder.Entity<Student>()
                .HasIndex(i => i.Email)
                .IsUnique();

            modelBuilder.Entity<Student>()
                .HasMany(s => s.Enrollments)
                .WithOne(e => e.Student)
                .HasForeignKey(e => e.StudentId);




            modelBuilder.Entity<Instructor>()
                .HasKey(i => i.InstructorId);

            modelBuilder.Entity<Instructor>()
                .HasIndex(i => i.Email)
                .IsUnique();

            modelBuilder.Entity<Instructor>()
                .HasMany(i => i.TrainingTracks)
                .WithOne(tt => tt.Instructor)
                .HasForeignKey(tt => tt.InstructorId);




            modelBuilder.Entity<TrainingTrack>()
                .HasKey(tt => tt.TrainingTrackId);

            modelBuilder.Entity<TrainingTrack>()
                .HasMany(tt => tt.Enrollments)
                .WithOne(e => e.TrainingTrack)
                .HasForeignKey(e => e.TrainingTrackId);




            modelBuilder.Entity<Enrollment>()
                .HasKey(e => e.EnrollmentId);

            modelBuilder.Entity<Enrollment>()
                .HasMany(e => e.Payments)
                .WithOne(p => p.Enrollment)
                .HasForeignKey(p => p.EnrollmentId);

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Student)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(e => e.StudentId);

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.TrainingTrack)
                .WithMany(tt => tt.Enrollments)
                .HasForeignKey(e => e.TrainingTrackId);




            modelBuilder.Entity<Payment>()
                .HasKey(p => p.PaymentId);

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Enrollment)
                .WithMany(e => e.Payments)
                .HasForeignKey(p => p.EnrollmentId);
        }


        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries()
                .Where(e => e.Entity is Student || e.Entity is Instructor || e.Entity is TrainingTrack || e.Entity is Enrollment || e.Entity is Payment)
                .ToList();
            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("CreatedAt").CurrentValue = DateTime.UtcNow;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Property("UpdatedAt").CurrentValue = DateTime.UtcNow;
                }
            }
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}
