using System.ComponentModel.DataAnnotations;
using Loan.Application.DTOs;

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
public class CreateProductViewModel
{
    public IFormFile ThumbnailFile { get; set; }
    public List<IFormFile> ImageFiles { get; set; }
    public ProductDto Product { get; set; }
    public List<CategoryDto>? Categories { get; set; }
}