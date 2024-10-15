using Loan.Application.Services.Abstraction;
using Loan.WebMVC.Models;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace Loan.WebMVC.Controllers;

public class MerchantController : Controller
{
    private readonly IToastNotification _toastNotification;
    private readonly IMerchantService _merchantService;

    public MerchantController(IMerchantService merchantService, IToastNotification toastNotification)
    {
        _merchantService = merchantService;
        _toastNotification = toastNotification;
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
            await _merchantService.ApplyAsync(model.Merchant, model.User);

            _toastNotification.AddSuccessToastMessage($"Merchant {model.Merchant.Name} successfully applied");

            // if (result.Succeeded)
            // {
            //     // Assign "Merchant" role to the user
            //     await _userManager.AddToRoleAsync(user, "Merchant");
            //
            //     // Handle Business License Upload
            //     if (model.BusinessLicense != null && model.BusinessLicense.Length > 0)
            //     {
            //         var uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads/licenses");
            //         if (!Directory.Exists(uploadsFolder))
            //         {
            //             Directory.CreateDirectory(uploadsFolder);
            //         }
            //
            //         var uniqueFileName = $"{user.Id}_{Path.GetFileName(model.BusinessLicense.FileName)}";
            //         var filePath = Path.Combine(uploadsFolder, uniqueFileName);
            //         using (var fileStream = new FileStream(filePath, FileMode.Create))
            //         {
            //             await model.BusinessLicense.CopyToAsync(fileStream);
            //         }
            //
            //         // Save file path or name to user profile if needed
            //         user.BusinessLicensePath = $"/uploads/licenses/{uniqueFileName}";
            //         await _userManager.UpdateAsync(user);
            //     }
            //
            //     // Send Confirmation Email
            //     var subject = "Merchant Application Received";
            //     var message = $"Dear {model.ContactPerson},\n\n" +
            //                   "Thank you for applying to become a merchant on our platform. " +
            //                   "We have received your application and will review it shortly.\n\n" +
            //                   "Best Regards,\n" +
            //                   "Your Company Name";
            //
            //     await _emailService.SendEmailAsync(model.Email, subject, message);
            //
            //     // Optionally, redirect to a confirmation page
            //     return RedirectToAction("ApplyConfirmation");
            // }
            // else
            // {
            //     foreach (var error in result.Errors)
            //     {
            //         ModelState.AddModelError("", error.Description);
            //     }
            // }
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