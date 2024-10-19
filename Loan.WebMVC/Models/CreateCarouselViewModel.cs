using System.ComponentModel.DataAnnotations;
using Loan.Application.DTOs;

namespace Loan.WebMVC.Models;

public class CreateCarouselViewModel
{
    [Required(ErrorMessage = "Title is required.")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Title must be between 3 and 100 characters.")]
    public string Title { get; set; }

    [StringLength(250, ErrorMessage = "Offer cannot exceed 250 characters.")]
    public string Offer { get; set; }

    [Url(ErrorMessage = "Please enter a valid URL.")]
    [Display(Name = "Link")]
    public string Link { get; set; }

    [Display(Name = "Is Active")]
    public bool IsActive { get; set; }

    [Required(ErrorMessage = "Category selection is required.")]
    [Display(Name = "Category")]
    public Guid CategoryId { get; set; }

    [Required(ErrorMessage = "Banner image is required.")]
    [Display(Name = "Banner Image")]
    [DataType(DataType.Upload)]
    public IFormFile BannerImageFile { get; set; }

    public List<CategoryDto>? Categories { get; set; }
}