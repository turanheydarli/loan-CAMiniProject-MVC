using AutoMapper;
using Loan.Application.DTOs;
using Loan.Application.MimeServer;
using Loan.Application.Services.Abstraction;
using Loan.DataAccess.Models;
using Loan.DataAccess.Persistence;
using Loan.DataAccess.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Loan.Application.Services;

public class CategoryService : GenericService<Category, CategoryDto>, ICategoryService
{
    private readonly IMediaService _mediaService;

    public CategoryService(IAsyncRepository<Category, AppDbContext> repository, IMapper mapper,
        IMediaService mediaService) : base(repository, mapper)
    {
        _mediaService = mediaService;
    }

    public override async Task<List<CategoryDto>> GetAllAsync()
    {
        var categories = await base.GetAllAsync();

        foreach (var product in categories)
        {
            product.Thumbnail = await _mediaService.GetFileAsync(product.ThumbnailId);
        }

        return categories;
    }

    public override async Task<CategoryDto> CreateAsync(CategoryDto entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        if (entity.ParentId != null)
        {
            var parentCategory = await _repository.GetAsync(c => c.ParentId == entity.ParentId);

            // if (parentCategory)
            // {
            //     throw new ArgumentException("Invalid ParentId", nameof(entity.ParentId));
            // }

            entity.Depth = parentCategory.Depth + 1;
        }
        else
        {
            entity.Depth = 0;
        }

        var entityToCreate = _mapper.Map<Category>(entity);

        var createdEntity = await _repository.AddAsync(entityToCreate);

        var createdDto = _mapper.Map<CategoryDto>(createdEntity);

        if (entity.ParentId.HasValue)
        {
            var parentCategoryDto = await _repository.GetAsync(c => c.ParentId == entity.ParentId);

            if (parentCategoryDto != null)
            {
                createdDto.ParentCategory = _mapper.Map<CategoryDto>(parentCategoryDto);
            }
        }

        return createdDto;
    }

    public async Task SetThumbnailAsync(Guid categoryId, MediaDto thumbnail)
    {
        if (thumbnail == null)
            throw new ArgumentNullException(nameof(thumbnail));

        var product = await _repository.GetAsync(p => p.Id == categoryId);

        if (product == null)
            throw new ApplicationException($"Category with ID {categoryId} not found.");


        var addedImageId = await _mediaService.UploadFileAsync(thumbnail, OwnerType.CategoryImage, categoryId);

        product.ThumbnailId = addedImageId;

        product.ModifiedDate = DateTime.UtcNow;

        await _repository.UpdateAsync(product);
    }
}