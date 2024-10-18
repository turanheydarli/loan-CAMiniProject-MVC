using Loan.Application.DTOs;
using Loan.DataAccess.Models;

namespace Loan.Application.Services.Abstraction;

public interface IBranchService : IGenericService<Branch, BranchDto>
{
    Task<BranchDto> CreateAsync(BranchDto branch, Guid merchantId);
    Task<List<BranchDto>> GetAllByMerchantId(Guid merchantId);
}