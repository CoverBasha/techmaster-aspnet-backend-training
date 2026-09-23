using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TrainingCenter.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            return Ok();
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetStudentById(Guid id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult CreateStudent()
        {
            return Ok();
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdateStudent(Guid id)
        {
            return Ok();
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
