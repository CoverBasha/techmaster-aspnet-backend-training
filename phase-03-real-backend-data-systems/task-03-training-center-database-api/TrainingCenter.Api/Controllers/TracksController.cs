using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TrainingCenter.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TracksController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllTracks()
        {
            return Ok();
        }
        [HttpGet("{id:guid}")]
        public IActionResult GetTrackById(Guid id)
        {
            return Ok();
        }
        [HttpPost]
        public IActionResult CreateTrack()
        {
            return Ok();
        }
        [HttpPut("{id:guid}")]
        public IActionResult UpdateTrack(Guid id)
        {
            return Ok();
        }
        [HttpDelete("{id:guid}")]
        public IActionResult DeleteTrack(Guid id)
        {
            return Ok();
        }

        [HttpGet("{id:guid}/students")]
        public IActionResult GetStudentsInTrack(Guid id)
        {
            return Ok();
        }
    }
}
