namespace TrainingCenter.Api.DTOs.Reports
{
    public class TrackCapacityListItem
    {
        public Guid TrackId { get; set; }
        public string TrackName { get; set; }
        public int Capacity { get; set; }
        public int EnrollmentCount { get; set; }

    }
}
