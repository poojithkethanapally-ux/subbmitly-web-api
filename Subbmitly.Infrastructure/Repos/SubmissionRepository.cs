using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Subbmitly.Application.DTOs;
using Subbmitly.Application.Interfaces;
using Subbmitly.Domain.Entities;

namespace Subbmitly.Infrastructure.Repos
{
    public class SubmissionRepository : ISubmissionRepository
    {
        private readonly RecruitMgmtDbContext _context;
        private readonly ILogger<SubmissionRepository> _logger;

        public SubmissionRepository(RecruitMgmtDbContext context, ILogger<SubmissionRepository> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<List<SubmissionResponse>> GetSubmissions()
        {
            var submissions = await _context.Submissions
                .Include(s => s.Candidate)
                    .ThenInclude(c => c.User)
                .Include(s => s.Recruiter)
                    .ThenInclude(r => r.User)
                .ToListAsync();

            var result = submissions.Select(s => new SubmissionResponse
            {
                SubmissionId = s.SubmissionId,
                CandidateId = s.CandidateId,
                CandidateName = s.Candidate?.User?.FullName,
                RecruiterId = s.RecruiterId,
                RecruiterName = s.Recruiter?.User?.FullName,
                ClientName = s.ClientName,
                VendorName = s.VendorName,
                JobTitle = s.JobTitle,
                JobDescription = s.JobDescription,
                RequiredSkills = s.RequiredSkills,
                Rate = s.Rate,
                Location = s.Location,
                EmploymentType = s.EmploymentType,
                SubmissionDate = s.SubmissionDate,
                CurrentStatus = s.CurrentStatus,
                CreatedDate = s.CreatedDate
            }).ToList();

            return result;
        }

        public async Task<bool> CreateSubmissionAsync(CreateSubmissionRequest request)
        {
            try
            {
                var submission = new Submission
                {
                    CandidateId = await _context.Candidates.Where(x => x.UserId == request.CandidateId).Select(x => x.CandidateId).FirstOrDefaultAsync(),
                    RecruiterId = await _context.Recruiters.Where(x => x.UserId == request.RecruiterId).Select(x => x.RecruiterId).FirstOrDefaultAsync(),
                    CurrentStatus = request.Status,
                    SubmissionDate = request.SubmissionDate ?? DateTime.Now,
                    ClientName = request.ClientName,
                    VendorName = request.VendorName,
                    VendorContactName = request.VendorContactName,
                    VendorContactEmail = request.VendorContactEmail,
                    VendorContactPhone = request.VendorContactPhone,
                    JobTitle = request.JobTitle,
                    JobDescription = request.JobDescription,
                    RequiredSkills = request.RequiredSkills,
                    Rate = request.Rate,
                    Location = request.Location,
                    CandidateLocation = request.CandidateLocation,
                    EmploymentType = request.EmploymentType,
                    CreatedDate = DateTime.Now
                };

                _context.Submissions.Add(submission);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Error creating submission for CandidateId {CandidateId} and RecruiterId {RecruiterId}",
                    request.CandidateId,
                    request.RecruiterId);
                return false;
            }
        }
    }
}