using System.ComponentModel.DataAnnotations;

namespace Loan.WebMVC.Models;

public class ActivateAccountViewModel
{
    public Guid UserId { get; set; }
    public string Token { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    public string ConfirmPassword { get; set; }
}