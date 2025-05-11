using session40_50.Models;
using session40_50.Models.DTOs;
using session40_52.Models.DTOs;

namespace session40_52.Interfaces
{
    public interface IUserService
    {
        Task<User> CreateUserAsync(UserDTO user);
        Task<User?> VerifyEmailAsync(string token);
        Task<string> LoginAsync(LoginRequestDTO loginRequest);
        Task<User?> GetUserByEmailAsync(string email);
        Task<User?> ForgotPasswordAsync(string email);
        Task<User?> ResetPasswordAsync(ResetPassDTO resetPasswordRequest);
    }
}