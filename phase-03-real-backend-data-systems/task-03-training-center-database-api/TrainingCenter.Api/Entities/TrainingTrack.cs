using System.Threading.Tasks;

namespace TrainingCenter.Api.Entities
{
    public class TrainingTrack
    {
        public Guid TrainingTrackId { get; set; }

        public string Title { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string? Description { get; set; }

        public int Level { get; set; }
        public int Capacity { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public TrackStatus Status { get; set; }

        public Guid InstructorId { get; set; }
        public DateTime CreatedAt { get; set; }

        public bool IsDeleted { get; set; }

        // Navigation properties
        public Instructor Instructor { get; set; } = null!;

        public ICollection<Enrollment> Enrollments { get; set; }
            = new List<Enrollment>();
    }
}