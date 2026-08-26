using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiRoutingDrills.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        [HttpGet("add")]
        public IActionResult Add([FromQuery] decimal a, [FromQuery] decimal b)
        {
            return Ok(new { result = a + b });
        }
    }
}
