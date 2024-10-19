using Loan.Application.Services.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace Loan.WebMVC.ViewComponents;

public class MerchantsViewComponent : ViewComponent
{
    private readonly IMerchantService _merchantService;

    public MerchantsViewComponent(IMerchantService merchantService)
    {
        _merchantService = merchantService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var merchants = await _merchantService.GetAllAsync();

        return View(merchants);
    }
}