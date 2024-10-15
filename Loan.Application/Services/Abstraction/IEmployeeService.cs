using Loan.Application.DTOs;
using Loan.DataAccess.Models;

namespace Loan.Application.Services.Abstraction
{
    public interface IEmployeeService : IGenericService<Employee, EmployeeDto>
    {
        Task<List<EmployeeDto>> GetByBranchIdAsync(int branchId);
    }
}