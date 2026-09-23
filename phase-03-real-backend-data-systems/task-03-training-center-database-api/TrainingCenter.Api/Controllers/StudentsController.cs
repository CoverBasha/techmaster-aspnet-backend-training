using Microsoft.AspNetCore.Mvc;
using TrainingCenter.Api.DTOs.Students;
using TrainingCenter.Api.Services;

namespace TrainingCenter.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly StudentService studentService;

        public StudentsController(StudentService studentService)
        {
            this.studentService = studentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudentsAsync(
            [FromQuery] string? keyword,
            [FromQuery] bool? isActive,
            [FromQuery] int?pageNumber,
            [FromQuery]int?pageSize)
        {
            var response = await studentService.GetAllStudentsAsync(keyword, isActive, pageNumber, pageSize);

            return Ok(response.Data);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetStudentByIdAsync(Guid id)
        {
            var response = await studentService.GetStudentByIdAsync(id);

            if (response.Status == Status.NotFound)
                return NotFound(response.Message);

            return Ok(response.Data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudentAsync([FromBody]CreateStudentRequest createStudentRequest)
        {
            var response = await studentService.CreateStudentAsync(createStudentRequest);

            if (response.Status == Status.Error)
                return BadRequest(response.Message);

            return Ok();
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateStudent(Guid id,[FromBody]UpdateStudentRequest updateStudentRequest)
        {
            var response = await studentService.UpdateStudentAsync(id, updateStudentRequest);
            
            if (response.Status == Status.NotFound)
                return NotFound(response.Message);
            if (response.Status == Status.Error)
                return BadRequest(response.Message);

            return Ok(response.Data);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteStudent(Guid id)
        {
            return Ok();
        }

        [HttpGet("{id:guid}/enrollments")]
        public IActionResult GetStudentEnrollments(Guid id)
        {
            return Ok();
        }


    }
}
