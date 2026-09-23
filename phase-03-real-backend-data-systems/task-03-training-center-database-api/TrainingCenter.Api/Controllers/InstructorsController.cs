using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TrainingCenter.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllInstructors()
        {
            return Ok();
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetInstructorById(Guid id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult CreateInstructor()
        {
            return Ok();
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdateInstructor(Guid id)
        {
            return Ok();
        }

        [HttpGet("{id:guid}/tracks")]
        public IActionResult GetInstructorTracks(Guid id)
        {
            return Ok();
        }
    }
}
