using task_02_student_management_api.Models;
using task_02_student_management_api.Models.DTOs;

namespace task_02_student_management_api.Services
{
    public class StudentsService
    {
        public static Dictionary<Guid, Student> Students { get; set; } = [];

        public ServiceResponse<IEnumerable<StudentResponse>> GetStudents()
        {
            return new() {
                Status = Status.Success,
                Result = Students.Values.Select(s => new StudentResponse
                {
                    Id = s.Id,
                    Fullname = s.Fullname,
                    Email = s.Email,
                    Phone = s.Phone,
                    EnrollmentDate = s.EnrollmentDate,
                    IsActive = s.IsActive,
                    TrackName = s.TrackName
                }).AsEnumerable()

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


            
    }
}
