
using Microsoft.EntityFrameworkCore;
using TrainingCenter.Api.Data;
using TrainingCenter.Api.DTOs.Enrollments;
using TrainingCenter.Api.DTOs.Reports;
using TrainingCenter.Api.Entities;

namespace TrainingCenter.Api.Services
{
    public class ReportService
    {
        private readonly ApplicationDbContext context;

        public ReportService(ApplicationDbContext context)
        {
            this.context = context;
        }


        public async Task<ServiceResponse<List<EnrollmentListItemResponse>>> GetUnpaidOrPartiallyPaidEnrollmentsAsync()
        {
            var enrollments = await context.Enrollments
                .Where(e => e.Payments.Any(p =>
                p.PaymentStatus == PaymentStatus.Paid ||
                p.PaymentStatus == PaymentStatus.PartiallyPaid)).Select(e => new EnrollmentListItemResponse
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
                }).ToListAsync();

            return new()
            {
                Data = enrollments,
                Status = Status.Success,
            };
            
        }

        public async Task<ServiceResponse<List<TrackCapacityListItem>>> GetCapacityPerTrack()
        {
            var tracks = await context.TrainingTracks
                .Select(tt => new TrackCapacityListItem
                {
                    TrackId = tt.TrainingTrackId,
                    TrackName = tt.Title,
                    Capacity = tt.Capacity,
                    EnrollmentCount = tt.Enrollments.Count()
                }).ToListAsync();

            return new()
            {
                Data = tracks,
                Status = Status.Success,
            };
        }

    }
}
