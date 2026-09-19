using System.ComponentModel.DataAnnotations;

namespace task_01_ef_core_modeling_drills.Entities
{
    public class Instructor
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Fullname { get; set; }
        public ICollection<TrainingTrack> TrainingTracks { get; set; }
    }
}
