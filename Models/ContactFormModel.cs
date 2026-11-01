using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models;

public class ContactFormModel
{
    [Required(ErrorMessage = "Please enter your name.")]
    [StringLength(100, ErrorMessage = "Name must be under 100 characters.")]
    [Display(Name = "Name")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please enter your email.")]
    [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
    [StringLength(200)]
    [Display(Name = "Email")]
    public string Email { get; set; } = string.Empty;

    [StringLength(150)]
    [Display(Name = "Company")]
    public string? Company { get; set; }

    [Required(ErrorMessage = "Please enter a subject.")]
    [StringLength(200, ErrorMessage = "Subject must be under 200 characters.")]
    [Display(Name = "Subject")]
    public string Subject { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please enter a message.")]
    [StringLength(4000, MinimumLength = 10, ErrorMessage = "Message should be between 10 and 4000 characters.")]
    [Display(Name = "Message")]
    public string Message { get; set; } = string.Empty;
}
