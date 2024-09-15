using Loan.Application.AuthServices.Abstraction;
using Loan.Application.AuthServices.DTOs;

namespace Loan.Application.AuthServices;

public class AuthService: IAuthService
{
    public Task<UserRegisterDto> Register(UserRegisterDto registerDto)
    {
        throw new NotImplementedException();
    }

    public Task<UserLoginDto> Login(UserLoginDto loginDto)
    {
        throw new NotImplementedException();
    }
}