using System.Security.Claims;
using AutoMapper;
using Loan.Application.DTOs;
using Loan.Application.Services.Abstraction;
using Loan.WebMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Loan.WebMVC.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin,Merchant")]
public class EmployeeController : Controller
{
    private readonly IEmployeeService _employeeService;
    private readonly IBranchService _branchService;
    private readonly IMerchantService _merchantService;
    private readonly IUserService _userService;

    public EmployeeController(IEmployeeService employeeService, IUserService userService, IBranchService branchService,
        IMerchantService merchantService)
    {
        _employeeService = employeeService;
        _userService = userService;
        _branchService = branchService;
        _merchantService = merchantService;
    }

    public async Task<IActionResult> Index()
    {
        var employees = await _employeeService.GetAllAsync();

        return View(employees);
    }


    [Authorize(Roles = "Merchant")]
    public async Task<IActionResult> Create()
    {
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrEmpty(userIdClaim) || !Guid.TryParse(userIdClaim, out Guid userId))
        {
            return Unauthorized();
        }

        var merchant = await _merchantService.GetByUserIdAsync(userId);

        if (merchant == null)
        {
            return NotFound("Merchant not found.");
        }

        var branches = await _branchService.GetAllByMerchantId(merchant.Id);

        var model = new CreateEmployeeViewModel
        {
            Employee = new EmployeeDto(),
            Branches = branches != null && branches.Any() ? branches : new List<BranchDto>()
        };

        return View(model);
    }


    [HttpPost]
    [Authorize(Roles = "Merchant")]
    public async Task<IActionResult> Create(CreateEmployeeViewModel model)
    {
        await _employeeService.CreateAsync(model.Employee, model.BranchId);

        return RedirectToAction("Index");
    }
}