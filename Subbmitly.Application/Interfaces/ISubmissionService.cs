
using Subbmitly.Application.DTOs;

namespace Subbmitly.Application.Interfaces
{
    public interface ISubmissionService
    {
        Task<bool> CreateSubmissionAsync(CreateSubmissionRequest request);

    }
}