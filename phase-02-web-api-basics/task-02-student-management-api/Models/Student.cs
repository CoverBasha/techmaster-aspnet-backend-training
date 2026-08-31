namespace task_02_student_management_api.Models
{
    public class Student
    {
        public Guid Id { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string TrackName { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public bool IsActive { get; set; }

    }
}
