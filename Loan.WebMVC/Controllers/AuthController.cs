using Loan.Application.DTOs;
using Loan.Application.Services.Abstraction;
using Loan.DataAccess.Models;
using Loan.WebMVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Loan.WebMVC.Controllers;

public class AuthController : Controller
{
    private readonly IUserService _userService;

    public AuthController(IUserService userService)
    {
        _userService = userService;
    }

    [Route("/auth/login", Name = "auth-login")]
    public IActionResult Login()
    {
        return View();
    }

    [Route("/auth/logout", Name = "auth-logout")]
    public async Task<IActionResult> Logout(LoginViewModel model)
    {
        await _userService.LogoutAsync();

        return RedirectToAction("Index", "Home");
    }

    [HttpPost]
    [Route("/auth/login", Name = "auth-login")]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var user = await _userService.LoginAsync(new UserLoginDto()
        {
            Password = model.Password,
            Username = model.Username,
            IsPersistent = model.IsPersistent,
            LockoutOnFailure = model.LockoutOnFailure,
        });

        if (user != null)
        {
            return RedirectToAction("Index", "Home");
        }

        return View();
    }

    [Route("/auth/register", Name = "auth-register")]
    public async Task<IActionResult> Register()
    {
        return View();
    }

    [HttpPost]
    [Route("/auth/register", Name = "auth-register")]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var user = await _userService.RegisterAsync(new()
        {
            Email = model.Email,
            ConfirmPassword = model.ConfirmPassword,
            Password = model.Password,
            UserName = model.Username,
        });

        if (user != null)
        {
            return RedirectToAction("Login", "Auth");
        }

        return View();
    }
}