using AutoMapper;
using Loan.Application.DTOs;
using Loan.Application.Services.Abstraction;
using Loan.DataAccess.Models;
using Loan.DataAccess.Persistence;
using Loan.DataAccess.Persistence.Repositories;

namespace Loan.Application.Services;

public class GenericService<TEntity, TDto> : IGenericService<TEntity, TDto>
    where TEntity : BaseEntity where TDto : BaseDto
{
    protected readonly IAsyncRepository<TEntity, AppDbContext> _repository;
    protected readonly IMapper _mapper;

    public GenericService(IAsyncRepository<TEntity, AppDbContext> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public virtual async Task<TDto> CreateAsync(TDto entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        var entityToCreate = _mapper.Map<TEntity>(entity);

        var createdBranch = await _repository.AddAsync(entityToCreate);

        return _mapper.Map<TDto>(createdBranch);
    }

    public virtual async Task<TDto> GetByIdAsync(int entityId)
    {
        var entity = await _repository.GetAsync(m => m.Id == entityId);

        if (entity == null)
        {
            throw new ApplicationException($"{typeof(TEntity)} does not exist.");
        }

        return _mapper.Map<TDto>(entity);
        ;
    }

    public virtual async Task<List<TDto>> GetAllAsync()
    {
        var allEntities = await _repository.GetListAsync();

        return _mapper.Map<List<TDto>>(allEntities);
        ;
    }

    public virtual async Task<TDto> UpdateAsync(TDto entity)
    {
        var entityToUpdate = await _repository.GetAsync(m => m.Id == entity.Id);

        if (entityToUpdate == null)
        {
            throw new ApplicationException($"{typeof(TEntity)} does not exist.");
        }

        entityToUpdate.ModifiedDate = DateTime.UtcNow;

        return _mapper.Map<TDto>(entityToUpdate);
    }

    public virtual async Task DeleteAsync(int entityId)
    {
        var entityToDelete = await _repository.GetAsync(m => m.Id == entityId);

        if (entityToDelete == null)
        {
            throw new ApplicationException($"{typeof(TEntity)} does not exist.");
        }

        await _repository.DeleteAsync(entityToDelete);
    }
}