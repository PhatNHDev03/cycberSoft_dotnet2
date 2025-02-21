using System.ComponentModel.DataAnnotations;

public class courses
{
    [Required(ErrorMessage = "Please Enter your name")]
    [MinLength(2, ErrorMessage = "Name must be at least 3 charaters Long")]
    public string Fullname { get; set; } = string.Empty;
    [Required(ErrorMessage = "Please enter your email")]
    [EmailAddress(ErrorMessage = "Please Enter a valid email address")]
    public string Email { get; set; }
    [Required(ErrorMessage = "Please enter phone number")]
    [RegularExpression(@"^\d{10,12}$", ErrorMessage = "Phone number must be 10 to 12 digits")]
    public string PhoneNumber { get; set; }
    [Required(ErrorMessage = "Please enter course")]
    public string Course { get; set; }
    [Required(ErrorMessage = "Please choose study mode")]
    public string StudyMode { get; set; }
    [Required(ErrorMessage = "Please enter start date")]
    public DateTime StartDate { get; set; }
    public string message { get; set; }
    [MustBeTrue(ErrorMessage = "You must agree before submit")]

    public bool IsAgree { get; set; }
}