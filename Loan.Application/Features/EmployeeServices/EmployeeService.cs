using AutoMapper;
using Loan.Application.Features.EmployeeServices.Abstraction;
using Loan.Application.Features.EmployeeServices.DTOs;
using Loan.DataAccess.Models;
using Loan.DataAccess.Persistence;
using Loan.DataAccess.Persistence.Repositories;

namespace Loan.Application.Features.EmployeeServices;

public class EmployeeService : IEmployeeService
{
    private readonly IAsyncRepository<Employee, AppDbContext> _employeeRepository;
    private readonly IMapper _mapper;

    public EmployeeService(IAsyncRepository<Employee, AppDbContext> employeeRepository, IMapper mapper)
    {
        _employeeRepository = employeeRepository;
        _mapper = mapper;
    }

    public async Task<EmployeeDto> CreateEmployeeAsync(EmployeeCreateDto employee)
    {
        var employeeToCreate = _mapper.Map<Employee>(employee);
        var createdEmployee = await _employeeRepository.AddAsync(employeeToCreate);
        return _mapper.Map<EmployeeDto>(createdEmployee);
    }

    public async Task<EmployeeDto> GetEmployeeByIdAsync(int employeeId)
    {
        var employee = await _employeeRepository.GetAsync(e => e.Id == employeeId);
        var employeeDto = _mapper.Map<EmployeeDto>(employee);
        return employeeDto;
    }

    public async Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync()
    {
        var employee = await _employeeRepository.GetListAsync();
        var employeeDto = _mapper.Map<IEnumerable<EmployeeDto>>(employee);
        return employeeDto;
    }

    public async Task<IEnumerable<EmployeeDto>> GetEmployeesByBranchIdAsync(int branchId)
    {
        var employee = await _employeeRepository.GetListAsync(e => e.BranchId == branchId);
        var employeeDto = _mapper.Map<IEnumerable<EmployeeDto>>(employee);
        return employeeDto;
    }

    public async Task<EmployeeDto> UpdateEmployeeAsync(EmployeeDto employeeDto)
    {
        var employee = await _employeeRepository.GetAsync(m => m.Id == employeeDto.Id);

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

    public async Task DeleteEmployeeAsync(int employeeId)
    {
        var employee = await _employeeRepository.GetAsync(m => m.Id == employeeId);

        if (employee == null)
        {
            throw new ApplicationException("employee does not exist");
        }

        await _employeeRepository.DeleteAsync(employee);
    }
}