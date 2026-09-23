using TrainingCenter.Api.Entities;

namespace TrainingCenter.Api.DTOs.Tracks
{
    public class TrackStudentResponse
    {
        public Guid StudentId { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;

        public Guid EnrollmentId { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public EnrollmentStatus EnrollmentStatus { get; set; }
        public byte ProgressPercentage { get; set; }
    }
}
