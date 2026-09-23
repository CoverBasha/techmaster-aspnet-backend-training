namespace TrainingCenter.Api.DTOs.Shared
{
    public class StudentSummaryResponse
    {
        public Guid StudentId { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
