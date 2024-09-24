namespace Loan.WebMVC.Models;

public class LoginViewModel
{
    public string Username { get; set; }
    public string Password { get; set; }
    public bool IsPersistent { get; set; }
    public bool LockoutOnFailure { get; set; }
}