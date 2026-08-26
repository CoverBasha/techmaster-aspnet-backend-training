using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiRoutingDrills.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EchoController : ControllerBase
    {
        [HttpGet("{name}")]
        public IActionResult Echo(string name)
        {
            return Ok(new { name });
        }
    }
}
