using TrainingCenter.Api.Entities;

namespace TrainingCenter.Api.DTOs.Shared
{
    public class PaymentResponse
    {
        public Guid PaymentId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; } = null!;
        public DateTime PaymentDate { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public string ReferenceNumber { get; set; } = null!;
        public string? Notes { get; set; }
    }
}
