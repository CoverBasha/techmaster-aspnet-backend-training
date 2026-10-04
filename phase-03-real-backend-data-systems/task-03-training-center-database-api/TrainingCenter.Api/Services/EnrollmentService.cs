using Microsoft.EntityFrameworkCore;
using TrainingCenter.Api.Data;
using TrainingCenter.Api.DTOs.Enrollments;
using TrainingCenter.Api.DTOs.Shared;
using TrainingCenter.Api.Entities;

namespace TrainingCenter.Api.Services
{
    public class EnrollmentService
    {
        private readonly ApplicationDbContext context;

        public EnrollmentService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<ServiceResponse<List<EnrollmentListItemResponse>>> GetAllEnrollmentsAsync(
            EnrollmentStatus? status,
            Guid? trackId,
            Guid? studentId,
            PaymentStatus? paymentStatus)
        {
            var query = context.Enrollments.AsQueryable();
            if (status.HasValue)
            {
                query = query.Where(e => e.EnrollmentStatus == status.Value);
            }
            if (trackId.HasValue)
            {
                query = query.Where(e => e.TrainingTrackId == trackId.Value);
            }
            if (studentId.HasValue)
            {
                query = query.Where(e => e.StudentId == studentId.Value);
            }
            if (paymentStatus.HasValue)
            {
                query = query.Where(e => e.Payments.Any(p => p.PaymentStatus == paymentStatus.Value));
            }

            var enrollments = await query
                .Select(e => new EnrollmentListItemResponse
                {
                    EnrollmentId = e.EnrollmentId,
                    StudentId = e.StudentId,
                    StudentName = e.Student.FullName,
                    TrainingTrackId = e.TrainingTrackId,
                    TrackTitle = e.TrainingTrack.Title,
                    EnrollmentDate = e.EnrollmentDate,
                    EnrollmentStatus = e.EnrollmentStatus,
                    ProgressPercentage = e.ProgressPercentage,
                    FinalResult = e.FinalResult
                })
                .ToListAsync();

            return new()
            {
                Data = enrollments,
                Status = Status.Success
            };

        }

        public async Task<ServiceResponse<EnrollmentDetailsResponse>> GetByIdAsync(Guid id)
        {
            var enrollment = await context.Enrollments.Where(e => e.EnrollmentId == id)
                .Select(e => new EnrollmentDetailsResponse
                {
                    EnrollmentId = e.EnrollmentId,
                    EnrollmentDate = e.EnrollmentDate,
                    Status = e.EnrollmentStatus,
                    ProgressPercentage = e.ProgressPercentage,
                    FinalResult = e.FinalResult,
                    Student = new StudentSummaryResponse
                    {
                        StudentId = e.Student.StudentId,
                        FullName = e.Student.FullName,
                        Email = e.Student.Email
                    },
                    Track = new TrackSummaryResponse
                    {
                        TrainingTrackId = e.TrainingTrack.TrainingTrackId,
                        Title = e.TrainingTrack.Title,
                        Code = e.TrainingTrack.Code
                    },
                    Payments = e.Payments.Select(p => new PaymentResponse
                    {
                        PaymentId = p.PaymentId,
                        Amount = p.Amount,
                        PaymentMethod = p.PaymentMethod,
                        PaymentDate = p.PaymentDate,
                        PaymentStatus = p.PaymentStatus,
                        ReferenceNumber = p.ReferenceNumber,
                        Notes = p.Notes
                    }).ToList()
                }).FirstOrDefaultAsync();


            if (enrollment == null)
                return new() { Status = Status.NotFound, Message = "Enrollment not found" };

            return new()
            {
                Data = enrollment,
                Status = Status.Success
            };
        }

        public async Task<ServiceResponse<EnrollmentDetailsResponse>> CreateEnrollmentAsync(CreateEnrollmentRequest request)
        {
            var studentExists = await context.Students.AnyAsync(s => s.StudentId == request.StudentId && !s.IsDeleted);

            if (!studentExists) throw new KeyNotFoundException("Student not found.");
            var track = await context.TrainingTracks
                .FirstOrDefaultAsync(t => t.TrainingTrackId == request.TrainingTrackId && !t.IsDeleted);

            if (track == null)
                return new() { Status = Status.NotFound, Message = "Training track not found." };

            if (track.Status == TrackStatus.Cancelled || track.Status == TrackStatus.Completed)
                return new() { Status = Status.Error, Message = "This track is not accepting enrollments." };


            var duplicateEnrollment = await context.Enrollments
                .AnyAsync(e => e.StudentId == request.StudentId
                && e.TrainingTrackId == request.TrainingTrackId
                && (e.EnrollmentStatus == EnrollmentStatus.Pending || e.EnrollmentStatus == EnrollmentStatus.Active));

            if (duplicateEnrollment)
                return new() { Status = Status.Error, Message = "Student already has an active enrollment in this track." };

            var activeEnrollmentCount = await context.Enrollments
                .CountAsync(e => e.TrainingTrackId == request.TrainingTrackId
                && (e.EnrollmentStatus == EnrollmentStatus.Pending || e.EnrollmentStatus == EnrollmentStatus.Active));

            if (activeEnrollmentCount >= track.Capacity)
                return new() { Status = Status.Error, Message = "This track has reached its capacity." };

            var enrollment = new Enrollment
            {
                EnrollmentId = Guid.NewGuid(),
                StudentId = request.StudentId,
                TrainingTrackId = request.TrainingTrackId,
                EnrollmentDate = DateTime.UtcNow,
                EnrollmentStatus = EnrollmentStatus.Pending,
                ProgressPercentage = 0,
            };

            await context.Enrollments.AddAsync(enrollment);
            await context.SaveChangesAsync();

            return await GetByIdAsync(enrollment.EnrollmentId);
        }

        public async Task<ServiceResponse<EnrollmentDetailsResponse>> UpdateStatusAsync(Guid id, UpdateEnrollmentStatusRequest request)
        {
            var enrollment = await context.Enrollments.FirstOrDefaultAsync(e => e.EnrollmentId == id);
            if (enrollment == null)
                return new() { Status = Status.NotFound, Message = "Enrollment not found" };

            enrollment.EnrollmentStatus = request.Status;
            try
            {
                await context.SaveChangesAsync();
            }
            catch(DbUpdateException ex)
            {
                return new() { Status = Status.Error, Message = $"Error updating enrollment status" };
            }

            return await GetByIdAsync(id);
        }

        public async Task<ServiceResponse<List<PaymentResponse>>> GetPaymentHistoryAsync(Guid id)
        {
            if (!await context.Enrollments.AnyAsync(e => e.EnrollmentId == id))
                return new() { Status = Status.NotFound, Message = $"Enrollment with id: {id} not found" };

            var payments = context.Payments.Where(p => p.EnrollmentId == id).Select(p => new PaymentResponse
            {
                PaymentId = p.PaymentId,
                Amount = p.Amount,
                PaymentMethod = p.PaymentMethod,
                PaymentDate = p.PaymentDate,
                PaymentStatus = p.PaymentStatus,
                ReferenceNumber = p.ReferenceNumber,
                Notes = p.Notes
            }).ToList();

            return new()
            {
                Data = payments,
                Status = Status.Success
            };
        }
    }
}
