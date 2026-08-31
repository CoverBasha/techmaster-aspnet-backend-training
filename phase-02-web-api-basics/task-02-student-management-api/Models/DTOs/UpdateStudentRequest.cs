using System.ComponentModel.DataAnnotations;

namespace task_02_student_management_api.Models.DTOs
{
    public class UpdateStudentRequest
    {
        [Required]
        public string Fullname { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Phone]
        public string Phone { get; set; }
        [Required]
        public string TrackName { get; set; }

    }
}
