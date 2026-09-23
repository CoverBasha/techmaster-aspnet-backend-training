namespace TrainingCenter.Api.DTOs.Enrollments
{
    public class CreateEnrollmentRequest
    {
        public Guid StudentId { get; set; }
        public Guid TrainingTrackId { get; set; }
    }
}
