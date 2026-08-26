using Microsoft.AspNetCore.Mvc;

namespace ApiRoutingDrills.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusCodeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Status200()
        {
            return Ok();
        }
        [HttpPost]
        public IActionResult Status201()
        {
            return Created("", new object());
        }
        [HttpDelete]
        public IActionResult Status204()
        {
            return NoContent();
        }
        [HttpPut]
        public IActionResult Status400()
        {
            return BadRequest();
        }
        [HttpPatch]
        public IActionResult Status404()
        {
            return NotFound();
        }
    }
}
