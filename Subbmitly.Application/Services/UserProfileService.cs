using Subbmitly.Application.DTOs;
using Subbmitly.Application.Interfaces;
using Subbmitly.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Subbmitly.Application.Services
{
    public class UserProfileService : IUserProfileService
    {
        private readonly IUserProfileRepository userProfileRepository;

        public UserProfileService(IUserProfileRepository userProfileRepository)
        {
            this.userProfileRepository = userProfileRepository;
        }

        public async Task<List<User>> GetUserInfo()
        {
            return await userProfileRepository.GetUserInfo();
        }

        public async  Task<bool> CreateUserAsync(CreateUserRequest request)
        {
            return await userProfileRepository.CreateUserAsync(request);
        }
    }
}



