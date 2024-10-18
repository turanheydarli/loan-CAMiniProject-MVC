using System.Security.Claims;
using Loan.Application.DTOs;
using Loan.Application.Services.Abstraction;
using Loan.WebMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Loan.WebMVC.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Merchant")]
public class BranchController : Controller
{
    private readonly IBranchService _branchService;
    private readonly IMerchantService _merchantService;

    public BranchController(IBranchService branchService, IMerchantService merchantService)
    {
        _branchService = branchService;
        _merchantService = merchantService;
    }

    public async Task<IActionResult> Index()
    {
        var merchant =
            await _merchantService.GetByUserIdAsync(Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value));
        var branches = await _branchService.GetAllByMerchantId(merchant.Id);

        return View(branches);
    }

    [Authorize(Roles = "Merchant")]
    public async Task<IActionResult> Create()
    {
        var merchant =
            await _merchantService.GetByUserIdAsync(Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value));

        return View(new CreateBranchViewModel()
        {
            Branch = new BranchDto()
            {
                MerchantId = merchant.Id
            },
            Address = new AddressDto()
        });
    }

    [HttpPost]
    [Authorize(Roles = "Merchant")]
    public async Task<IActionResult> Create(CreateBranchViewModel model)
    {
        var merchant =
            await _merchantService.GetByUserIdAsync(Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value));

        await _branchService.CreateAsync(model.Branch, merchant.Id);

        return RedirectToAction("Index");
    }
}