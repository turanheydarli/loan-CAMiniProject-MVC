using System.ComponentModel.DataAnnotations;
using Loan.Application.DTOs;
using Loan.WebMVC.Areas.Admin.Controllers;

namespace Loan.WebMVC.Models;

public class MerchantApplyViewModel
{
    public MerchantDto Merchant { get; set; }
}

public class CreateBranchViewModel
{
    public BranchDto Branch { get; set; }
    public AddressDto Address { get; set; }
}



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

public class MerchantProfileViewModel
{
    public Guid MerchantId { get; set; }
    public Guid Token { get; set; }

    [Required]
    [MaxLength(100, ErrorMessage = "Business Name cannot exceed 100 characters.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Please upload your logo.")]
    public IFormFile Logo { get; set; }

    [Required]
    [Phone(ErrorMessage = "Invalid contact number.")]
    public string ContactNumber { get; set; }

    [Required]
    [MaxLength(200, ErrorMessage = "Address cannot exceed 200 characters.")]
    public string Address { get; set; }
}