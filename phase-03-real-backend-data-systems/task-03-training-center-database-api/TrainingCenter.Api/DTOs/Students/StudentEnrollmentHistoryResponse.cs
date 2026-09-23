using TrainingCenter.Api.Entities;

namespace TrainingCenter.Api.DTOs.Students
{
    public class StudentEnrollmentHistoryResponse
    {
        public Guid EnrollmentId { get; set; }

        public Guid TrainingTrackId { get; set; }
        public string TrackTitle { get; set; } = null!;

        public DateTime EnrollmentDate { get; set; }
        public EnrollmentStatus Status { get; set; }
        public byte ProgressPercentage { get; set; }
        public float? FinalResult { get; set; }
    }
}
