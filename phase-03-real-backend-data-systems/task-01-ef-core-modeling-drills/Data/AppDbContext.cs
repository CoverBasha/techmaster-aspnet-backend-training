using Microsoft.EntityFrameworkCore;
using task_01_ef_core_modeling_drills.Entities;

namespace task_01_ef_core_modeling_drills.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentProfile> StudentProfiles { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<TrainingTrack> TrainingTracks { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<PaymentSummary> PaymentSummaries { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Enrollment join entity relationship configuration

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Student)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(e => e.StudentId);

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.TrainingTrack)
                .WithMany(t => t.Enrollments)
                .HasForeignKey(e => e.TrackId);


            //Seeding

            var student1Id = Guid.Parse("11111111-1111-1111-1111-111111111111");
            var student2Id = Guid.Parse("22222222-2222-2222-2222-222222222222");
            var student3Id = Guid.Parse("33333333-3333-3333-3333-333333333333");
            var student4Id = Guid.Parse("44444444-4444-4444-4444-444444444444");
            var student5Id = Guid.Parse("55555555-5555-5555-5555-555555555555");

            var instructor1Id = Guid.Parse("11111111-1111-1111-1111-111111111111");
            var instructor2Id = Guid.Parse("22222222-2222-2222-2222-222222222222");

            var track1Id = Guid.Parse("33333333-3333-3333-3333-333333333333");
            var track2Id = Guid.Parse("44444444-4444-4444-4444-444444444444");
            var track3Id = Guid.Parse("55555555-5555-5555-5555-555555555555");

            var enrollment1Id = Guid.Parse("66666666-6666-6666-6666-666666666666");
            var enrollment2Id = Guid.Parse("77777777-7777-7777-7777-777777777777");
            var enrollment3Id = Guid.Parse("88888888-8888-8888-8888-888888888888");
            var enrollment4Id = Guid.Parse("99999999-9999-9999-9999-999999999999");
            var enrollment5Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa");

            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    Id = student1Id,
                    Fullname = "Omar Hassan",
                    Email = "omar.hassan@example.com",
                    CreatedAt = new DateTime(2026, 9, 1)
                },
                new Student
                {
                    Id = student2Id,
                    Fullname = "Youssef Ahmed",
                    Email = "youssef.ahmed@example.com",
                    CreatedAt = new DateTime(2026, 9, 1)
                },
                new Student
                {
                    Id = student3Id,
                    Fullname = "Karim Mahmoud",
                    Email = "karim.mahmoud@example.com",
                    CreatedAt = new DateTime(2026, 9, 1)
                },
                new Student
                {
                    Id = student4Id,
                    Fullname = "Mariam Adel",
                    Email = "mariam.adel@example.com",
                    CreatedAt = new DateTime(2026, 9, 1)
                },
                new Student
                {
                    Id = student5Id,
                    Fullname = "Nour Khaled",
                    Email = "nour.khaled@example.com",
                    CreatedAt = new DateTime(2026, 9, 1)
                }
            );

            modelBuilder.Entity<StudentProfile>().HasData(
                new StudentProfile
                {
                    StudentID = student1Id,
                    NationalId = "30101234567891",
                    Address = "Nasr City, Cairo",
                    EmergencyPhone = "01012345678",
                    DateOfBirth = new DateTime(2002, 5, 14)
                },
                new StudentProfile
                {
                    StudentID = student2Id,
                    NationalId = "30202345678912",
                    Address = "Maadi, Cairo",
                    EmergencyPhone = "01123456789",
                    DateOfBirth = new DateTime(2001, 9, 22)
                },
                new StudentProfile
                {
                    StudentID = student3Id,
                    NationalId = "30303456789123",
                    Address = "Heliopolis, Cairo",
                    EmergencyPhone = "01234567890",
                    DateOfBirth = new DateTime(2003, 2, 8)
                },
                new StudentProfile
                {
                    StudentID = student4Id,
                    NationalId = "30404567891234",
                    Address = "New Cairo, Cairo",
                    EmergencyPhone = "01098765432",
                    DateOfBirth = new DateTime(2002, 11, 30)
                },
                new StudentProfile
                {
                    StudentID = student5Id,
                    NationalId = "30505678912345",
                    Address = "Dokki, Giza",
                    EmergencyPhone = "01187654321",
                    DateOfBirth = new DateTime(2001, 7, 17)
                }
            );

            modelBuilder.Entity<Instructor>().HasData(
                new Instructor
                {
                    Id = instructor1Id,
                    Fullname = "Ahmed Hassan"
                },
                new Instructor
                {
                    Id = instructor2Id,
                    Fullname = "Mariam Ibrahim"
                }
            );

            modelBuilder.Entity<TrainingTrack>().HasData(
                new TrainingTrack
                {
                    Id = track1Id,
                    Name = ".NET Backend Development",
                    InstructorId = instructor1Id
                },
                new TrainingTrack
                {
                    Id = track2Id,
                    Name = "Database Fundamentals",
                    InstructorId = instructor1Id
                },
                new TrainingTrack
                {
                    Id = track3Id,
                    Name = "Cloud Development",
                    InstructorId = instructor2Id
                }
            );

            modelBuilder.Entity<Enrollment>().HasData(
                new Enrollment
                {
                    Id = enrollment1Id,
                    StudentId = student1Id,
                    TrackId = track1Id,
                    EnrollmentDate = new DateTime(2026, 9, 1),
                    FinalGrade = 88.5f
                },
                new Enrollment
                {
                    Id = enrollment2Id,
                    StudentId = student2Id,
                    TrackId = track1Id,
                    EnrollmentDate = new DateTime(2026, 9, 2),
                    FinalGrade = 92.0f
                },
                new Enrollment
                {
                    Id = enrollment3Id,
                    StudentId = student3Id,
                    TrackId = track2Id,
                    EnrollmentDate = new DateTime(2026, 9, 3),
                    FinalGrade = 76.5f
                },
                new Enrollment
                {
                    Id = enrollment4Id,
                    StudentId = student4Id,
                    TrackId = track3Id,
                    EnrollmentDate = new DateTime(2026, 9, 4),
                    FinalGrade = 95.0f
                },
                new Enrollment
                {
                    Id = enrollment5Id,
                    StudentId = student5Id,
                    TrackId = track1Id,
                    EnrollmentDate = new DateTime(2026, 9, 5),
                    FinalGrade = 81.0f
                }
            );

        }


        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e =>
                    e.Entity is Student &&
                    (e.State == EntityState.Added ||
                     e.State == EntityState.Modified));

            foreach (var entry in entries)
            {
                var student = (Student)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    student.CreatedAt = DateTime.UtcNow;
                }
                else if (entry.State == EntityState.Modified)
                {
                    student.UpdatedAt = DateTime.UtcNow;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
