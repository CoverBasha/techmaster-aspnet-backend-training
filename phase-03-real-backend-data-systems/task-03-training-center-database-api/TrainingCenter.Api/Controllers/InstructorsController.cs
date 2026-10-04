using Microsoft.AspNetCore.Mvc;
using TrainingCenter.Api.DTOs.Instructors;
using TrainingCenter.Api.Services;

namespace TrainingCenter.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorsController : ControllerBase
    {
        private readonly InstructorService instructorService;

        public InstructorsController(InstructorService instructorService)
        {
            this.instructorService = instructorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllInstructors(
            [FromQuery] string? keyword,
            [FromQuery] bool? isActive,
            [FromQuery] int? pageNumber,
            [FromQuery] int? pageSize)

        {
            var response = await instructorService.GetAllInstructorsAsync(keyword, isActive, pageNumber, pageSize);

            return Ok(response.Data);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetInstructorByIdAsync([FromRoute] Guid id)
        {
            var response = await instructorService.GetInstructorByIdAsync(id);

            if (response.Status == Status.NotFound)
                return NotFound(response.Message);

            return Ok(response.Data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateInstructorAsync(CreateInstructorRequest createInstructorRequest)
        {
            var response = await instructorService.CreateInstructorAsync(createInstructorRequest);

            if (response.Status == Status.Error)
                return BadRequest(response.Message);

            return Ok(response.Data);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateInstructorAsync([FromRoute] Guid id, 
            [FromBody] UpdateInstructorRequest updateInstructorRequest)
        {
            var response = await instructorService.UpdateInstructorAsync(id, updateInstructorRequest);

            if (response.Status == Status.NotFound)
                return NotFound(response.Message);
            if (response.Status == Status.Error)
                return BadRequest(response.Message);

            return Ok(response.Data);
        }

        [HttpGet("{id:guid}/tracks")]
        public async Task<IActionResult> GetInstructorTracks([FromRoute] Guid id)
        {
            var response = await instructorService.GetInstructorTracks(id);

            if (response.Status == Status.NotFound)
                return NotFound(response.Message);

            return Ok(response.Data);
        }
    }
}
