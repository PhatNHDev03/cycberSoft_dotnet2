using session40_50.Models;
using session40_50.Models.DTOs;

namespace session40_52.Interfaces
{
    public interface IUserService
    {
        Task<User> CreateUserAsync(UserDTO user);
    }
}