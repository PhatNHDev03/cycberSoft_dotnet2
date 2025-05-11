using System.ComponentModel.DataAnnotations;

namespace session40_52.Models.DTOs
{
    public class ResetPassDTO
    {
        [Required]
        public string resetToken { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }


}