using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TrainingCenter.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllPayments()
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult CreatePayment()
        {
            return Ok();
        }

        [HttpPut("{id:guid}/status")]
        public IActionResult UpdatePaymentStatus(Guid id)
        {
            return Ok();
        }
    }
}
