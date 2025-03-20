using System.ComponentModel.DataAnnotations;

public class FeedbackModel
{
    [Required(ErrorMessage = "please Enter first name")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "please Enter last name")]
    public string LastName { get; set; }
    [Required(ErrorMessage = "please Enter Email name")]

    [EmailAddress(ErrorMessage = "enter valid emai !!!")]
    public string Email { get; set; }
    [Required(ErrorMessage = "please Enter user name")]

    public string UserName { get; set; }
    public double Cleaniness { get; set; } = 5;
    public double Staff { get; set; } = 5;
    public double Comfort { get; set; } = 5;
    public double Value { get; set; } = 5;
    public string feedbackText { get; set; }
}