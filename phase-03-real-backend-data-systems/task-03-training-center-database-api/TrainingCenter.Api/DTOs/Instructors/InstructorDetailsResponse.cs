namespace TrainingCenter.Api.DTOs.Instructors
{
    public class InstructorDetailsResponse
    {
        public Guid InstructorId { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Specialization { get; set; } = null!;
        public string Bio { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }
    }
}
