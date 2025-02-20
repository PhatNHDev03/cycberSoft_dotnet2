using System.ComponentModel.DataAnnotations;
public class UserModel
{
    [Required(ErrorMessage = "Please input UserName")]
    [MinLength(8, ErrorMessage = "UserName must be at least at 8 charaters")]
    [MaxLength(20, ErrorMessage = "UserName must be at most at 20 charaters")]

    public string userName { get; set; } = string.Empty;
    [Required(ErrorMessage = "Please input password")]
    [MinLength(8, ErrorMessage = "Password must be at least at 8 charaters")]
    public string password { get; set; } = string.Empty;
    public string fullName { get; set; } = string.Empty;
    public string gender { get; set; } = "male";
    public string country { get; set; } = "VN";
    [Required(ErrorMessage = "Please input phone number")]
    [RegularExpression(@"^\d{10,12}$", ErrorMessage = "Phone number must be 10 to 12 digits")]
    public string PhoneNumber { get; set; }


}