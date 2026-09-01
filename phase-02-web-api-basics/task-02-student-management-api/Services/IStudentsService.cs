using task_02_student_management_api.DTOs;

namespace task_02_student_management_api.Services
{
    public interface IStudentsService
    {
        ServiceResponse<PagedResultResponse> GetStudents(int? pageNumber, int? pageSize);
        ServiceResponse<StudentResponse> GetStudentById(Guid id);
        ServiceResponse<StudentResponse> CreateStudent(CreateStudentRequest dto);
        ServiceResponse<StudentResponse> UpdateStudent(Guid id, UpdateStudentRequest dto);
        ServiceResponse<StudentResponse> UpdateStudentStatus(Guid id, UpdateStudentStatusRequest dto);
        ServiceResponse<bool> DeleteStudent(Guid id);
        public ServiceResponse<PagedResultResponse> GetByTrack(string trackName, int? pageNumber, int? pageSize);
        ServiceResponse<StudentStatsResponse> StudentStats();
    }
}
