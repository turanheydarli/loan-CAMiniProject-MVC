using System.ComponentModel.DataAnnotations;
using Loan.Application.Features.EmployeeServices.DTOs;

namespace Loan.Application.Features.EmployeeServices.Abstraction
{
    public interface IEmployeeService
    {
        Task<EmployeeDto> CreateEmployeeAsync(EmployeeCreateDto employee);
        Task<EmployeeDto> GetEmployeeByIdAsync(int employeeId);
        Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync();
        Task<IEnumerable<EmployeeDto>> GetEmployeesByBranchIdAsync(int branchId);
        Task<EmployeeDto> UpdateEmployeeAsync(EmployeeDto employeeDto);
        Task DeleteEmployeeAsync(int employeeId);
    }
}