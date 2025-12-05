using Microsoft.AspNetCore.Mvc;
using Subbmitly.Infrastructure;
using Subbmitly.Domain.Entities;
using Subbmitly.Application.Interfaces;
using Subbmitly.Application.Services;
using Subbmitly.Application.DTOs;

namespace Subbmitly.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserProfileController : ControllerBase
    {
        private readonly IUserProfileService userProfileService;

        public UserProfileController(IUserProfileService userProfileService)
        {
            this.userProfileService = userProfileService;
        }

        [HttpGet("getUserInfo")]
        public async Task<IActionResult> GetUserInfo()
        {
            var users = await userProfileService.GetUserInfo();
            return Ok(users);
        }

        [HttpPost("createUser")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
        {
            var result = await userProfileService.CreateUserAsync(request);
            return Ok(result);
        }
    }
}
