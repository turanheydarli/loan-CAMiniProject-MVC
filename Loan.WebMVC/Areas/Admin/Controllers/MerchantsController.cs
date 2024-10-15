using Loan.Application.DTOs;
using Loan.Application.Services.Abstraction;
using Loan.WebMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Loan.WebMVC.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin,Merchant")]
public class MerchantsController : Controller
{
    private readonly IMerchantService _merchantService;
    private readonly IUserService _userService;

    public MerchantsController(IMerchantService merchantService, IUserService userService)
    {
        _merchantService = merchantService;
        _userService = userService;
    }

    public async Task<IActionResult> Index()
    {
        var merchants = await _merchantService.GetAllAsync();

        return View(merchants);
    }

    public async Task<IActionResult> Create()
    {
        // var users = await _userService.GetAllAsync();
        //
        // return View(new MerchantApplyViewModel()
        // {
        //     Merchant = new MerchantDto(),
        //     Users = users
        // });
        return View();

    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create(MerchantApplyViewModel model)
    {
        // await _merchantService.CreateAsync(model.Merchant, model.UserId);
        //
        // return RedirectToAction("Index");

        return View();
    }
}