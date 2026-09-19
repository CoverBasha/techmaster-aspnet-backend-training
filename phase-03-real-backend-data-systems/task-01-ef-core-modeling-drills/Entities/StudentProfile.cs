using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace task_01_ef_core_modeling_drills.Entities
{
    public class StudentProfile
    {
        [ForeignKey(nameof(Student))]
        [Key]
        public Guid StudentID { get; set; }
        [Required]
        [StringLength(14)]
        [RegularExpression(@"^\d+$", ErrorMessage = "National ID must contain numbers only.")]
        public string NationalId { get; set; }
        [Required]
        public string Address { get; set; }
        [Phone]
        public string EmergencyPhone { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
    }
}
