using AutoMapper;
using Loan.Application.DTOs;
using Loan.Application.Services.Abstraction;
using Loan.DataAccess.Models;
using Loan.DataAccess.Persistence;
using Loan.DataAccess.Persistence.Repositories;

namespace Loan.Application.Services;

public class EmployeeService : GenericService<Employee, EmployeeDto>, IEmployeeService
{
    public EmployeeService(IAsyncRepository<Employee, AppDbContext> repository, IMapper mapper) : base(repository,
        mapper)
    {
    }

    public async Task<List<EmployeeDto>> GetByBranchIdAsync(int branchId)
    {
        var employee = await _repository.GetListAsync(e => e.BranchId == branchId);
        var employeeDto = _mapper.Map<List<EmployeeDto>>(employee);
        return employeeDto;
    }

    public override async Task<EmployeeDto> UpdateAsync(EmployeeDto employeeDto)
    {
        var employee = await _repository.GetAsync(m => m.Id == employeeDto.Id);

        if (employee == null)
        {
            throw new ApplicationException("employee does not exist");
        }

        employee.Position = employeeDto.Position;
        employee.FirstName = employeeDto.FirstName;
        employee.LastName = employeeDto.LastName;

        employee.ModifiedDate = DateTime.UtcNow;

        return _mapper.Map<EmployeeDto>(employee);
    }
}