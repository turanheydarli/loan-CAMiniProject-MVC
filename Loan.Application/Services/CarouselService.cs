using AutoMapper;
using Loan.Application.DTOs;
using Loan.Application.MimeServer;
using Loan.Application.Services.Abstraction;
using Loan.DataAccess.Models;
using Loan.DataAccess.Persistence;
using Loan.DataAccess.Persistence.Repositories;

namespace Loan.Application.Services;

public class CarouselService : GenericService<CarouselItem, CarouselItemDto>, ICarouselService
{
    private readonly IMediaService _mediaService;

    public CarouselService(IAsyncRepository<CarouselItem, AppDbContext> repository, IMapper mapper,
        IMediaService mediaService) : base(repository,
        mapper)
    {
        _mediaService = mediaService;
    }

    public override async Task<List<CarouselItemDto>> GetAllAsync()
    {
        var carouselItems = await base.GetAllAsync();

        foreach (var carouselItem in carouselItems)
        {
            carouselItem.BannerImage = await _mediaService.GetFileAsync(carouselItem.BannerImageId);
        }

        return carouselItems;
    }

    public async Task SetBannerAsync(Guid carouselId, MediaDto banner)
    {
        if (banner == null)
            throw new ArgumentNullException(nameof(banner));

        var product = await _repository.GetAsync(p => p.Id == carouselId);

        if (product == null)
            throw new ApplicationException($"CarouselItem with ID {carouselId} not found.");

        var addedImageId = await _mediaService.UploadFileAsync(banner, OwnerType.CarouselBanner, carouselId);

        product.BannerImageId = addedImageId;

        product.ModifiedDate = DateTime.UtcNow;

        await _repository.UpdateAsync(product);
    }
}