using TrainingCenter.Api.Entities;

namespace TrainingCenter.Api.DTOs.Enrollments
{
    public class EnrollmentQueryParameters
    {
        public EnrollmentStatus? Status { get; set; }
        public Guid? TrackId { get; set; }
        public Guid? StudentId { get; set; }
        public PaymentStatus? PaymentStatus { get; set; }
    }
}
