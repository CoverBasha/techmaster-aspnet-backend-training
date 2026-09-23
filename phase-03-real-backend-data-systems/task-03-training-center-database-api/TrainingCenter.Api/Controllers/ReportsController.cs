using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TrainingCenter.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        [HttpGet("dashboard-summary")]
        public IActionResult GetDashboardSummary()
        {
            return Ok();
        }

        [HttpGet("unpaid-enrollments")]
        public IActionResult GetUnpaidEnrollments()
        {
            return Ok();
        }

        [HttpGet("track-capacity")]
        public IActionResult GetTrackCapacity()
        {
            return Ok();
        }

        [HttpGet("revenue-summary")]
        public IActionResult GetRevenueSummary()
        {
            return Ok();
        }

        [HttpGet("revenue-by-track")]
        public IActionResult GetRevenueByTrack()
        {
            return Ok();
        }
    }
}
