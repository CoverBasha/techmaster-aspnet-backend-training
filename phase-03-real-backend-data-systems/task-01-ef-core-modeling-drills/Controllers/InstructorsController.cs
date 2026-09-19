using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using task_01_ef_core_modeling_drills.Data;

namespace task_01_ef_core_modeling_drills.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InstructorsController : ControllerBase
    {
        private readonly AppDbContext context;

        public InstructorsController(AppDbContext context)
        {
            this.context = context;
        }


        [HttpGet("{id:guid}/tracks")]
        public async Task<IActionResult> GetInstructorTracksAsync(Guid id)
        {

            var tracks = await context.TrainingTracks.Where(t => t.InstructorId == id).ToListAsync();
            return Ok(tracks);
        }
    }
}
