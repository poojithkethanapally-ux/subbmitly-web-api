using Microsoft.EntityFrameworkCore;
using Subbmitly.Application.DTOs;
using Subbmitly.Application.Interfaces;
using Subbmitly.Domain.Entities;
using Subbmitly.Application.Const_and_Enums;

namespace Subbmitly.Infrastructure.Repos
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly RecruitMgmtDbContext _context;

        public UserProfileRepository(RecruitMgmtDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<UserResponse>> GetUserInfo()
        {
            var users = await _context.Users.Include(u => u.UserRoles).ThenInclude(ur => ur.Role).ToListAsync();
            var result = users.Select(u =>
            {
                var userRole = u.UserRoles?.FirstOrDefault(ur => ur.IsActive);
                string? roleString = userRole?.Role?.RoleName;

                if (string.IsNullOrWhiteSpace(roleString) && userRole != null)
                {
                    // Fallback: convert RoleId to enum name if it matches enum values
                    if (Enum.IsDefined(typeof(UserRoleEnum), userRole.RoleId))
                    {
                        roleString = ((UserRoleEnum)userRole.RoleId).ToString();
                    }
                }

                return new UserResponse
                {
                    UserId = u.UserId,
                    FullName = u.FullName,
                    Email = u.Email,
                    IsActive = u.IsActive,
                    CreatedDate = u.CreatedDate,
                    Role = roleString ?? "Unknown"
                };
            }).ToList();

            return result;
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

            // 5. Insert into Candidate or Recruiter table based on role
            if (request.role == UserRoleEnum.Candidate)
            {
                var candidate = new Candidate
                {
                    UserId = user.UserId,
                    //Phone = request.phone ?? null,
                    //Location = request.location ?? null,
                    //VisaStatus = request.visaStatus ?? null,
                    //TotalExperienceYrs = request.totalExp ?? null,
                    //PrimarySkills = request.primarySkills ?? null,
                    //SecondarySkills = request.secondarySkills ?? null,
                    ResumePath = null,
                    CreatedDate = DateTime.Now
                };

                _context.Candidates.Add(candidate);
                await _context.SaveChangesAsync();
            }
            else if (request.role == UserRoleEnum.Recruiter)
            {
                var recruiter = new Recruiter
                {
                    UserId = user.UserId,
                    //Phone = request.phone ?? null,
                    //VendorCompany = request.vendorCompany ?? null,
                    //CreatedDate = DateTime.Now
                };

                _context.Recruiters.Add(recruiter);
                await _context.SaveChangesAsync();
            }
            return true;
        }
    }
}



