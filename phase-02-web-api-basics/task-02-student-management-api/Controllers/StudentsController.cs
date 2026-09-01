using Microsoft.AspNetCore.Mvc;
using task_02_student_management_api.DTOs;
using task_02_student_management_api.Services;

namespace task_02_student_management_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentsService studentsService;

        public StudentsController(IStudentsService studentsService)
        {
            this.studentsService = studentsService;
        }

        [HttpGet]
        public IActionResult GetAllStudents([FromQuery]int? pageNumber, [FromQuery]int? pageSize)
        {
            var response = studentsService.GetStudents(pageNumber, pageSize);
            return Ok(response.Result);
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetStudentById([FromRoute] Guid id)
        {
            var response = studentsService.GetStudentById(id);

            if (response.Status == Status.NotFound)
                return NotFound(response.Message);

            return Ok(response.Result);
        }

        [HttpPost]
        public IActionResult CreateStudent([FromBody] CreateStudentRequest dto)
        {
            var response = studentsService.CreateStudent(dto);

            if (response.Status == Status.Failure)
                return BadRequest(response.Message);

            return CreatedAtAction(nameof(CreateStudent), response.Result);
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdateStudent([FromRoute] Guid id, [FromBody] UpdateStudentRequest dto)
        {
            var response = studentsService.UpdateStudent(id, dto);

            if (response.Status == Status.NotFound)
                return NotFound(response.Message);
            if (response.Status == Status.Failure)
                return BadRequest(response.Message);

            return Ok(response.Result);
        }

        [HttpPatch("{id:guid}")]
        public IActionResult ChangeStudentStatus(Guid id, [FromBody] UpdateStudentStatusRequest dto)
        {
            var response = studentsService.UpdateStudentStatus(id, dto);
            if (response.Status == Status.NotFound)
                return NotFound(response.Message);

            return Ok(response.Result);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteStudent([FromRoute] Guid id)
        {
            var response = studentsService.DeleteStudent(id);
            if (response.Status == Status.NotFound)
                return NotFound(response.Message);

            return NoContent();
        }

        [HttpGet("by-track/{trackName}")]
        public IActionResult StudentsByTrack([FromRoute] string trackName, [FromQuery] int? pageNumber, [FromQuery] int? pageSize)
        {
            var response = studentsService.GetByTrack(trackName, pageNumber, pageSize);

            if (response.Status == Status.NotFound)
                return NotFound(response.Message);
            if(response.Status == Status.Failure)
                return BadRequest(response.Message);

            return Ok(response.Result);
        }

        [HttpGet("stats")]
        public IActionResult StudentsStats()
        {
            var response = studentsService.StudentStats();
            return Ok(response.Result);
        }
    }
}
