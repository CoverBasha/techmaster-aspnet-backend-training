using Microsoft.EntityFrameworkCore;
using TrainingCenter.Api.Data;
using TrainingCenter.Api.DTOs.Instructors;
using TrainingCenter.Api.DTOs.Shared;
using TrainingCenter.Api.Entities;

namespace TrainingCenter.Api.Services
{
    public class InstructorService
    {
        private readonly ApplicationDbContext context;
        public InstructorService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<ServiceResponse<List<InstructorListItemResponse>>> GetAllInstructorsAsync(
            string? keyword, bool? isActive, int? pageNumber, int? pageSize)
        {
            pageNumber = pageNumber == null || pageNumber < 1 ? 1 : pageNumber;
            pageSize = pageSize == null || pageSize < 1 ? 10 : pageSize;
            var instructorsQuery = context.Instructors.AsQueryable();
            if (isActive.HasValue)
                instructorsQuery = instructorsQuery.Where(i => i.IsActive == isActive.Value);
            if (!string.IsNullOrEmpty(keyword))
                instructorsQuery = instructorsQuery.Where(i =>
                i.FullName.Contains(keyword, StringComparison.OrdinalIgnoreCase)
                || i.Email.Contains(keyword, StringComparison.OrdinalIgnoreCase));
            instructorsQuery = instructorsQuery
                    .Skip((pageNumber.Value - 1) * pageSize.Value)
                    .Take(pageSize.Value);
            var instructors = await instructorsQuery.Select(i => new InstructorListItemResponse
            {
                InstructorId = i.InstructorId,
                FullName = i.FullName,
                Email = i.Email,
                IsActive = i.IsActive
            }).ToListAsync();
            return new() { Data = instructors, Status = Status.Success };
        }

        public async Task<ServiceResponse<InstructorDetailsResponse>> GetInstructorByIdAsync(Guid id)
        {
            var instructor = await context.Instructors.Select(i => new InstructorDetailsResponse
            {
                InstructorId = i.InstructorId,
                FullName = i.FullName,
                Email = i.Email,
                IsActive = i.IsActive,
                Specialization = i.Specialization,
                CreatedAt = i.CreatedAt,
                Bio = i.Bio
            }).FirstOrDefaultAsync(i => i.InstructorId == id);

            if (instructor == null)
                return new() { Status = Status.NotFound, Message = "Instructor not found." };
            return new() { Data = instructor, Status = Status.Success };
        }

        public async Task<ServiceResponse<InstructorDetailsResponse>> CreateInstructorAsync(CreateInstructorRequest request)
        {
            var newInstructor = new Instructor
            {
                InstructorId = Guid.NewGuid(),
                FullName = request.FullName,
                Email = request.Email,
                IsActive = true,
                Specialization = request.Specialization,
                Bio = request.Bio
            };
            await context.Instructors.AddAsync(newInstructor);
            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                var response = new ServiceResponse<InstructorDetailsResponse> { Status = Status.Error };

                if (ex.InnerException != null && ex.InnerException.Message.Contains("duplicate"))
                    response.Message = "An instructor with the same email already exists.";
                else
                    response.Message = "An error occurred while adding the intructor.";

                return response;
            }

            return new()
            {
                Data = new InstructorDetailsResponse
                {
                    InstructorId = newInstructor.InstructorId,
                    FullName = newInstructor.FullName,
                    Email = newInstructor.Email,
                    IsActive = newInstructor.IsActive,
                    Specialization = newInstructor.Specialization,
                    Bio = newInstructor.Bio,
                    CreatedAt = newInstructor.CreatedAt
                },
                Status = Status.Success
            };
        }

        public async Task<ServiceResponse<InstructorDetailsResponse>> UpdateInstructorAsync(Guid id, UpdateInstructorRequest request)
        {
            var instructor = await context.Instructors.FindAsync(id);
            if (instructor == null)
                return new() { Status = Status.NotFound, Message = "Instructor not found." };
            instructor.FullName = request.FullName;
            instructor.Email = request.Email;
            instructor.Specialization = request.Specialization;
            instructor.Bio = request.Bio;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                var response = new ServiceResponse<InstructorDetailsResponse> { Status = Status.Error };
                if (ex.InnerException != null && ex.InnerException.Message.Contains("duplicate"))
                    response.Message = "An instructor with the same email already exists.";
                else
                    response.Message = "An error occurred while updating the intructor.";
                return response;
            }

            return new()
            {
                Data = new InstructorDetailsResponse
                {
                    InstructorId = instructor.InstructorId,
                    FullName = instructor.FullName,
                    Email = instructor.Email,
                    IsActive = instructor.IsActive,
                    Specialization = instructor.Specialization,
                    Bio = instructor.Bio,
                    CreatedAt = instructor.CreatedAt
                },
                Status = Status.Success
            };
        }

        public async Task<ServiceResponse<InstructorDetailsResponse>> DeleteInstructorAsync(Guid id)
        {
            var instructor = await context.Instructors.FindAsync(id);
            if (instructor == null)
                return new() { Status = Status.NotFound, Message = "Instructor not found." };
            instructor.IsActive = false;
            await context.SaveChangesAsync();
            return new()
            {
                Data = new()
                {
                    InstructorId = instructor.InstructorId,
                    FullName = instructor.FullName,
                    Email = instructor.Email,
                    IsActive = instructor.IsActive,
                    Specialization = instructor.Specialization,
                    Bio = instructor.Bio,
                    CreatedAt = instructor.CreatedAt
                },
                Status = Status.Success
            };
        }

        public async Task<ServiceResponse<InstructorTracksResponse>> GetInstructorTracks(Guid id)
        {
            var instructor = await context.Instructors.Include(t => t.TrainingTracks)
                .SingleOrDefaultAsync(i => i.InstructorId == id);

            if (instructor == null)
                return new() { Status = Status.NotFound, Message = "Instructor not found." };

            return new()
            {
                Data = new()
                {
                    InstructorId = instructor.InstructorId,
                    FullName = instructor.FullName,
                    Email = instructor.Email,
                    IsActive = instructor.IsActive,
                    Specialization = instructor.Specialization,
                    Bio = instructor.Bio,
                    CreatedAt = instructor.CreatedAt,
                    TrainingTracks = instructor.TrainingTracks.Select(t => new TrackSummaryResponse
                    {
                        TrainingTrackId = t.TrainingTrackId,
                        Title = t.Title,
                        Code = t.Description,
                        Status = t.Status,
                    }).ToList()
                },
                Status = Status.Success
            };
        }
    }
}
