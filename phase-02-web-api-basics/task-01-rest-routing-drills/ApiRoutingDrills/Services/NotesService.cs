using ApiRoutingDrills.Models;
using ApiRoutingDrills.Models.DTOs;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace ApiRoutingDrills.Services
{
    public class NotesService
    {
        public Dictionary<Guid, Note> Notes { get; set; }
        public NotesService()
        {
            Notes = [];
        }

        public ServiceResponse<NoteDto> CreateNote(CreateNoteDto dto)
        {
            if (dto == null || string.IsNullOrEmpty(dto.Title))
                return new () { Status = Status.Error, Message = "Title cannot be empty" };

            var note = new Note { Id = Guid.NewGuid(), Title = dto.Title, Description = dto.Description };
            Notes.Add(note.Id, note);

            return new ()
            {
                Status = Status.Success,
                Result = new NoteDto { Id = note.Id, Title = note.Title, Description = note.Description }
            };
        }

        public ServiceResponse<NoteDto> GetNote(Guid id)
        {
            if (!Notes.TryGetValue(id, out Note? note))
                return new () { Status = Status.NotFound, Message = $"Note with Id: {id} not found" };

            return new ()
            {
                Status = Status.Success,
                Result = new NoteDto
                {
                    Id = note.Id,
                    Title = note.Title,
                    Description = note.Description,
                }
            };
        }

        public ServiceResponse<IEnumerable<NoteDto>> GetNotes()
        {
            return new ()
            {
                Status = Status.Success,
                Result = Notes.Values.Select(x => new NoteDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                }).AsEnumerable()
            };
        }

        public ServiceResponse<NoteDto> UpdateNote(Guid id, CreateNoteDto dto)
        {
            if (!Notes.ContainsKey(id))
                return new () { Status = Status.NotFound, Message = $"Note with Id: {id} not found" };

            if (string.IsNullOrWhiteSpace(dto.Title))
                return new () { Status = Status.Error, Message = "Title cannot be empty" };

            Notes[id] = new Note
            {
                Id = id,
                Title = dto.Title,
                Description = dto.Description,
            };

            return new ()
            {
                Status = Status.Success,
                Result = new NoteDto { Id = Notes[id].Id, Title = Notes[id].Title, Description = Notes[id].Description }
            };

        }

        public ServiceResponse<NoteDto> DeleteNote(Guid id)
        {
            if (!Notes.ContainsKey(id))
                return new () { Status = Status.NotFound, Message = $"Note with Id: {id} not found" };

            Notes.Remove(id);

            return new ()
            {
                Status = Status.Success,
                Message = $"Note with Id: {id} deleted successfully"
            };
        }

        public ServiceResponse<IEnumerable<NoteDto>> Search(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return new() { Status = Status.Error, Message = "Search word cannot be emtpy" };

            var result = Notes.Values
                .Where(n => n.Title.Contains(keyword, StringComparison.OrdinalIgnoreCase)
                || n.Description.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                .Select(x => new NoteDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                }).AsEnumerable();



            return new()
            {
                Status = Status.Success,
                Result = result,
                Message = !result.Any() ? "No matching notes" : $"{result.Count()} notes found"
            };
        }

        public ServiceResponse<PagedResult> Paginate(int pageNumber, int pageSize)
        {
            pageNumber = pageNumber < 1 ? 1 : pageNumber;

            var result = Notes.Values.Skip((pageNumber - 1) * pageSize).Take(pageSize)
                .Select(x => new NoteDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                }).AsEnumerable();

            return new()
            {
                Status = Status.Success,
                Result = new()
                {
                    Notes = result,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    TotalCount = (int)Math.Ceiling((double)Notes.Count / (double)pageSize)
                }
            };
        }
    }
}
