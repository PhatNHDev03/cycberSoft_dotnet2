using System.ComponentModel.DataAnnotations;

public class UserContact
{
    [Required(ErrorMessage = "Please input full")]
    [MinLength(3, ErrorMessage = "Full name must be at least 3 characters")]
    public string FullName { get; set; }
    [Required(ErrorMessage = "Please input email")]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$",
     ErrorMessage = "Please enter a valid email address")]
    public string Email { get; set; }
    [Required(ErrorMessage = "Please input phone number")]
    [RegularExpression(@"^\d{10,12}$", ErrorMessage = "Phone number must be 10 to 12 digits")]
    public string PhoneNumber { get; set; }

    [MinLength(5, ErrorMessage = "Address must be at least 3 characters")]

    public string Address { get; set; }
    [Required(ErrorMessage = "Please input full")]
    [MinLength(10, ErrorMessage = "Message must be at least 3 characters")]
    public string Message { get; set; }
    public string service { get; set; }
    [Required(ErrorMessage = "You must agree before submit")]
    public bool IsAgree { get; set; }
}