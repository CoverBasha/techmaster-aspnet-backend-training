using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace task_01_ef_core_modeling_drills.Entities
{
    public class TrainingTrack
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }

        [ForeignKey(nameof(Instructor))]
        [Required]
        public Guid InstructorId { get; set; }

        //Navigation Property
        public Instructor Instructor { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }

    }
}
