using task_02_student_management_api.DTOs;
using task_02_student_management_api.Models;

namespace task_02_student_management_api.Services
{
    public class StudentsService : IStudentsService
    {
        public static Dictionary<Guid, Student> Students { get; set; } = [];

        public ServiceResponse<PagedResultResponse> GetStudents(int? pageNumber, int? pageSize)
        {
            var students = Students.Values.Select(s => new StudentResponse
            {
                Id = s.Id,
                Fullname = s.Fullname,
                Email = s.Email,
                Phone = s.Phone,
                EnrollmentDate = s.EnrollmentDate,
                IsActive = s.IsActive,
                TrackName = s.TrackName
            }).AsEnumerable();

            return new()
            {
                Status = Status.Success,
                Result = GetPagedStudents(students, pageNumber, pageSize)
            };
        }

        public ServiceResponse<StudentResponse> GetStudentById(Guid id)
        {
            if (!Students.TryGetValue(id, out Student? student))
                return new() { Status = Status.NotFound, Message = $"Student with ID: {id} not found" };

            return new()
            {
                Status = Status.Success,
                Result = new()
                {
                    Id = student.Id,
                    Fullname = student.Fullname,
                    Email = student.Email,
                    Phone = student.Phone,
                    EnrollmentDate = student.EnrollmentDate,
                    IsActive = student.IsActive,
                    TrackName = student.TrackName
                }
            };
        }

        public ServiceResponse<StudentResponse> CreateStudent(CreateStudentRequest dto)
        {
            if (string.IsNullOrEmpty(dto.Fullname))
                return new() { Status = Status.Failure, Message = "Name cannot be empty" };

            Student student = new()
            {
                Id = Guid.NewGuid(),
                Fullname = dto.Fullname,
                Email = dto.Email,
                Phone = dto.Phone,
                TrackName = dto.TrackName,
                IsActive = true,
                EnrollmentDate = DateTime.UtcNow
            };

            Students.Add(student.Id, student);

            return new()
            {
                Status = Status.Success,
                Result = new()
                {
                    Id = student.Id,
                    Fullname = student.Fullname,
                    Email = student.Email,
                    Phone = student.Phone,
                    EnrollmentDate = student.EnrollmentDate,
                    IsActive = student.IsActive,
                    TrackName = student.TrackName
                }
            };
        }

        public ServiceResponse<StudentResponse> UpdateStudent(Guid id, UpdateStudentRequest dto)
        {
            if (!Students.TryGetValue(id, out Student? student))
                return new() { Status = Status.NotFound, Message = $"Student with ID: {id} not found" };

            if (string.IsNullOrEmpty(dto.Fullname))
                return new() { Status = Status.Failure, Message = "Name cannot be empty" };

            student.Fullname = dto.Fullname;
            student.Email = dto.Email;
            student.Phone = dto.Phone;
            student.TrackName = dto.TrackName;

            Students[id] = student;

            return new()
            {
                Status = Status.Success,
                Result = new()
                {
                    Id = student.Id,
                    Fullname = student.Fullname,
                    Email = student.Email,
                    Phone = student.Phone,
                    EnrollmentDate = student.EnrollmentDate,
                    IsActive = student.IsActive,
                    TrackName = student.TrackName
                }
            };
        }

        public ServiceResponse<StudentResponse> UpdateStudentStatus(Guid id, UpdateStudentStatusRequest dto)
        {
            if (!Students.TryGetValue(id, out Student? student))
                return new() { Status = Status.NotFound, Message = $"Student with ID: {id} not found" };

            Students[id].IsActive = dto.IsActive;

            return new()
            {
                Status = Status.Success,
                Result = new()
                {
                    Id = student.Id,
                    Fullname = student.Fullname,
                    Email = student.Email,
                    Phone = student.Phone,
                    EnrollmentDate = student.EnrollmentDate,
                    IsActive = dto.IsActive,
                    TrackName = student.TrackName
                }
            };
        }

        public ServiceResponse<bool> DeleteStudent(Guid id)
        {
            if(!Students.Remove(id))
                return new() { Status = Status.NotFound, Message = $"Student with ID: {id} not found" };

            return new ServiceResponse<bool> { Status = Status.Success };
        }

        public ServiceResponse<PagedResultResponse> GetByTrack(string trackName, int? pageNumber,int?pageSize)
        {
            if (string.IsNullOrEmpty(trackName))
                return new() { Status = Status.Failure, Message = "Track name cannot be empty" };

            var studentsInTrack = Students.Values
                .Where(s => s.TrackName.Equals(trackName, StringComparison.OrdinalIgnoreCase))
                .Select(s => new StudentResponse
                {
                    Id = s.Id,
                    Fullname = s.Fullname,
                    Email = s.Email,
                    Phone = s.Phone,
                    EnrollmentDate = s.EnrollmentDate,
                    IsActive = s.IsActive,
                    TrackName = s.TrackName
                }).AsEnumerable();

            if (!studentsInTrack.Any())
                return new() { Status = Status.NotFound, Message = $"No students found in track: {trackName}" };

            return new()
            {
                Status = Status.Success,
                Result = GetPagedStudents(studentsInTrack, pageNumber, pageSize)
            };
        }

        public ServiceResponse<StudentStatsResponse> StudentStats()
        {
            return new()
            {
                Status = Status.Success,
                Result = new()
                {
                    TotalCount = Students.Count,
                    TotalActive = Students.Values.Count(s => s.IsActive),
                    TotalInactive = Students.Values.Count(s => !s.IsActive),
                    TrackCounts = Students.Values
                        .GroupBy(s => s.TrackName)
                        .Select(g => new TrackCount { TrackName = g.Key, Count = g.Count() })
                        .AsEnumerable()
                }
            };
        }

        private static PagedResultResponse GetPagedStudents(IEnumerable<StudentResponse> students,int? pageNumber, int? pageSize)
        {
            pageNumber ??= 1;
            pageSize ??= 10;

            var totalCount = students.Count();
            var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
            var pagedStudents = students
                .Skip((int)((pageNumber - 1) * pageSize))
                .Take((int)pageSize)
                .AsEnumerable();
            return new()
            {
                Students = pagedStudents,
                PageNumber = (int)pageNumber,
                PageSize = (int)pageSize,
                TotalCount = totalCount,
                TotalPages = totalPages
            };
        }
    }
}
