using Loan.Application.DTOs;
using Loan.DataAccess.Models;

namespace Loan.Application.Services.Abstraction;

public interface IGenericService<TEntity, TDto> where TEntity : BaseEntity where TDto : BaseDto
{
    Task<TDto> CreateAsync(TDto entity);
    Task<TDto> GetByIdAsync(Guid entityId);
    Task<List<TDto>> GetAllAsync();
    Task<TDto> UpdateAsync(TDto entity);
    Task DeleteAsync(Guid entityId);
}