namespace TrainingCenter.Api.Entities
{
    public class Enrollment
    {
        public Guid EnrollmentId { get; set; }

        public Guid StudentId { get; set; }
        public Guid TrainingTrackId { get; set; }

        public DateTime EnrollmentDate { get; set; }

        public EnrollmentStatus Status { get; set; }

        public byte ProgressPercentage { get; set; }

        public float? FinalResult { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Navigation properties
        public Student Student { get; set; } = null!;
        public TrainingTrack TrainingTrack { get; set; } = null!;

        public ICollection<Payment> Payments { get; set; }
            = new List<Payment>();
    }
}