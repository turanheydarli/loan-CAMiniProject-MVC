using System.Security.Authentication;
using Loan.Application.Features.AuthServices.Abstraction;
using Loan.Application.Features.AuthServices.DTOs;
using Loan.DataAccess.Models;
using Loan.Shared.Exceptions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Loan.Application.Features.AuthServices;

public class UserService : IUserService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signinManager;
    private readonly RoleManager<AppRole> _roleManager;

    public UserService(UserManager<AppUser> userManager, SignInManager<AppUser> signinManager,
        RoleManager<AppRole> roleManager)
    {
        _userManager = userManager;
        _signinManager = signinManager;
        _roleManager = roleManager;

    }

    public async Task<UserDto> RegisterAsync(UserRegisterDto registerDto)
    {
        AppUser user = new AppUser()
        {
            UserName = registerDto.Username,
            Email = registerDto.Email,
        };

        IdentityResult result = await _userManager.CreateAsync(user, registerDto.Password);

        if (!result.Succeeded)
        {
            throw new IdentityException(result.Errors);
        }

        await _userManager.AddToRoleAsync(user, "Admin");

        return new()
        {
            Id = user.Id,
            Email = user.Email,
            UserName = user.UserName,
        };
    }

    public async Task AddUserToRoleAsync(string userId, string role)
    {
        var user = await _userManager.FindByIdAsync(userId);

        if (user == null)
        {
            throw new AuthenticationException("Invalid username or password.");
        }

        if (!await _userManager.IsInRoleAsync(user, role))
        {
            await _userManager.AddToRoleAsync(user, role);
        }
    }

    public async Task<bool> IsUserInRoleAsync(string userId, string role)
    {
        var user = await _userManager.FindByIdAsync(userId);

        if (user == null)
        {
            throw new AuthenticationException("Invalid username or password.");
        }

        return await _userManager.IsInRoleAsync(user, role);
    }

    public async Task<UserDto> GetUserByIdAsync(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);

        if (user == null)
        {
            return null;
        }

        return new UserDto()
        {
            Id = user.Id,
            Email = user.Email,
            UserName = user.UserName,
        };
    }

    public async Task<bool> CheckIfUserNullAsync(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);

        return user == null;
    }

    public async Task<UserLoginDto> LoginAsync(UserLoginDto loginDto)
    {
        AppUser user = await _userManager.FindByNameAsync(loginDto.Username);

        if (user == null)
        {
            throw new UserNotFoundException(loginDto.Username);
        }

        var result = await _signinManager.PasswordSignInAsync(user,
            loginDto.Password,
            loginDto.IsPersistent,
            loginDto.LockoutOnFailure);

        if (!result.Succeeded)
        {
            throw new InvalidCredentialException(loginDto.Username);
        }

        return loginDto;
    }
}