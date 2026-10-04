using Microsoft.AspNetCore.Mvc;
using TrainingCenter.Api.DTOs.Payments;
using TrainingCenter.Api.Entities;
using TrainingCenter.Api.Services;

namespace TrainingCenter.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly PaymentService paymentService;

        public PaymentsController(PaymentService paymentService)
        {
            this.paymentService = paymentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPayments(
            [FromQuery] DateTime? StartDate,
            [FromQuery] DateTime? EndDate,
            [FromQuery] PaymentStatus? paymentStatus)
        {
            var response = await paymentService.GetAllPaymentsAsync(StartDate, EndDate, paymentStatus);

            return Ok(response.Data);
        }

        [HttpPost("{enrollmentId:guid}")]
        public async Task<IActionResult> MakePayment([FromRoute] Guid enrollmentId, [FromBody] MakePaymentRequest paymentRequest)
        {
            var response = await paymentService.MakePaymentAsync(enrollmentId, paymentRequest);

            if(response.Status == Status.NotFound)
                return NotFound(response.Message);
            if (response.Status == Status.Error)
                return BadRequest(response.Message);

            return Ok(response.Data);
        }

        [HttpPut("{id:guid}/status")]
        public async Task<IActionResult> UpdatePaymentStatus(Guid id, UpdatePaymentStatusRequest updatePaymentStatusRequest)
        {
            var response = await paymentService.UpdatePaymentStatusAsync(id, updatePaymentStatusRequest);

            if (response.Status == Status.NotFound)
                return NotFound(response.Message);
            if (response.Status == Status.Error)
                return BadRequest(response.Message);

            return Ok(response.Data);
        }
    }
}
