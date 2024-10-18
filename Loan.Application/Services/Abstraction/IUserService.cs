using Loan.Application.DTOs;

namespace Loan.Application.Services.Abstraction;

public interface IUserService
{
    Task<UserLoginDto> LoginAsync(UserLoginDto loginDto);
    Task LogoutAsync();
    Task<UserDto> RegisterAsync(UserRegisterDto registerDto);
    Task<UserDto> RegisterAsDraftAsync(UserDto registerDto);
    Task<List<UserDto>> GetAllAsync();
    Task AddUserToRoleAsync(Guid userId, string role);
    Task<bool> IsUserInRoleAsync(Guid userId, string role);
    Task<UserDto> GetUserByIdAsync(Guid userId);
    Task<UserDto> GetUserByEmailAsync(string email);
    Task ResetPasswordAsync(UserDto user, string resetToken, string password);
    Task<string> GeneratePasswordResetTokenAsync(UserDto user);
    Task<string> GenerateEmailConfirmationTokenAsync(UserDto createdUser);
    Task<bool> ConfirmEmailAsync(Guid userId, string token);
    Task SetPasswordAsync(Guid userId, string password);
}