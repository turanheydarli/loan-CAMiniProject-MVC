using AutoMapper;
using Loan.Application.DTOs;
using Loan.Application.Services.Abstraction;
using Loan.DataAccess.Models;
using Loan.DataAccess.Persistence;
using Loan.DataAccess.Persistence.Repositories;

namespace Loan.Application.Services;

public class CategoryService : GenericService<Category, CategoryDto>, ICategoryService
{
    public CategoryService(IAsyncRepository<Category, AppDbContext> repository, IMapper mapper) : base(repository, mapper)
    {
    }

    public override async Task<CategoryDto> CreateAsync(CategoryDto entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        if (entity.ParentId.HasValue)
        {
            var parentCategory = await _repository.GetAsync(c => c.ParentId == entity.ParentId);

            if (parentCategory == null)
            {
                throw new ArgumentException("Invalid ParentId", nameof(entity.ParentId));
            }

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
}