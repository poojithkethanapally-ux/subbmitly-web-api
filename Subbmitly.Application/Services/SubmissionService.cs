using Microsoft.EntityFrameworkCore;
using Subbmitly.Application.DTOs;
using Subbmitly.Application.Interfaces;
using Subbmitly.Domain.Entities;

namespace Subbmitly.Application.Services
{
    public class SubmissionService : ISubmissionService
    {
        private readonly ISubmissionRepository _submissionRepository;

        public SubmissionService(ISubmissionRepository submissionRepository)
        {
            _submissionRepository = submissionRepository;
        }

        public async Task<bool> CreateSubmissionAsync(CreateSubmissionRequest request)
        {
            return await _submissionRepository.CreateSubmissionAsync(request);
        }

    }
}