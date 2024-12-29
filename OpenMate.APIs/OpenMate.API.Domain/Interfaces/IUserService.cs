using OpenMate.API.Domain.DTOs;
using OpenMate.API.Domain.Responses;

namespace OpenMate.API.Domain.Interfaces
{
    public interface IUserService
    {
        //Task<User> Authenticate(string username, string password);
        Task<IEnumerable<UserRes>> GetAll(string? query);
        Task<UserRes> GetById(string id);
        Task Create(UserDto user);
        Task Delete(string id);
    }
}
