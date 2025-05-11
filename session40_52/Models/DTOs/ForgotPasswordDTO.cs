using System.ComponentModel.DataAnnotations;

namespace session40_52.Models.DTOs
{
    public class ForgotPasswordDTO
    {
        [Required(ErrorMessage = "Please enter your email")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; } = string.Empty;
    }
}