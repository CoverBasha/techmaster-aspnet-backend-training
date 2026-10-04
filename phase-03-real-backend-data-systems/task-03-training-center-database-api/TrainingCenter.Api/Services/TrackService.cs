using Microsoft.EntityFrameworkCore;
using TrainingCenter.Api.Data;
using TrainingCenter.Api.DTOs.Shared;
using TrainingCenter.Api.DTOs.Tracks;
using TrainingCenter.Api.Entities;

namespace TrainingCenter.Api.Services
{
    public class TrackService
    {
        private readonly ApplicationDbContext context;

        public TrackService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<ServiceResponse<List<TrackSummaryResponse>>> GetAllTracksAsync(
            string? keyword, int? level, TrackStatus? status, Guid? instructorId)
        {

            var tracksQuery = context.TrainingTracks.AsQueryable();

            if (!string.IsNullOrEmpty(keyword))
                tracksQuery = tracksQuery.Where(t =>
                    t.Title.Contains(keyword, StringComparison.OrdinalIgnoreCase)
                    || t.Code.Contains(keyword, StringComparison.OrdinalIgnoreCase));

            if (level.HasValue)
                tracksQuery = tracksQuery.Where(t => t.Level == level.Value);
            if (status.HasValue)
                tracksQuery = tracksQuery.Where(t => t.Status == status.Value);
            if (instructorId.HasValue)
                tracksQuery = tracksQuery.Where(t => t.InstructorId == instructorId.Value);

            var result = await tracksQuery.Select(t => new TrackSummaryResponse
            {
                TrainingTrackId = t.TrainingTrackId,
                Title = t.Title,
                Code = t.Code,
                Status = t.Status,
            }).ToListAsync();

            return new()
            {
                Data = result,
                Status = Status.Success
            };
        }

        public async Task<ServiceResponse<TrackDetailsResponse>> GetTrackByIdAsync(Guid id)
        {
            var track = await context.TrainingTracks.FindAsync(id);
            if (track == null)
                return new() { Status = Status.NotFound, Message = "Track not found." };

            return new()
            {
                Data = new TrackDetailsResponse
                {
                    TrainingTrackId = track.TrainingTrackId,
                    Title = track.Title,
                    Description = track.Description,
                    Code = track.Code,
                    Level = track.Level,
                    Capacity = track.Capacity,
                    StartDate = track.StartDate,
                    EndDate = track.EndDate,
                    Status = track.Status,
                    InstructorId = track.InstructorId,
                },
                Status = Status.Success
            };
        }

        public async Task<ServiceResponse<Guid>> CreateTrackAsync(CreateTrackRequest request)
        {
            var newTrack = new TrainingTrack
            {
                TrainingTrackId = Guid.NewGuid(),
                Title = request.Title,
                Code = request.Code,
                Description = request.Description,
                Level = request.Level,
                Capacity = request.Capacity,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                Status = TrackStatus.Active,
                InstructorId = request.InstructorId,
                CreatedAt = DateTime.UtcNow
            };
            await context.TrainingTracks.AddAsync(newTrack);
            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                return new()
                {
                    Status = Status.Error,
                    Message = "An error occurred while adding the track.",
                };
            }
            
            return new ServiceResponse<Guid>
            {
                Data = newTrack.TrainingTrackId,
                Status = Status.Success
            };
        }

        public async Task<ServiceResponse<TrackDetailsResponse>> UpdateTrackAsync(Guid id, UpdateTrackRequest request)
        {
            var track = await context.TrainingTracks.FindAsync(id);
            if (track == null)
            {
                return new ServiceResponse<TrackDetailsResponse>
                {
                    Status = Status.NotFound,
                    Message = "Track not found."
                };
            }

            track.Title = request.Title;
            track.Code = request.Code;
            track.Description = request.Description;
            track.Level = request.Level;
            track.Capacity = request.Capacity;
            track.StartDate = request.StartDate;
            track.EndDate = request.EndDate;
            track.Status = request.Status;
            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                return new ServiceResponse<TrackDetailsResponse>
                {
                    Status = Status.Error,
                    Message = "An error occurred while updating the track.",
                };
            }
            var response = new TrackDetailsResponse
            {
                TrainingTrackId = track.TrainingTrackId,
                Title = track.Title,
                Code = track.Code,
                Description = track.Description,
                Level = track.Level,
                Capacity = track.Capacity,
                StartDate = track.StartDate,
                EndDate = track.EndDate,
                Status = track.Status,
                InstructorId = track.InstructorId
            };
            return new ServiceResponse<TrackDetailsResponse>
            {
                Data = response,
                Status = Status.Success
            };
        }

        public async Task<ServiceResponse<bool>> DeleteTrackAsync(Guid id)
        {
            var track = await context.TrainingTracks.FindAsync(id);
            if (track == null)
            {
                return new ServiceResponse<bool>
                {
                    Status = Status.NotFound,
                    Message = "Track not found."
                };
            }
            track.IsDeleted = true;
            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                return new ServiceResponse<bool>
                {
                    Status = Status.Error,
                    Message = "An error occurred while deleting the track.",
                };
            }
            return new ServiceResponse<bool>
            {
                Data = true,
                Status = Status.Success
            };
        }

        public async Task<ServiceResponse<List<StudentSummaryResponse>>> GetStudentsInTrackAsync(Guid id)
        {
            var track = await context.TrainingTracks.FindAsync(id);

            if(track == null)
            {
                return new ServiceResponse<List<StudentSummaryResponse>>
                {
                    Status = Status.NotFound,
                    Message = "Track not found."
                };
            }

            var students = await context.Enrollments
                .Where(e => e.TrainingTrackId == id)
                .Select(e => new StudentSummaryResponse
                {
                    StudentId = e.Student.StudentId,
                    FullName = e.Student.FullName,
                    Email = e.Student.Email
                })
                .ToListAsync();

            return new ServiceResponse<List<StudentSummaryResponse>>
            {
                Data = students,
                Status = Status.Success
            };
        }
    }
}
