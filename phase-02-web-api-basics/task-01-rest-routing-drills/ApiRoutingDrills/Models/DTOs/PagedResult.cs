namespace ApiRoutingDrills.Models.DTOs
{
    public class PagedResult
    {
        public IEnumerable<NoteDto> Notes { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
    }
}
