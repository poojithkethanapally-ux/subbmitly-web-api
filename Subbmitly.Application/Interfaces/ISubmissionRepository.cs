using Subbmitly.Application.DTOs;

namespace Subbmitly.Application.Interfaces
{
    public interface ISubmissionRepository
    {
        Task<List<SubmissionResponse>> GetSubmissions();
        Task<bool> CreateSubmissionAsync(CreateSubmissionRequest request);
    }
}