using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TrainingCenter.Api.DTOs.Enrollments;
using TrainingCenter.Api.Entities;
using TrainingCenter.Api.Services;

namespace TrainingCenter.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentsController : ControllerBase
    {
        private readonly EnrollmentService enrollmentService;

        public EnrollmentsController(EnrollmentService enrollmentService)
        {
            this.enrollmentService = enrollmentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEnrollments(
            [FromQuery] EnrollmentStatus? status,
            [FromQuery] Guid? trackId,
            [FromQuery] Guid? studentId,
            [FromQuery] PaymentStatus? paymentStatus)
        {
            var response = await enrollmentService.GetAllEnrollmentsAsync(status, trackId, studentId, paymentStatus);

            return Ok(response.Data);
        }


        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetEnrollmentById([FromRoute] Guid id)
        {
            var response = await enrollmentService.GetByIdAsync(id);

            if (response.Status == Status.NotFound)
                return NotFound(response.Message);

            return Ok(response.Data);
        }
        
        
        [HttpPost]
        public async Task<IActionResult> EnrollInTrackAsync([FromBody] CreateEnrollmentRequest request)
        {
            var response = await enrollmentService.CreateEnrollmentAsync(request);

            if (response.Status == Status.NotFound)
                return NotFound(response.Message);

            if (response.Status == Status.Error)
                return BadRequest(response.Message);

            return CreatedAtAction(nameof(GetEnrollmentById), new { id = response.Data.EnrollmentId }, response.Data);
        }


        [HttpPut("{id:guid}/status")]
        public async Task<IActionResult> ChangeEnrollmentStatusAsync([FromRoute] Guid id, [FromBody] UpdateEnrollmentStatusRequest request)
        {
            var response = await enrollmentService.UpdateStatusAsync(id, request);

            if (response.Status == Status.NotFound)
                return NotFound(response.Message);

            if (response.Status == Status.Error)
                return BadRequest(response.Message);

            return Ok(response.Data);
        }



        [HttpGet("{id:guid}/payments")]
        public async Task<IActionResult> GetEnrollmentPaymentsAsync([FromRoute] Guid id)
        {
            var response = await enrollmentService.GetPaymentHistoryAsync(id);

            if (response.Status == Status.NotFound)
                return NotFound(response.Message);

            return Ok(response.Data);
        }
    }
}
