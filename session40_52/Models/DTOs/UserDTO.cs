using System.ComponentModel.DataAnnotations;

namespace session40_50.Models.DTOs
{
    public class UserDTO
    {


        public string Name { get; set; } = string.Empty;


        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty; // password đã được mã hóa

        public bool IsEmailVerified { get; set; } = false;

        public string? Token { get; set; }

        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;

    }

}