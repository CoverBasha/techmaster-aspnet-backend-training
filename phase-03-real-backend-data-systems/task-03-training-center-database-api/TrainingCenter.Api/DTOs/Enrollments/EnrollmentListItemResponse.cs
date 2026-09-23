using TrainingCenter.Api.Entities;

namespace TrainingCenter.Api.DTOs.Enrollments
{
    public class EnrollmentListItemResponse
    {
        public Guid EnrollmentId { get; set; }

        public Guid StudentId { get; set; }
        public string StudentName { get; set; } = null!;

        public Guid TrainingTrackId { get; set; }
        public string TrackTitle { get; set; } = null!;

        public DateTime EnrollmentDate { get; set; }
        public EnrollmentStatus Status { get; set; }
        public byte ProgressPercentage { get; set; }
        public float? FinalResult { get; set; }
    }
}
