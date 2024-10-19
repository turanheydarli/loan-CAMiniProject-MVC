using Loan.Application.DTOs;
using Loan.DataAccess.Models;

namespace Loan.Application.Services.Abstraction;

public interface ICarouselService : IGenericService<CarouselItem, CarouselItemDto>
{
    Task SetBannerAsync(Guid carouselId, MediaDto banner);
}