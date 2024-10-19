using Loan.Application.DTOs;
using Loan.DataAccess.Models;

namespace Loan.Application.Services.Abstraction;

public interface ICategoryService : IGenericService<Category, CategoryDto>
{
    Task SetThumbnailAsync(Guid categoryId, MediaDto thumbnail);
}