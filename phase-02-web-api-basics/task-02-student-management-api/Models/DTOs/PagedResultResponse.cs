namespace task_02_student_management_api.Models.DTOs
{
    public class PagedResultResponse
    {
        public StudentResponse StudentDto { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
    }
}
