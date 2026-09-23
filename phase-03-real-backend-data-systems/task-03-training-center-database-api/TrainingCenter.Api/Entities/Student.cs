namespace TrainingCenter.Api.Entities
{
    public class Student
    {
        public Guid StudentId { get; set; }

        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? PhoneNumber { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }

        // Navigation properties
        public ICollection<Enrollment> Enrollments { get; set; }
            = new List<Enrollment>();
    }
}
