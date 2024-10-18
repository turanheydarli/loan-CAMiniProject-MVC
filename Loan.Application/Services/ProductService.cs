using AutoMapper;
using Loan.Application.DTOs;
using Loan.Application.MimeServer;
using Loan.Application.Services.Abstraction;
using Loan.DataAccess.Models;
using Loan.DataAccess.Persistence;
using Loan.DataAccess.Persistence.Repositories;

namespace Loan.Application.Services
{
    public class ProductService : GenericService<Product, ProductDto>, IProductService
    {
        private readonly IMediaService _mediaService;

        public ProductService(IAsyncRepository<Product, AppDbContext> repository, IMapper mapper,
            IMediaService mediaService) : base(repository,
            mapper)
        {
            _mediaService = mediaService;
        }

        public async Task AddProductImagesAsync(Guid productId, List<MediaDto> images)
        {
            if (images == null || !images.Any())
                throw new ArgumentException("No images provided.");

            var product = await _repository.GetAsync(p => p.Id == productId);

            if (product == null)
                throw new KeyNotFoundException($"Product with ID {productId} not found.");

            foreach (var imageDto in images)
            {
                var addedImageId = await _mediaService.UploadFileAsync(imageDto, productId);

                product.Images.Add(new Media
                {
                    Id = addedImageId,
                });
            }

            product.ModifiedDate = DateTime.UtcNow;
            await _repository.UpdateAsync(product);
        }


        public async Task SetProductThumbnailAsync(Guid productId, MediaDto thumbnailDto)
        {
            
        }
    }
}