using Loan.Application.DTOs;
using Loan.Application.Exceptions;
using Loan.Application.Services.Abstraction;
using Loan.DataAccess.Models;
using Loan.WebMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace Loan.WebMVC.Controllers;

public class MerchantController : Controller
{
    private readonly IToastNotification _toastNotification;
    private readonly IMerchantService _merchantService;
    private readonly IUserService _userService;

    public MerchantController(IMerchantService merchantService, IToastNotification toastNotification,
        IUserService userService)
    {
        _merchantService = merchantService;
        _toastNotification = toastNotification;
        _userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> Activate([FromQuery] Guid merchantId, [FromQuery] string token)
    {
        var isValid = await _merchantService.ValidateActivationTokenAsync(merchantId, token);

        if (!isValid)
        {
            _toastNotification.AddErrorToastMessage("Activation token is invalid");

            return View("ActivationError");
        }

        var merchant = await _merchantService.GetByIdAsync(merchantId);

        if (merchant.Status == MerchantStatus.Active)
        {
            _toastNotification.AddErrorToastMessage("Invalid operation");

            return RedirectToAction("Index", "Home");
        }

        return RedirectToAction("SetPassword", new { merchantId = merchantId, token = token });
    }


    [AllowAnonymous]
    [HttpGet]
    public IActionResult SetPassword(Guid merchantId, string token)
    {
        if (merchantId == Guid.Empty || string.IsNullOrEmpty(token))
        {
            _toastNotification.AddErrorToastMessage("Invalid token");

            return View();
        }

        var model = new SetPasswordViewModel
        {
            MerchantId = merchantId,
            Token = token
        };

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> SetPassword(SetPasswordViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var isValid = await _merchantService.ValidateActivationTokenAsync(model.MerchantId, model.Token);

        if (!isValid)
        {
            _toastNotification.AddErrorToastMessage("Activation token is invalid");

            return View("ActivationError");
        }

        try
        {
            await _merchantService.CompleteStepOneAsync(model.MerchantId, model.Password);

            return RedirectToAction("CompleteProfile");
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(model);
        }
    }


    [Authorize(Roles = "Merchant")]
    [HttpGet]
    public async Task<IActionResult> CompleteProfile()
    {
        var user = await _userService.GetUserByEmailAsync(User.Identity?.Name);

        var merchant = await _merchantService.GetByUserIdAsync(user.Id);

        if (merchant == null)
        {
            return View("Error");
        }

        var model = new MerchantProfileViewModel
        {
            MerchantId = merchant.Id,
        };

        return View(model);
    }

    [Authorize(Roles = "Merchant")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CompleteProfile(MerchantProfileViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        await _merchantService.CompleteStepTwoAsync(model.MerchantId, new MerchantDto()
        {
            Name = model.Name,
        });

        await _merchantService.SetProfileImageAsync(model.MerchantId, new MediaDto()
        {
            File = model.Logo,
        });

        return RedirectToAction("Index", "Dashboard", new { Area = "Admin" });
    }


    [HttpGet]
    public async Task<IActionResult> Apply()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Apply(MerchantApplyViewModel model)
    {
        if (ModelState.IsValid)
        {
            model.Merchant.BusinessLicense = new MediaDto()
            {
                File = model.BusinessLicenceFile
            };

            await _merchantService.ApplyAsync(model.Merchant);

            _toastNotification.AddSuccessToastMessage($"Merchant {model.Merchant.Name} successfully applied");
        }

        foreach (var modelState in ModelState.Values)
        {
            foreach (var error in modelState.Errors)
            {
                _toastNotification.AddErrorToastMessage(error.ErrorMessage);
            }
        }

        return View(model);
    }
}