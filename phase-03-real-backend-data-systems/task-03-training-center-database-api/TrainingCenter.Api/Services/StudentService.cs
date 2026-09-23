using Microsoft.EntityFrameworkCore;
using TrainingCenter.Api.Data;
using TrainingCenter.Api.DTOs.Enrollments;
using TrainingCenter.Api.DTOs.Students;
using TrainingCenter.Api.Entities;

namespace TrainingCenter.Api.Services
{
    public class StudentService
    {
        private readonly ApplicationDbContext context;

        public StudentService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<ServiceResponse<List<StudentListItemResponse>>> GetAllStudentsAsync(string? keyword, bool? isActive, int? pageNumber, int? pageSize)
        {
            pageNumber = pageNumber == null || pageNumber < 1 ? 1 : pageNumber;
            pageSize = pageSize == null || pageSize < 1 ? 10 : pageSize;

            var studentsQuery = context.Students.AsQueryable();

            if (isActive.HasValue)
                studentsQuery = studentsQuery.Where(s => s.IsActive == isActive.Value);

            if (!string.IsNullOrEmpty(keyword))
                studentsQuery = studentsQuery.Where(s =>
                s.FullName.Contains(keyword, StringComparison.CurrentCultureIgnoreCase)
                || s.Email.Contains(keyword, StringComparison.CurrentCultureIgnoreCase));


            studentsQuery = studentsQuery
                    .Skip((pageNumber.Value - 1) * pageSize.Value)
                    .Take(pageSize.Value);

            var students = await studentsQuery.Select(s => new StudentListItemResponse
            {
                StudentId = s.StudentId,
                FullName = s.FullName,
                Email = s.Email,
                IsActive = s.IsActive
            }).ToListAsync();

            return new() { Data = students, Message = "Students retrieved successfully." };
        }

        public async Task<ServiceResponse<StudentDetailsResponse>> GetStudentByIdAsync(Guid id)
        {
            var student = await context.Students.Select(s => new StudentDetailsResponse
            {
                StudentId = s.StudentId,
                FullName = s.FullName,
                Email = s.Email,
                PhoneNumber = s.PhoneNumber,
                CreatedAt = s.CreatedAt,
                UpdatedAt = s.UpdatedAt,
                IsActive = s.IsActive

            }).FirstOrDefaultAsync(s => s.StudentId == id);

            if (student == null)
                return new() { Status = Status.NotFound, Message = "Student not found." };

            return new() { Data = student, Message = "Student retrieved successfully." };
        }

        public async Task<ServiceResponse<List<EnrollmentListItemResponse>>> GetStudentEnrollmentHistory(Guid studentId)
        {
            var student = await context.Students.FindAsync(studentId);

            if (student == null)
                return new() { Status = Status.NotFound, Message = "Student not found." };

            var enrollments = await context.Enrollments.Include(t => t.TrainingTrack).Where(e => e.StudentId == studentId)
                .Select(e => new EnrollmentListItemResponse
                {
                    EnrollmentId = e.EnrollmentId,
                    StudentId = e.StudentId,
                    StudentName = student.FullName,
                    EnrollmentDate = e.EnrollmentDate,
                    TrainingTrackId = e.TrainingTrackId,
                    TrackTitle = e.TrainingTrack.Title,
                    Status = e.Status,
                    ProgressPercentage = e.ProgressPercentage,
                    FinalResult = e.FinalResult
                }).ToListAsync();


            return new() { Data = enrollments, Message = "Student enrollment history retrieved successfully." };
        }

        public async Task<ServiceResponse<StudentDetailsResponse>> CreateStudentAsync(CreateStudentRequest createStudentRequest)
        {
            var student = new Student
            {
                FullName = createStudentRequest.FullName,
                Email = createStudentRequest.Email,
                PhoneNumber = createStudentRequest.PhoneNumber,
            };

            try
            {
                await context.Students.AddAsync(student);
                await context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                var response = new ServiceResponse<StudentDetailsResponse> { Status = Status.Error };

                if (ex.InnerException != null && ex.InnerException.Message.Contains("duplicate"))
                    response.Message = "A student with the same email already exists.";
                else
                    response.Message = "An error occurred while updating the student.";
                return response;
            }
        

            var studentDetailsResponse = new StudentDetailsResponse
            {
                StudentId = student.StudentId,
                FullName = student.FullName,
                Email = student.Email,
                PhoneNumber = student.PhoneNumber,
                CreatedAt = student.CreatedAt,
                UpdatedAt = student.UpdatedAt,
                IsActive = student.IsActive
            };

            return new() { Data = studentDetailsResponse, Message = "Student created successfully." };
        }

        public async Task<ServiceResponse<StudentDetailsResponse>> UpdateStudentAsync(Guid id, UpdateStudentRequest updateStudentRequest)
        {
            var student = await context.Students.FindAsync(id);
            
            if (student == null)
                return new() { Status = Status.NotFound, Message = "Student not found." };

            student.FullName = updateStudentRequest.FullName;
            student.Email = updateStudentRequest.Email;
            student.PhoneNumber = updateStudentRequest.PhoneNumber;
            student.IsActive = updateStudentRequest.IsActive;
            
            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                var response = new ServiceResponse<StudentDetailsResponse> { Status = Status.Error };

                if (ex.InnerException != null && ex.InnerException.Message.Contains("duplicate"))
                    response.Message = "A student with the same email already exists.";
                else
                    response.Message = "An error occurred while updating the student.";
                return response;
            }

            var studentDetailsResponse = new StudentDetailsResponse
            {
                StudentId = student.StudentId,
                FullName = student.FullName,
                Email = student.Email,
                PhoneNumber = student.PhoneNumber,
                CreatedAt = student.CreatedAt,
                UpdatedAt = student.UpdatedAt,
                IsActive = student.IsActive 
            };
            return new() { Data = studentDetailsResponse, Message = "Student updated successfully." };
        }

        public async Task<ServiceResponse<bool>> DeleteStudentAsync(Guid id)
        {
            var student = await context.Students.FindAsync(id);
            if (student == null)
                return new() { Data = false, Status = Status.NotFound, Message = "Student not found." };
            student.IsDeleted = true;
            student.DeletedAt = DateTime.UtcNow;
            await context.SaveChangesAsync();
            return new() { Data = true, Message = "Student deleted successfully." };
        }
    }
}
