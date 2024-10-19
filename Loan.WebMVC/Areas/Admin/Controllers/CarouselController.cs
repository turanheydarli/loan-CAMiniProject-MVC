using Loan.Application.DTOs;
using Loan.Application.Services.Abstraction;
using Loan.WebMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace Loan.WebMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CarouselController : Controller
    {
        private readonly ICarouselService _carouselService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CarouselController(ICarouselService carouselService, ICategoryService categoryService, IMapper mapper)
        {
            _carouselService = carouselService;
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var carouselItems = await _carouselService.GetAllAsync();
            return View(carouselItems);
        }

        public async Task<IActionResult> Create()
        {
            var categories = await _categoryService.GetAllAsync();

            var model = new CreateCarouselViewModel
            {
                Categories = categories.ToList()
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateCarouselViewModel model)
        {
            if (ModelState.IsValid)
            {
                var createdCarousel = await _carouselService.CreateAsync(new CarouselItemDto()
                {
                    IsActive = true,
                    Link = model.Link,
                    Offer = model.Offer,
                    Title = model.Title,
                    CategoryId = model.CategoryId
                });

                await _carouselService.SetBannerAsync(createdCarousel.Id, new MediaDto()
                {
                    File = model.BannerImageFile
                });

                return RedirectToAction(nameof(Index));
            }

            model.Categories = (await _categoryService.GetAllAsync()).ToList();
            return View(model);
        }
    }
}