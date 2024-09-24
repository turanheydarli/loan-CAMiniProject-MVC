using System.ComponentModel.DataAnnotations;
using Loan.Application.Features.BranchServices.DTOs;

namespace Loan.Application.Features.BranchServices.Abstraction;

public interface IBranchService
{
    Task<BranchDto> CreateBranchAsync(BranchCreateDto branch);
    Task<BranchDto> GetBranchByIdAsync(int branchId);
    Task<IEnumerable<BranchDto>> GetAllBranchesAsync();
    Task<BranchDto> UpdateBranchAsync(BranchDto branchDto);
    Task DeleteBranchAsync(int merchantId);
}