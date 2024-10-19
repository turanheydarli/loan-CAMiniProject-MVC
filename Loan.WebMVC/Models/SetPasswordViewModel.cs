using System.ComponentModel.DataAnnotations;

namespace Loan.WebMVC.Models;

public class SetPasswordViewModel
{
    public Guid MerchantId { get; set; }
    public string? Token { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [MinLength(6, ErrorMessage = "Password must be at least 6 characters long.")]
    public string Password { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Passwords do not match.")]
    public string ConfirmPassword { get; set; }
}