using Loan.DataAccess.Models;

namespace Loan.Application.DTOs;

public record ProductDto : BaseDto
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int StockCount { get; set; }
    public string Model { get; set; }
    public string Brand { get; set; }

    public Guid CategoryId { get; set; }
    public CategoryDto Category { get; set; }

    public MediaDto Thumbnail { get; set; }
    public ICollection<MediaDto> Images { get; set; }
    public ICollection<LoanItem> LoanItems { get; set; }
}