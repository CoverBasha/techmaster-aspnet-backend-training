using Microsoft.AspNetCore.Mvc;
using TrainingCenter.Api.Services;

namespace TrainingCenter.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly ReportService reportService;

        public ReportsController(ReportService reportService)
        {
            this.reportService = reportService;
        }



        [HttpGet("dashboard-summary")]
        public async Task<IActionResult> GetDashboardSummary()
        {
            return Ok();
        }

        [HttpGet("unpaid-enrollments")]
        public async Task<IActionResult> GetUnpaidEnrollments()
        {
            var response = await reportService.GetUnpaidOrPartiallyPaidEnrollmentsAsync();
            return Ok(response.Data);
        }

        [HttpGet("track-capacity")]
        public async Task<IActionResult> GetTrackCapacity()
        {
            var response = await reportService.GetCapacityPerTrack();
            return Ok(response.Data);
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
