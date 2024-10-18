using Loan.Application.DTOs;
using Loan.DataAccess.Models;

namespace Loan.Application.Services.Abstraction
{
    public interface IEmployeeService : IGenericService<Employee, EmployeeDto>
    {
        Task<List<EmployeeDto>> GetByBranchIdAsync(Guid branchId);
        Task<EmployeeDto> CreateAsync(EmployeeDto employee, Guid branchId);
        
    }
}