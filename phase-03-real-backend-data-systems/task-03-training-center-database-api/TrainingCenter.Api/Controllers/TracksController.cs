using Microsoft.AspNetCore.Mvc;
using TrainingCenter.Api.DTOs.Tracks;
using TrainingCenter.Api.Entities;
using TrainingCenter.Api.Services;

namespace TrainingCenter.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TracksController : ControllerBase
    {
        private readonly TrackService trackService;

        public TracksController(TrackService trackService)
        {
            this.trackService = trackService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTracks(
            [FromQuery] string? keyword,
            [FromQuery] int? level,
            [FromQuery] TrackStatus? status,
            [FromQuery] Guid? instructorId)
        {
            var response = await trackService.GetAllTracksAsync(keyword, level, status, instructorId);
            return Ok(response.Data);
        }


        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetTrackById([FromRoute] Guid id)
        {
            var response = await trackService.GetTrackByIdAsync(id);

            if (response.Status == Status.NotFound)
                return NotFound(response.Message);

            return Ok(response.Data);
        }


        [HttpPost]
        public async Task<IActionResult> CreateTrack([FromBody] CreateTrackRequest createTrackRequest)
        {
            var response = await trackService.CreateTrackAsync(createTrackRequest);
            if (response.Status == Status.Error)
                return BadRequest(response.Message);

            return CreatedAtAction(nameof(GetTrackById), new { id = response.Data }, response.Data);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateTrack([FromRoute] Guid id, [FromBody] UpdateTrackRequest updateTrackRequest)
        {
            var response = await trackService.UpdateTrackAsync(id, updateTrackRequest);
            if(response.Status == Status.NotFound)
                return NotFound(response.Message);
            if(response.Status == Status.Error)
                return BadRequest(response.Message);

            return Ok(response.Data);
        }
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteTrack([FromRoute] Guid id)
        {
            var response = await trackService.DeleteTrackAsync(id);
            if (response.Status == Status.NotFound)
                return NotFound(response.Message);
            return Ok(response.Data);
        }

        [HttpGet("{id:guid}/students")]
        public async Task<IActionResult> GetStudentsInTrack([FromRoute] Guid id)
        {
            var response = await trackService.GetStudentsInTrackAsync(id);
            if (response.Status == Status.NotFound)
                return NotFound(response.Message);
            return Ok(response.Data);
        }
    }
}
