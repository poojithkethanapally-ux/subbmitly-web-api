using Subbmitly.Application.DTOs;
using Subbmitly.Application.Interfaces;

namespace Subbmitly.Application.Services
{
    public class SubmissionService : ISubmissionService
    {
        private readonly ISubmissionRepository _submissionRepository;

        public SubmissionService(ISubmissionRepository submissionRepository)
        {
            _submissionRepository = submissionRepository;
        }

        public async Task<List<SubmissionResponse>> GetSubmissions()
        {
            return await _submissionRepository.GetSubmissions();
        }

        public async Task<bool> CreateSubmissionAsync(CreateSubmissionRequest request)
        {
            return await _submissionRepository.CreateSubmissionAsync(request);
        }
    }
}