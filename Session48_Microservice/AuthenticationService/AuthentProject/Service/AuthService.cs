using AuthentProject.Data;
using AuthentProject.DTOs;
using AuthentProject.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthentProject.Service
{
    public class AuthService
    {
        private readonly AuthDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _clientFactory;
        public AuthService(AuthDbContext context, IConfiguration configuration, IHttpClientFactory clientFactory)
        {
            _context = context;
            _configuration = configuration;
            _clientFactory = clientFactory;
        }
        public async Task<AuthResponse> register(RegisterDTO registerDTO)
        {

            if (await _context.Users.FirstOrDefaultAsync(x => x.Email == registerDTO.Email) != null) return null;
            var user = new User
            {
                Email = registerDTO.Email,
                Username = registerDTO.Username,
                PasswordHash = registerDTO.Password
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            //send mail
            var client = _clientFactory.CreateClient("EmailService");
            await client.PostAsJsonAsync("api/Email/welcome", new
            {
                Email = user.Email,
                Username = user.Username
            });
            return new AuthResponse
            {
                Token = Guid.NewGuid().ToString(),
                Email = user.Email,
                Username = user.Username
            };
        }
    }
}