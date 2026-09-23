namespace TrainingCenter.Api.Entities
{
    public class Payment
    {
        public Guid PaymentId { get; set; }

        public Guid EnrollmentId { get; set; }

        public decimal Amount { get; set; }

        public string PaymentMethod { get; set; } = null!;

        public DateTime PaymentDate { get; set; }

        public PaymentStatus PaymentStatus { get; set; }

        public string ReferenceNumber { get; set; } = null!;
        public string? Notes { get; set; }

        // Navigation property
        public Enrollment Enrollment { get; set; } = null!;
    }
}