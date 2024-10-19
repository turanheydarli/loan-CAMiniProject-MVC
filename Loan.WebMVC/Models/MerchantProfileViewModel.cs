using System.ComponentModel.DataAnnotations;

namespace Loan.WebMVC.Models;

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