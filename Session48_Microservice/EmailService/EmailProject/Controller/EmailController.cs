using EmailProject.DTOs;
using EmailProject.Service;
using Microsoft.AspNetCore.Mvc;

namespace EmailProject.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailController : ControllerBase
    {
        private readonly EmailService _emailService;
        public EmailController(EmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost("welcome")]
        public async Task<IActionResult> SendWellcomeEmail([FromBody] WelcomeEmailRequest request)
        {
            try
            {
                await _emailService.SendWellcomeEmailAsync(request.Email, request.UserName);
                return Ok("Email sent successfully   ");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}