using TrainingCenter.Api.Entities;

namespace TrainingCenter.Api.DTOs.Tracks
{
    public class UpdateTrackRequest
    {
        public string Title { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int Level { get; set; }
        public int Capacity { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public TrackStatus Status { get; set; }

    }
}
