using Loan.Application.Services.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace Loan.WebMVC.ViewComponents;

public class HeaderCarouselViewComponent : ViewComponent
{
    private readonly ICarouselService _carouselService;

    public HeaderCarouselViewComponent(ICarouselService carouselService)
    {
        _carouselService = carouselService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var carouselItems = await _carouselService.GetAllAsync();

        return View(carouselItems);
    }
}