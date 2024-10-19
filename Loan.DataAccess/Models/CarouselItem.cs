namespace Loan.DataAccess.Models;

public class CarouselItem : BaseEntity
{
    public string ImagePath { get; set; }
    public string Title { get; set; }
    public string Offer { get; set; }
    public string Link { get; set; }
    public bool IsActive { get; set; }

    public Guid BannerImageId { get; set; }
}