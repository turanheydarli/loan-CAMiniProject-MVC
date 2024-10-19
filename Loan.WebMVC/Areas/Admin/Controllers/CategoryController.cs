using AutoMapper;
using Loan.Application.DTOs;
using Loan.Application.Services.Abstraction;
using Loan.DataAccess.Models;
using Loan.WebMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Loan.WebMVC.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class CategoryController : Controller
{
    private readonly ICategoryService _categoryService;
    private readonly IBranchService _branchService;
    private readonly IMapper _mapper;

    public CategoryController(ICategoryService categoryService, IBranchService branchService, IMapper mapper)
    {
        _categoryService = categoryService;
        _branchService = branchService;
        _mapper = mapper;
    }

    public async Task<IActionResult> Index()
    {
        var categories = await _categoryService.GetAllAsync();
        return View(categories);
    }

    public async Task<IActionResult> Create()
    {
        var parentCategories = await _categoryService.GetAllAsync();

        var model = new CreateCategoryViewModel
        {
            ParentCategories = parentCategories
        };

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateCategoryViewModel model)
    {
        if (ModelState.IsValid)
        {
            var category = new CategoryDto()
            {
                Name = model.Name,
                ParentId = model.ParentId,
            };

            var createdCategory = await _categoryService.CreateAsync(category);

             await _categoryService.SetThumbnailAsync(createdCategory.Id, new MediaDto() { File = model.ThumbnailFile });

            return RedirectToAction(nameof(Index));
        }

        model.ParentCategories = _mapper.Map<List<CategoryDto>>(await _categoryService.GetAllAsync());

        return View(model);
    }
}