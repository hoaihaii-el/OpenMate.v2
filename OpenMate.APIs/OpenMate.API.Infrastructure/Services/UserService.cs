using Microsoft.EntityFrameworkCore;
using OpenMate.API.Domain.DTOs;
using OpenMate.API.Domain.Entities;
using OpenMate.API.Domain.Exceptions;
using OpenMate.API.Domain.Helpers;
using OpenMate.API.Domain.Interfaces;
using OpenMate.API.Domain.Responses;
using OpenMate.API.Infrastructure.Data;

namespace OpenMate.API.Infrastructure.Services
{
    public class UserService(DataContext context) : IUserService
    {
        public async Task Create(UserDto user)
        {
            var newUser = new User
            {
                Id = user.Id,
                PasswordHash = UserHelper.GeneratePasswordHash(user.Password ?? ""),
                Name = user.Name,
                MainRole = user.MainRole,
                SkillSet = user.SkillSet
            };

            context.Users.Add(newUser);
            await context.SaveChangesAsync();
        }

        public async Task Delete(string id)
        {
            var user = await context.Users.FindAsync(id);
            
            if (user == null) throw new AppException("User not found");

            context.Users.Remove(user);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserRes>> GetAll(string? query)
        {
            return string.IsNullOrEmpty(query) ? await context.Users.Select(u => new UserRes
            {
                Id = u.Id,
                Name = u.Name,
                MainRole = u.MainRole,
                SkillSet = u.SkillSet
            }).ToListAsync() :
            await context.Users
                .Where(u => u.Name!.Contains(query) || u.Id!.Contains(query))
                .Select(u => new UserRes
            {
                Id = u.Id,
                Name = u.Name,
                MainRole = u.MainRole,
                SkillSet = u.SkillSet
            }).ToListAsync();
        }

        public async Task<UserRes> GetById(string id)
        {
            return await context.Users.FindAsync(id) switch
            {
                null => throw new AppException("User not found"),
                var user => new UserRes
                {
                    Id = user.Id,
                    Name = user.Name,
                    MainRole = user.MainRole,
                    SkillSet = user.SkillSet
                }
            };
        }
    }
}
