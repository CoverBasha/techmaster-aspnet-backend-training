namespace TrainingCenter.Api.Entities
{
    public class Instructor
    {
        public Guid InstructorId { get; set; }

        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Specialization { get; set; } = null!;
        public string? Bio { get; set; }

        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation properties
        public ICollection<TrainingTrack> TrainingTracks { get; set; }
            = new List<TrainingTrack>();
    }
}