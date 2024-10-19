namespace Loan.DataAccess.Models;

public class Media : BaseEntity
{
    public Guid OwnerId { get; set; }
    public OwnerType OwnerType { get; set; }
    public string FileName { get; set; }

    public string ContentType { get; set; }

    public string FilePath { get; set; }
}

public enum OwnerType
{
    ProductThumbnail,
    UserProfile,
    MerchantProfile,
    BusinessLicence,
    CategoryImage,
    MerchantBanner,
    ProductImages,
    CarouselBanner
}