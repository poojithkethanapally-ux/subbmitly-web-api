using Microsoft.EntityFrameworkCore;
using Subbmitly.Application.DTOs;
using Subbmitly.Application.Interfaces;
using Subbmitly.Domain.Entities;
using Subbmitly.Infrastructure;

namespace Subbmitly.Infrastructure.Repos
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly RecruitMgmtDbContext _context;

        public UserProfileRepository(RecruitMgmtDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<User>> GetUserInfo()
        {
            var users = await _context.Users.ToListAsync();

            return users;
        }

        public async Task<bool> CreateUserAsync(CreateUserRequest request)
        {
            if (await _context.Users.AnyAsync(u => u.Email == request.email))
                throw new Exception("Email already exists.");

            int roleId = (int)request.role;

            if (!await _context.Roles.AnyAsync(r => r.RoleId == roleId))
                throw new Exception("Invalid role.");

            var user = new User
            {
                FullName = request.fullName,
                Email = request.email,
                IsActive = true,
                CreatedDate = DateTime.Now
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            _context.UserRoles.Add(new UserRole
            {
                UserId = user.UserId,
                RoleId = roleId,
                IsActive = true,
                CreatedDate = DateTime.Now
            });

            await _context.SaveChangesAsync();
            return true;
        }

    }
}


