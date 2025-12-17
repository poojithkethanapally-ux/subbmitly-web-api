using Subbmitly.Application.DTOs;

namespace Subbmitly.Application.Interfaces
{
    public interface ISubmissionRepository
    {
        Task<bool> CreateSubmissionAsync(CreateSubmissionRequest request);

    }
}