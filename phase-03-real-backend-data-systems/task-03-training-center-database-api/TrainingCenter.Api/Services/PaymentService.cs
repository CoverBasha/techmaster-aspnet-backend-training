using Microsoft.EntityFrameworkCore;
using TrainingCenter.Api.Data;
using TrainingCenter.Api.DTOs.Payments;
using TrainingCenter.Api.DTOs.Shared;
using TrainingCenter.Api.Entities;

namespace TrainingCenter.Api.Services
{
    public class PaymentService
    {
        private readonly ApplicationDbContext context;

        public PaymentService(ApplicationDbContext context)
        {
            this.context = context;
        }


        public async Task<ServiceResponse<List<PaymentResponse>>> GetAllPaymentsAsync(
            DateTime? StartDate,
            DateTime? EndDate,
            PaymentStatus? paymentStatus)
        {
            var payments = context.Payments.AsQueryable();
            
            if(StartDate.HasValue)
            {
                payments = payments.Where(p => p.PaymentDate >= StartDate.Value);
            }

            if(EndDate.HasValue)
            {
                payments = payments.Where(p => p.PaymentDate <= EndDate.Value);
            }

            if(paymentStatus.HasValue)
            {
                payments = payments.Where(p => p.PaymentStatus == paymentStatus.Value);
            }

            var paymentList = await payments.Select(p => new PaymentResponse
            {
                PaymentId = p.PaymentId,
                Amount = p.Amount,
                PaymentMethod = p.PaymentMethod,
                PaymentDate = p.PaymentDate,
                PaymentStatus = p.PaymentStatus,
                ReferenceNumber = p.ReferenceNumber,
                Notes = p.Notes
            }).ToListAsync();

            return new ServiceResponse<List<PaymentResponse>>
            {
                Status = Status.Success,
                Data = paymentList
            };
        }


        public async Task<ServiceResponse<PaymentResponse>> MakePaymentAsync(Guid enrollmentId, MakePaymentRequest paymentRequest)
        {
            var enrollment = await context.Enrollments.FindAsync(enrollmentId);

            if(enrollment == null)
            {
                return new ServiceResponse<PaymentResponse>
                {
                    Status = Status.NotFound,
                    Message = "Enrollment not found."
                };
            }

            var payment = new Payment
            {
                PaymentId = Guid.NewGuid(),
                EnrollmentId = enrollmentId,
                Amount = paymentRequest.Amount,
                PaymentMethod = paymentRequest.PaymentMethod,
                PaymentDate = paymentRequest.PaymentDate,
                PaymentStatus = paymentRequest.PaymentStatus,
                ReferenceNumber = paymentRequest.ReferenceNumber,
                Notes = paymentRequest.Notes
            };

            await context.Payments.AddAsync(payment);
            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return new ServiceResponse<PaymentResponse>
                {
                    Status = Status.Error,
                    Message = "An error occurred while saving the payment"
                };
            }

            var paymentResponse = new PaymentResponse
            {
                PaymentId = payment.PaymentId,
                Amount = payment.Amount,
                PaymentMethod = payment.PaymentMethod,
                PaymentDate = payment.PaymentDate,
                PaymentStatus = payment.PaymentStatus,
                ReferenceNumber = payment.ReferenceNumber,
                Notes = payment.Notes
            };

            return new ServiceResponse<PaymentResponse>
            {
                Status = Status.Success,
                Data = paymentResponse
            };
        }


        public async Task<ServiceResponse<PaymentResponse>> UpdatePaymentStatusAsync(Guid id, UpdatePaymentStatusRequest request)
        {
            var payment = await context.Payments.FindAsync(id);

            if (payment == null)
            {
                return new ServiceResponse<PaymentResponse>
                {
                    Status = Status.NotFound,
                    Message = "Payment not found."
                };
            }

            payment.PaymentStatus = request.PaymentStatus;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return new ServiceResponse<PaymentResponse>
                {
                    Status = Status.Error,
                    Message = "An error occurred while updating the payment status."
                };
            }

            var paymentResponse = new PaymentResponse
            {
                PaymentId = payment.PaymentId,
                Amount = payment.Amount,
                PaymentMethod = payment.PaymentMethod,
                PaymentDate = payment.PaymentDate,
                PaymentStatus = payment.PaymentStatus,
                ReferenceNumber = payment.ReferenceNumber,
                Notes = payment.Notes
            };

            return new ServiceResponse<PaymentResponse>
            {
                Status = Status.Success,
                Data = paymentResponse
            };

        }
    }
}
