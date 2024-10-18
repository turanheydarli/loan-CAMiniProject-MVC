using Loan.Application.Services.Abstraction;
using Loan.WebMVC.Models;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace Loan.WebMVC.Controllers;

public class EmployeeController : Controller
{
    private readonly IToastNotification _toastNotification;
    private readonly IEmployeeService _employeeService;
    private readonly IUserService _userService;

    public EmployeeController(IToastNotification toastNotification, IEmployeeService employeeService,
        IUserService userService)
    {
        _toastNotification = toastNotification;
        _employeeService = employeeService;
        _userService = userService;
    }


    [HttpGet]
    public IActionResult Activate([FromQuery] Guid userId, [FromQuery] string token)
    {
        var model = new ActivateAccountViewModel
        {
            UserId = userId,
            Token = token
        };

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Activate(ActivateAccountViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var emailConfirmed = await _userService.ConfirmEmailAsync(model.UserId, model.Token);

        if (!emailConfirmed)
        {
            ModelState.AddModelError("", "Invalid token.");
            return View(model);
        }

        await _userService.SetPasswordAsync(model.UserId, model.Password);


        return RedirectToAction("Login", "Auth");
    }
}