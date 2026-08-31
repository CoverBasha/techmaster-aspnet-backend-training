using System.ComponentModel.DataAnnotations;

namespace task_02_student_management_api.Models.DTOs
{
    public class UpdateStudentStatusRequest
    {
        [Required]
        public bool IsActive { get; set; }
    }
}
