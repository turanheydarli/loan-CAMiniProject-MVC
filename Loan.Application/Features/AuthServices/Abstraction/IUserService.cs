using Loan.Application.Features.AuthServices.DTOs;
using Loan.DataAccess.Models;

namespace Loan.Application.Features.AuthServices.Abstraction;

public interface IUserService
{
    Task<UserLoginDto> LoginAsync(UserLoginDto loginDto);
    Task<UserDto> RegisterAsync(UserRegisterDto registerDto);
    Task AddUserToRoleAsync(string userId, string role);
    Task<bool> IsUserInRoleAsync(string userId, string role);
    Task<UserDto> GetUserByIdAsync(string userId);
    Task<bool> CheckIfUserNullAsync(string userId);
}