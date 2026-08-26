using ApiRoutingDrills.Models.DTOs;
using ApiRoutingDrills.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiRoutingDrills.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly NotesService notesService;

        public NotesController(NotesService notesService)
        {
            this.notesService = notesService;
        }


        [HttpPost]
        public IActionResult CreateNote([FromBody] CreateNoteDto dto)
        {
            var response = notesService.CreateNote(dto);

            if (response.Status == Status.Error)
                return BadRequest(response.Message);

            return Ok(response.Result);
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetNote(Guid id)
        {
            var response = notesService.GetNote(id);

            if (response.Status == Status.NotFound)
                return NotFound(response.Message);

            return Ok(response.Result);
        }

        [HttpGet]
        public IActionResult GetAll([FromQuery] int? pageNumber, [FromQuery] int? pageSize)
        {
            if (pageNumber.HasValue && pageSize.HasValue)
            {
                var response = notesService.Paginate(pageNumber.Value, pageSize.Value);
                return Ok(response.Result);
            }

            var notes = notesService.GetNotes();
            return Ok(notes.Result);
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdateNote([FromRoute]Guid id, [FromBody] CreateNoteDto dto)
        {
            var response = notesService.UpdateNote(id, dto);

            if (response.Status == Status.NotFound)
                return NotFound(response.Message);

            if (response.Status == Status.Error)
                return BadRequest(response.Message);

            return Ok(response.Result);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteNote([FromRoute] Guid id)
        {
            var response = notesService.DeleteNote(id);

            if (response.Status == Status.NotFound)
                return NotFound(response.Message);

            return NoContent();
        }

        [HttpGet("search")]
        public IActionResult Search([FromQuery] string keyword)
        {
            var response = notesService.Search(keyword);

            return Ok(new { response.Result, response.Message });
        }
    }
}
