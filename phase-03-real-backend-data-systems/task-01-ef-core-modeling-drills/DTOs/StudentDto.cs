namespace task_01_ef_core_modeling_drills.DTOs
{
    public class StudentDto
    {
        public Guid Id { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }

        public StudentProfileDto StudentProfileDto { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; }
        public DateTime DeletedAt { get; set; }

    }

    public class StudentProfileDto
    {
        public string NationalId { get; set; }
        public string Address { get; set; }
        public string EmergencyPhone { get; set; }
        public DateTime DateOfBirth { get; set; }
    }

    public class PaginationResult
    {
        public IEnumerable<StudentDto> Students { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
        public int TotalPages { get; set; }
    }

    public class CreateStudentDto
    {
        public string Fullname { get; set; }
        public string Email { get; set; }
        public CreateStudentProfileDto StudentProfileDto { get; set; }

    }

    public class CreateStudentProfileDto
    {
        public string Address { get; set; }
        public string EmergencyPhone { get; set; }
        public DateTime DateOfBirth { get; set; }
    }

    public class UpdateStudentDto
    {
        public string Fullname { get; set; }
        public string Email { get; set; }
        public UpdateStudentProfileDto StudentProfileDto { get; set; }

    }

    public class UpdateStudentProfileDto
    {
        public string Address { get; set; }
        public string EmergencyPhone { get; set; }
        public DateTime DateOfBirth { get; set; }

    }

}
