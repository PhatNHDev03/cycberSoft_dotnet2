using System.ComponentModel.DataAnnotations;
public class ContactModel
{
    [Required(ErrorMessage = "Please Enter your name")]
    [MinLength(2, ErrorMessage = "Name must be at least 3 charaters Long")]
    public string FullName { get; set; } = string.Empty;
    [Required(ErrorMessage = "Please enter your email")]
    [EmailAddress(ErrorMessage = "Please Enter a valid email address")]
    public string Email { get; set; } = string.Empty;
    [Required(ErrorMessage = "Phone number must be 10 to 12 digits")]
    [RegularExpression(@"^\d{10,12}$", ErrorMessage = "Phone number must be 10 to 12 digits")]
    public string PhoneNumber { get; set; } = string.Empty;
    [MinLength(5, ErrorMessage = "Address must be at least 5 characters")]

    public string Address { get; set; }
    [Required(ErrorMessage = "Message must be at least 10 characters long")]
    [MinLength(10, ErrorMessage = "Message must be at least 10 characters long")]

    public string Message { get; set; }
    [Required(ErrorMessage = "Please select a services")]
    public string service { get; set; }
    [MustBeTrue(ErrorMessage = "You must agree before submit")]
    public bool IsAgree { get; set; }
}