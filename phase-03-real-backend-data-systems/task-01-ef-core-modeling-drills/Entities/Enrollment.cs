using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace task_01_ef_core_modeling_drills.Entities
{
    public class Enrollment
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey(nameof(Student))]
        public Guid StudentId { get; set; }
        [ForeignKey(nameof(TrainingTrack))]
        public Guid TrackId { get; set; }
        [Required]
        public DateTime EnrollmentDate { get; set; }
        [Required]
        public float FinalGrade { get; set; }

        //Navigation properties
        public Student Student { get; set; }
        public TrainingTrack TrainingTrack { get; set; }
        public PaymentSummary PaymentSummary { get; set; }
    }
}
