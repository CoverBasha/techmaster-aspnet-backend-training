using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TrainingCenter.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllEnrollments()
        {
            return Ok();
        }
        [HttpGet("{id:guid}")]
        public IActionResult GetEnrollmentById(Guid id)
        {
            return Ok();
        }
        [HttpPost]
        public IActionResult EnrollInTrack()
        {
            return Ok();
        }
        [HttpPut("{id:guid}/status")]
        public IActionResult ChangeEnrollmentStatus(Guid id)
        {
            return Ok();
        }
        [HttpDelete("{id:guid}")]
        public IActionResult DeleteEnrollment(Guid id)
        {
            return Ok();
        }

        [HttpGet("{id:guid}/payments")]
        public IActionResult GetEnrollmentPayments(Guid id)
        {
            return Ok();
        }

    }
}
