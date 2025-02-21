using System.ComponentModel.DataAnnotations;

public class UserContact
{
    [Required(ErrorMessage = "Full name must be at least 3 characters long")]
    [MinLength(3, ErrorMessage = "Full name must be at least 3 characters long")]
    public string FullName { get; set; }
    [Required(ErrorMessage = "Please enter a valid email address")]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$",
     ErrorMessage = "Please enter a valid email address")]
    public string Email { get; set; }
    [Required(ErrorMessage = "Phone number must be 10 to 12 digits")]
    [RegularExpression(@"^\d{10,12}$", ErrorMessage = "Phone number must be 10 to 12 digits")]
    public string PhoneNumber { get; set; }

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