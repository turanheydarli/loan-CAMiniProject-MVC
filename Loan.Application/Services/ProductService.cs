using System.Net.Mime;
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

        public override async Task<List<ProductDto>> GetAllAsync()
        {
            var products = await base.GetAllAsync();

            foreach (var product in products)
            {
                product.Thumbnail = await _mediaService.GetFileAsync(product.ThumbnailId);
            }

            return products;
        }

        public async Task<List<ProductDto>> GetAllTrendingProducts()
        {
            var productEntities = await _repository.GetListAsync();

            var products = _mapper.Map<List<ProductDto>>(productEntities);

            foreach (var product in products)
            {
                product.Thumbnail = await _mediaService.GetFileAsync(product.ThumbnailId);
            }

            return products;
        }

        public async Task AddProductImagesAsync(Guid productId, List<MediaDto> images)
        {
            if (images == null || !images.Any())
                throw new ArgumentException("No images provided.");

            var product = await _repository.GetAsync(p => p.Id == productId);

            if (product == null)
                throw new ApplicationException($"Product with ID {productId} not found.");


            product.ModifiedDate = DateTime.UtcNow;
            await _repository.UpdateAsync(product);
        }


        public async Task SetProductThumbnailAsync(Guid productId, MediaDto thumbnailDto)
        {
            if (thumbnailDto == null)
                throw new ArgumentNullException(nameof(thumbnailDto));

            var product = await _repository.GetAsync(p => p.Id == productId);

            if (product == null)
                throw new ApplicationException($"Product with ID {productId} not found.");

            var addedImageId = await _mediaService.UploadFileAsync(thumbnailDto, OwnerType.ProductThumbnail, productId);

            product.ThumbnailId = addedImageId;

            product.ModifiedDate = DateTime.UtcNow;

            await _repository.UpdateAsync(product);
        }
    }
}