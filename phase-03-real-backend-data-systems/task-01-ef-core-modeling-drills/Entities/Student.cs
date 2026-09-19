using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace task_01_ef_core_modeling_drills.Entities
{
    public class Student
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Fullname { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; }
        public DateTime DeletedAt { get; set; }

        //Navigation property
        public StudentProfile StudentProfile { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
