using Microsoft.AspNetCore.Mvc;
using task_02_student_management_api.Models.DTOs;
using task_02_student_management_api.Services;

namespace task_02_student_management_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly StudentsService studentsService;

        public StudentsController(StudentsService studentsService)
        {
            this.studentsService = studentsService;
        }

        [HttpGet]
        public IActionResult GetAllStudents()
        {
            var response = studentsService.GetStudents();
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
        public IActionResult ChangeStudentStatus([FromBody] UpdateStudentStatusRequest dto)
        {
            return Ok();
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteStudent([FromRoute] Guid id)
        {
            return Ok();
        }

        [HttpGet("by-track/{trackName}")]
        public IActionResult StudentsByTrack([FromRoute] string trackName)
        {
            return Ok();
        }

        [HttpGet("stats")]
        public IActionResult StudentsStats()
        {
            return Ok();
        }
    }
}
