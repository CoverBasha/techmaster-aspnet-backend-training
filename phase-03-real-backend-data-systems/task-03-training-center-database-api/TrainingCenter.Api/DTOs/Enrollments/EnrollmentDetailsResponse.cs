using TrainingCenter.Api.DTOs.Shared;
using TrainingCenter.Api.Entities;

namespace TrainingCenter.Api.DTOs.Enrollments
{
    public class EnrollmentDetailsResponse
    {
        public Guid EnrollmentId { get; set; }

        public StudentSummaryResponse Student { get; set; } = null!;
        public TrackSummaryResponse Track { get; set; } = null!;

        public DateTime EnrollmentDate { get; set; }
        public EnrollmentStatus Status { get; set; }
        public byte ProgressPercentage { get; set; }
        public float? FinalResult { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public List<PaymentResponse> Payments { get; set; } = new();
    }
}
