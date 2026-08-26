namespace ApiRoutingDrills.Models.DTOs
{
    public class CreateNoteDto
    {
        public string Title { get; set; }
        public string Description { get; set; }

    }

    public class NoteDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
