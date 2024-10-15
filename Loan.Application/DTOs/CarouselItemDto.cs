namespace Loan.Application.DTOs;

public record CarouselItemDto : BaseDto
{
    public string ImagePath { get; set; }
    public string Title { get; set; }
    public string Offer { get; set; }
    public string Link { get; set; }
    public bool IsActive { get; set; }
    public int CategoryId { get; set; }
}