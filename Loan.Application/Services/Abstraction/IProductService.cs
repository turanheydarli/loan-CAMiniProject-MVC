using Loan.Application.DTOs;
using Loan.DataAccess.Models;

namespace Loan.Application.Services.Abstraction;

public interface IProductService : IGenericService<Product, ProductDto>
{
    Task AddProductImagesAsync(Guid productId, List<MediaDto> images);
    Task SetProductThumbnailAsync(Guid productId, MediaDto thumbnail);
}