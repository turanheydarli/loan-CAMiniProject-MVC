namespace Loan.Application.DTOs;

public record CategoryDto : BaseDto
{
    public string Name { get; set; }
    public int? ParentId { get; set; }
    public int BranchId { get; set; }

    public int Depth { get; set; }

    public CategoryDto ParentCategory { get; set; }
    public ICollection<CategoryDto> SubCategories { get; set; }
    // public ICollection<ProductDto> Products { get; set; }
    public BranchDto Branch { get; set; }
}