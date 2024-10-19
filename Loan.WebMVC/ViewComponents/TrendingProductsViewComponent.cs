using Loan.Application.Services.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace Loan.WebMVC.ViewComponents;

public class TrendingProductsViewComponent : ViewComponent
{
    private readonly IProductService _productService;

    public TrendingProductsViewComponent(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var merchants = await _productService.GetAllTrendingProducts();

        return View(merchants);
    }
}