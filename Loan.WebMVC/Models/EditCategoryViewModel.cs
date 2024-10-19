using System.ComponentModel.DataAnnotations;
using Loan.Application.DTOs;

namespace Loan.WebMVC.Models;

public class EditCategoryViewModel
{
    [Required] public CategoryDto Category { get; set; }

    public List<CategoryDto> ParentCategories { get; set; }
}

public class CreateCategoryViewModel
{
    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string Name { get; set; }

    public Guid? ParentId { get; set; }

    public IFormFile ThumbnailFile { get; set; }

    public List<CategoryDto>? ParentCategories { get; set; }
}