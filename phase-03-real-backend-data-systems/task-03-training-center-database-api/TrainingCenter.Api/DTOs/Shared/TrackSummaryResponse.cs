using TrainingCenter.Api.Entities;

namespace TrainingCenter.Api.DTOs.Shared
{
    public class TrackSummaryResponse
    {
        public Guid TrainingTrackId { get; set; }
        public string Title { get; set; } = null!;
        public string Code { get; set; } = null!;
        public TrackStatus Status { get; set; }
    }
}
