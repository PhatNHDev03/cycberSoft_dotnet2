using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Org.BouncyCastle.Pqc.Crypto.Crystals.Dilithium;
using session40_50.Interfaces;
using session40_50.Models;
using session40_50.Models.DTOs;
using session40_52.Interfaces;
using session40_52.Models.DTOs;

namespace session40_50.Services
{
    public class AuthService : IUserService
    {
        private readonly IEmailService _emailService;
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        public AuthService(IEmailService emailService, IUserRepository userRepository, IConfiguration configuration)
        {
            _emailService = emailService;
            _userRepository = userRepository;
            _configuration = configuration;
        }
        private string GenerateJwtToken(User user)
        {
            // lấy key tạo token từ appsettings.json
            var securityKey = _configuration["Jwt:Key"];
            var formatKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
            var credentials = new SigningCredentials(formatKey, SecurityAlgorithms.HmacSha256);

            // tạo claims (lưu những info cơ bản của user để BE verify)
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role) // truyền info Role vào claim
            };

            // tạo token
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"], // required
                audience: _configuration["Jwt:Audience"], // required
                claims: claims, //required
                expires: DateTime.Now.AddHours(1), // required
                signingCredentials: credentials //required
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public async Task<User> CreateUserAsync(UserDTO user)
        {
            // ma hóa password
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            //tao token khi tao user --> tao toekn vo nghia vao` de tranh bi doan ra quy luat
            var token = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
            //tạo link verify new account
            //link này để api verfiy email
            var baseUrl = _configuration["AppSettings:BaseUrl"];
            var verifyUrl = $"{baseUrl}/api/auth/verify-email?token={token}";
            var newUser = new User
            {
                Email = user.Email,
                Password = user.Password,
                Name = user.Name,
                VerificationToken = token,
                IsEmailVerified = false,// default là false để khi tạo mới thì chưa verify email
                CreatedAt = DateTime.UtcNow,
                Role = user.role
            };

            await _userRepository.CreateUserAsync(newUser);

            //send  email to new user
            var emailBody = $@"<h1>welcome {user.Name}</h1>
            <p>you are registered successfully</p>
            <p> your user name is {user.Email}</p>
            <a href='{verifyUrl}'> Verify your email </a>
            ";
            await _emailService.SendEmailAsync(user.Email, "welcome", emailBody);
            return newUser;
        }

        public async Task<string?> LoginAsync(LoginRequestDTO loginDTO)
        {
            var user = await _userRepository.GetUserByEmailAsync(loginDTO.Email);
            if (user == null)
            {
                return null;
            }
            // kiểm tra password
            // Verify có 2 tham số
            // tham số 1 là password được nhập từ client
            // tham số 2 là password được mã hóa trong DB
            // return là true nếu password nhập đúng, ngược lại false
            if (!BCrypt.Net.BCrypt.Verify(loginDTO.Password, user.Password))
            {
                Console.WriteLine("Password không đúng");
                return null;
            }

            // kiểm tra email đã được verify chưa
            if (!user.IsEmailVerified)
            {
                return null;
            }
            var token = GenerateJwtToken(user);
            return token;
        }
        public async Task<User?> VerifyEmailAsync(string token)
        {
            return await _userRepository.GetUserByVerificationTokenAsync(token);

        }

        // flow forgot password
        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _userRepository.GetUserByEmailAsync(email);
        }

        public async Task<User?> ForgotPasswordAsync(string email)
        {
            var user = await GetUserByEmailAsync(email);
            if (user == null) return null;
            var GenerateResetPasswodToken = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
            var tokenResetPass = GenerateResetPasswodToken;
            user.ResetPasswordToken = tokenResetPass;
            user.ExpiresTokenResetPassword = DateTime.Now.AddHours(1);
            var result = await _userRepository.UpdateUserAsync(user);
            if (result == null) return null;
            // gui email toi nguoi dung 
            await _emailService.SendEmailAsync(email, "Reset Password", $"your reset token is{tokenResetPass}");
            return user;
        }

        public async Task<User?> ResetPasswordAsync(ResetPassDTO resetPasswordRequest)
        {
            var user = await _userRepository.GetUserResetToken(resetPasswordRequest.resetToken);
            if (user == null) return null;
            user.Password = BCrypt.Net.BCrypt.HashPassword(resetPasswordRequest.Password);
            user.ResetPasswordToken = null;
            user.ExpiresTokenResetPassword = null;
            await _userRepository.UpdateUserAsync(user);
            return user;
        }
    }
}
