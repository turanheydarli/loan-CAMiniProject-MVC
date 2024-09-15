using Loan.Application.AuthServices.DTOs;

namespace Loan.Application.AuthServices.Abstraction;

public interface IAuthService
{
    Task<UserRegisterDto> Register(UserRegisterDto registerDto);
    Task<UserLoginDto> Login(UserLoginDto loginDto);
}