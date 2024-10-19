using Loan.Application.DTOs;
using Loan.Application.MimeServer;
using Loan.Application.Services.Abstraction;
using Loan.WebMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Loan.WebMVC.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Employee")]
public class ProductController : Controller
{
    private readonly IProductService _productService;
    private readonly ICategoryService _categoryService;
    private readonly IMediaService _mediaService;

    public ProductController(
        IProductService productService,
        ICategoryService categoryService,
        IMediaService mediaService)
    {
        _productService = productService;
        _categoryService = categoryService;
        _mediaService = mediaService;
    }

    public async Task<IActionResult> Index()
    {
        var products = await _productService.GetAllAsync();
        return View(products);
    }

    public async Task<IActionResult> Details(Guid id)
    {
        var product = await _productService.GetByIdAsync(id);
        if (product == null)
            return NotFound();

        return View(product);
    }

    public async Task<IActionResult> Create()
    {
        var categories = await _categoryService.GetAllAsync();
        var model = new CreateProductViewModel
        {
            Product = new ProductDto(),
            Categories = categories
        };

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateProductViewModel model)
    {
        if (ModelState.IsValid)
        {
            var createdProduct = await _productService.CreateAsync(model.Product);

            await _productService.SetProductThumbnailAsync(createdProduct.Id, new MediaDto()
            {
                File = model.ThumbnailFile
            });

            await _productService.AddProductImagesAsync(createdProduct.Id, model.ImageFiles.Select(f => new MediaDto()
            {
                File = f
            }).ToList());

            return RedirectToAction(nameof(Index));
        }

        var categories = await _categoryService.GetAllAsync();
        model.Categories = categories;
        return View(model);
    }


    public async Task<IActionResult> Delete(Guid id)
    {
        var product = await _productService.GetByIdAsync(id);
        if (product == null)
            return NotFound();

        return View(product);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(Guid id)
    {
        await _productService.DeleteAsync(id);

        return RedirectToAction(nameof(Index));
    }
}