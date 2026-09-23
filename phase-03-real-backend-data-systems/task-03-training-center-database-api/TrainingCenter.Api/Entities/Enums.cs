namespace TrainingCenter.Api.Entities
{
    public enum TrackStatus
    {
        Upcoming,
        Active,
        Completed,
        Cancelled
    }

    public enum EnrollmentStatus
    {
        Pending,
        Active,
        Completed,
        Cancelled
    }

    public enum PaymentStatus
    {
        Pending,
        Paid,
        Failed,
        Refunded
    }
}
