using Subbmitly.Application.DTOs;
using Subbmitly.Domain.Entities;

namespace Subbmitly.Application.Interfaces
{
    public interface IUserProfileRepository
    {
        Task<List<UserResponse>> GetUserInfo();

        Task<bool> CreateUserAsync(CreateUserRequest request);
    }
}
