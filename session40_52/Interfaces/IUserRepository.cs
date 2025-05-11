using session40_50.Models;

namespace session40_50.Interfaces
{
    public interface IUserRepository
    {
        Task<User> CreateUserAsync(User user);
        Task<User?> GetUserByVerificationTokenAsync(string token);

        Task<User?> GetUserByEmailAsync(string email);
        Task<User> UpdateUserAsync(User user);

        Task<User?> GetUserResetToken(string token);
    }
}