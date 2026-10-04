namespace TrainingCenter.Api.DTOs.Instructors
{
    public class InstructorListItemResponse
    {
        public Guid InstructorId { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public bool IsActive { get; set; }
    }
}
