using System.ComponentModel.DataAnnotations;

namespace session40_50.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }


        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty; // password đã được mã hóa

        public bool IsEmailVerified { get; set; } = true;

        public string? VerificationToken { get; set; } = string.Empty;

        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;

        //them column role
        public string Role { get; set; } = "User";

        public string? ResetPasswordToken { get; set; } = string.Empty;

        public DateTime? ExpiresTokenResetPassword { get; set; }

    }
}