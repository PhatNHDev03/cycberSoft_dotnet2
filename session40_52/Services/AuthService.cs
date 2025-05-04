using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using session40_50.Interfaces;
using session40_50.Models;
using session40_50.Models.DTOs;
using session40_52.Interfaces;

namespace session40_50.Services
{
    public class AuthService : IUserService
    {
        private readonly IEmailService _emailService;
        private readonly IUserRepository _userRepository;

        public AuthService(IEmailService emailService, IUserRepository userRepository)
        {
            _emailService = emailService;
            _userRepository = userRepository;
        }
        public async Task<User> CreateUserAsync(UserDTO user)
        {
            var newUser = new User
            {
                Email = user.Email,
                Password = user.Password,
                Name = user.Name,
                VerificationToken = "yes",
                IsEmailVerified = false,// default là false để khi tạo mới thì chưa verify email
                CreatedAt = DateTime.UtcNow
            };

            await _userRepository.CreateUserAsync(newUser);

            //send  email to new user
            var emailBody = $@"<h1>welcome {user.Name}</h1>
            <p>you are registered successfully</p>
            <p> your user name is {user.Email}</p>
            ";
            await _emailService.SendEmailAsync(user.Email, "welcome", emailBody);
            return newUser;
        }
    }
}