using Microsoft.AspNetCore.Mvc;
using session40_50.Models;
using session40_50.Models.DTOs;
using session40_52.Interfaces;
using session40_52.Models.DTOs;
namespace session40_50.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] UserDTO user)
        {
            try
            {
                var result = await _userService.CreateUserAsync(user);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("verify-email")]
        public async Task<ActionResult> VerifyEmail([FromQuery] string token)
        {
            try
            {
                var user = await _userService.VerifyEmailAsync(token);
                if (user == null) return BadRequest("Invalid token");
                return Ok("Email verified successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login([FromBody] LoginRequestDTO loginDTO)
        {
            try
            {
                var token = await _userService.LoginAsync(loginDTO);
                if (token == null)
                {
                    return BadRequest("Invalid email or password");
                }
                return Ok(token);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("forgot-password")]
        public async Task<ActionResult> ForgotPassword([FromBody] ForgotPasswordDTO forgotPassword)
        {
            try
            {
                var result = await _userService.ForgotPasswordAsync(forgotPassword.Email);
                if (result == null) return BadRequest("invalid Emial");
                return Ok("Password reset link has been sent to your email");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("reset-password")]
        public async Task<ActionResult> ResetPassWord([FromBody] ResetPassDTO resetPasswordRequest)
        {
            try
            {
                var result = await _userService.ResetPasswordAsync(resetPasswordRequest);
                if (result == null) return BadRequest("invalid token");
                return Ok("Password reset successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}