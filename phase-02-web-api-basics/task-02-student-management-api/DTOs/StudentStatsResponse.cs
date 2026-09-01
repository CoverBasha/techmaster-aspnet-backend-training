namespace task_02_student_management_api.DTOs
{
    public class StudentStatsResponse
    {
        public int TotalCount { get; set; }
        public int TotalActive { get; set; }
        public int TotalInactive { get; set; }
        public IEnumerable<TrackCount> TrackCounts { get; set; }
    }

    public class TrackCount
    {
        public string TrackName { get; set; }
        public int Count { get; set; }
    }
}
