using TrainingCenter.Api.Entities;

namespace TrainingCenter.Api.DTOs.Payments
{
    public class UpdatePaymentStatusRequest
    {
        public PaymentStatus PaymentStatus { get; set; }
    }
}
