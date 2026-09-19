using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using task_01_ef_core_modeling_drills.Data;
using task_01_ef_core_modeling_drills.DTOs;

namespace task_01_ef_core_modeling_drills.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly AppDbContext context;

        public StudentsController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudentsAsync([FromQuery] int? pageNumber = 1, [FromQuery] int? pageSize = 5)
        {

            pageNumber = pageNumber < 1 ? 1 : pageNumber;
            pageSize = pageSize < 1 ? 5 : pageSize;

            ///////////////////////////////
            //Drill 9: Projection into DTOs
            ///////////////////////////////

            var students = await context.Students.Where(s => !s.IsDeleted)
                .Include(s => s.StudentProfile)
                .Select(s => new StudentDto
                {
                    Id = s.Id,
                    Fullname = s.Fullname,
                    Email = s.Email,
                    StudentProfileDto = new StudentProfileDto
                    {
                        Address = s.StudentProfile.Address,
                        DateOfBirth = s.StudentProfile.DateOfBirth,
                        EmergencyPhone = s.StudentProfile.EmergencyPhone,
                        NationalId = s.StudentProfile.NationalId
                    },
                    CreatedAt = s.CreatedAt,
                    UpdatedAt = s.UpdatedAt,
                    IsActive = s.IsActive,
                    IsDeleted = s.IsDeleted,
                    DeletedAt = s.DeletedAt
                })
                .Skip((int)((pageNumber - 1) * pageSize)).Take((int)pageSize) 
                .ToListAsync();



            ///////////////////////
            // Drill 10: Pagination
            ///////////////////////

            var result = new PaginationResult
            {
                Students = students,
                PageNumber = (int)pageNumber,
                PageSize = (int)pageSize,
                TotalRecords = students.Count,
                TotalPages = (int)Math.Ceiling((double)students.Count / pageSize.Value)
            };

            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetStudentByIdAsync(Guid id)
        {
            var student = await context.Students.Include(s => s.StudentProfile).Where(s => s.Id == id).Select(s => new StudentDto
            {
                Id = s.Id,
                Fullname = s.Fullname,
                Email = s.Email,
                StudentProfileDto = new StudentProfileDto
                {
                    Address = s.StudentProfile.Address,
                    DateOfBirth = s.StudentProfile.DateOfBirth,
                    EmergencyPhone = s.StudentProfile.EmergencyPhone,
                    NationalId = s.StudentProfile.NationalId
                },
                CreatedAt = s.CreatedAt,
                UpdatedAt = s.UpdatedAt,
                IsActive = s.IsActive,
                IsDeleted = s.IsDeleted,
                DeletedAt = s.DeletedAt
            }).FirstOrDefaultAsync();
            if (student == null)
            {
                return NotFound("Student not found");
            }
            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudentAsync([FromBody] CreateStudentDto createStudentDto)
        {
            var student = new Entities.Student
            {
                Id = Guid.NewGuid(),
                Fullname = createStudentDto.Fullname,
                Email = createStudentDto.Email,
                IsActive = true,
                IsDeleted = false,
                StudentProfile = new Entities.StudentProfile
                {
                    Address = createStudentDto.StudentProfileDto.Address,
                    EmergencyPhone = createStudentDto.StudentProfileDto.EmergencyPhone,
                    DateOfBirth = createStudentDto.StudentProfileDto.DateOfBirth
                }
            };

            await context.Students.AddAsync(student);
            await context.SaveChangesAsync();

            return Ok("Created Successfully");
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateStudentAsync(Guid id, [FromBody] UpdateStudentDto updateStudentDto)
        {
            var student = await context.Students.Include(s => s.StudentProfile).FirstOrDefaultAsync(s => s.Id == id);
            if (student == null)
            {
                return NotFound("Student not found");
            }
            student.Fullname = updateStudentDto.Fullname;
            student.Email = updateStudentDto.Email;
            if (student.StudentProfile != null)
            {
                student.StudentProfile.Address = updateStudentDto.StudentProfileDto.Address;
                student.StudentProfile.EmergencyPhone = updateStudentDto.StudentProfileDto.EmergencyPhone;
                student.StudentProfile.DateOfBirth = updateStudentDto.StudentProfileDto.DateOfBirth;
            }
            await context.SaveChangesAsync();
            return Ok("Updated Successfully");
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteStudentAsync(Guid id)
        {
            var student = await context.Students.FirstOrDefaultAsync(s => s.Id == id);
            if (student == null)
            {
                return NotFound("Student not found");
            }
            student.IsDeleted = true;
            student.DeletedAt = DateTime.UtcNow;
            await context.SaveChangesAsync();
            return Ok("Deleted Successfully");
        }
    }
}
