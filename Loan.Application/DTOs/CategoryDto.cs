namespace Loan.Application.DTOs;

public record CategoryDto : BaseDto
{
    public string Name { get; set; }
    public Guid? ParentId { get; set; }
    public int Depth { get; set; }
    public Guid ThumbnailId { get; set; }
    public MediaDto Thumbnail { get; set; }
    public CategoryDto ParentCategory { get; set; }
    public ICollection<CategoryDto> SubCategories { get; set; }
    public ICollection<ProductDto> Products { get; set; }
}