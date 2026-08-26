using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiRoutingDrills.Controllers
{
    [Route("api/request-info")]
    [ApiController]
    public class HeadersController : ControllerBase
    {
        [HttpGet]
        public IActionResult ReadHeader()
        {
            var header = Request.Headers["X-Student-Name"].FirstOrDefault();

            if (header == null)
                return BadRequest();

            return Ok(new { header, path = Request.Path.Value });
        }
    }
}
