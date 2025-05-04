using session40_50.Models;

namespace session40_50.Interfaces
{
    public interface IUserRepository
    {
        Task<User> CreateUserAsync(User user);
    }
}