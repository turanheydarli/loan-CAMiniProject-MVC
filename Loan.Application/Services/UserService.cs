using System.Security.Authentication;
using Loan.Application.DTOs;
using Loan.Application.Exceptions;
using Loan.Application.Services.Abstraction;
using Loan.DataAccess.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Loan.Application.Services;

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

    public async Task LogoutAsync()
    {
        await _signinManager.SignOutAsync();
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

        return new()
        {
            Id = user.Id,
            Email = user.Email,
            UserName = user.UserName,
        };
    }

    public async Task<UserDto> RegisterAsDraftAsync(UserDto registerDto)
    {
        AppUser user = new AppUser()
        {
            UserName = registerDto.Email,
            Email = registerDto.Email,
        };

        IdentityResult result = await _userManager.CreateAsync(user);

        if (!result.Succeeded)
        {
            throw new IdentityException(result.Errors);
        }

        return new()
        {
            Id = user.Id,
            Email = user.Email,
            UserName = user.UserName,
        };
    }

    public async Task<List<UserDto>> GetAllAsync()
    {
        var users = await _userManager.Users.ToListAsync();

        return users.Select(u => new UserDto
        {
            Id = u.Id,
            Email = u.Email,
            UserName = u.UserName,
        }).ToList();
    }

    public async Task AddUserToRoleAsync(string userId, string role)
    {
        var user = await _userManager.FindByIdAsync(userId);

        if (user == null)
        {
            throw new AuthenticationException("Invalid username or password.");
        }

        if (!await _roleManager.RoleExistsAsync(role))
        {
            await _roleManager.CreateAsync(new AppRole
            {
                Name = role
            });
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

    public async Task<UserDto> GetUserByEmailAsync(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);

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

    public async Task ResetPasswordAsync(UserDto user, string resetToken, string password)
    {
        var userToResrt = await _userManager.FindByIdAsync(user.Id);

        if (userToResrt == null)
        {
            throw new Exception("User not found.");
        }

        await _userManager.ResetPasswordAsync(userToResrt, resetToken, password);
    }

    public async Task<string> GeneratePasswordResetTokenAsync(UserDto userDto)
    {
        var user = await _userManager.FindByIdAsync(userDto.Id);

        if (user == null)
        {
            throw new Exception("User not found.");
        }

        return await _userManager.GeneratePasswordResetTokenAsync(user);
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