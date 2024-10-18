using AutoMapper;
using Loan.Application.DTOs;
using Loan.Application.MimeServer;
using Loan.Application.Services.Abstraction;
using Loan.DataAccess.Models;
using Loan.DataAccess.Persistence;
using Loan.DataAccess.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using System.Web;
using Loan.Application.Mailing;

namespace Loan.Application.Services;

public class EmployeeService : GenericService<Employee, EmployeeDto>, IEmployeeService
{
    private readonly IUserService _userService;
    private readonly IMediaService _mediaService;
    private readonly IBranchService _branchService;
    private readonly IMailService _mailService;
    private readonly IConfiguration _configuration;

    public EmployeeService(
        IAsyncRepository<Employee, AppDbContext> repository,
        IMapper mapper,
        IUserService userService,
        IMediaService mediaService,
        IBranchService branchService,
        IMailService mailService,
        IConfiguration configuration)
        : base(repository, mapper)
    {
        _userService = userService;
        _mediaService = mediaService;
        _branchService = branchService;
        _mailService = mailService;
        _configuration = configuration;
    }

    public async Task<List<EmployeeDto>> GetByBranchIdAsync(Guid branchId)
    {
        var employees = await _repository.GetListAsync(e => e.BranchId == branchId);
        return _mapper.Map<List<EmployeeDto>>(employees);
    }

    public async Task<EmployeeDto> CreateAsync(EmployeeDto employeeDto, Guid branchId)
    {
        var user = await _userService.GetUserByEmailAsync(employeeDto.Email);

        if (user == null)
        {
            return await CreateAsync(employeeDto, branchId, new UserRegisterDto()
            {
                Email = employeeDto.Email,
            });
        }

        if (await _userService.IsUserInRoleAsync(user.Id, "Employee"))
        {
            throw new ApplicationException("User is already an employee");
        }

        await _userService.AddUserToRoleAsync(user.Id, "Employee");

        return await CreateEmployeeAsync(employeeDto, branchId, user.Id);
    }

    private async Task<EmployeeDto> CreateAsync(EmployeeDto employeeDto, Guid branchId, UserRegisterDto userDto)
    {
        var newUserDto = new UserDto()
        {
            Email = userDto.Email,
            UserName = userDto.Email
        };

        var createdUser = await _userService.RegisterAsDraftAsync(newUserDto);

        if (createdUser == null)
        {
            throw new ApplicationException("Failed to create user");
        }

        await _userService.AddUserToRoleAsync(createdUser.Id, "Employee");


        var token = await _userService.GenerateEmailConfirmationTokenAsync(createdUser);

        var baseUrl = _configuration["AppSettings:BaseUrl"];
        var activationLink =
            $"{baseUrl}/Employee/Activate?userId={createdUser.Id}&token={HttpUtility.UrlEncode(token)}";

        var subject = "Activate Your Employee Account";
        var message = $"Dear {employeeDto.FirstName},\n\n" +
                      "You have been added as an employee.\n\n" +
                      "Please activate your account by clicking the link below:\n" +
                      $"{activationLink}\n\n" +
                      "Best Regards,\n" +
                      "Loan App Team";

        await _mailService.SendEmailAsync(createdUser.Email, subject, message);

        return await CreateEmployeeAsync(employeeDto, branchId, createdUser.Id);
    }

    private async Task<EmployeeDto> CreateEmployeeAsync(EmployeeDto employeeDto, Guid branchId, Guid userId)
    {
        var branch = await _branchService.GetByIdAsync(branchId);

        if (branch == null)
        {
            throw new ApplicationException("Branch not found");
        }

        var employeeToCreate = new Employee()
        {
            BranchId = branch.Id,
            FirstName = employeeDto.FirstName,
            LastName = employeeDto.LastName,
            Position = employeeDto.Position,
            UserId = userId,
            CreatedDate = DateTime.UtcNow
        };

        var createdEmployee = await _repository.AddAsync(employeeToCreate);

        return _mapper.Map<EmployeeDto>(createdEmployee);
    }

    public override async Task<EmployeeDto> UpdateAsync(EmployeeDto employeeDto)
    {
        var employee = await _repository.GetAsync(m => m.Id == employeeDto.Id);

        if (employee == null)
        {
            throw new ApplicationException("Employee does not exist");
        }

        employee.Position = employeeDto.Position;
        employee.FirstName = employeeDto.FirstName;
        employee.LastName = employeeDto.LastName;
        employee.ModifiedDate = DateTime.UtcNow;

        await _repository.UpdateAsync(employee);

        return _mapper.Map<EmployeeDto>(employee);
    }
}