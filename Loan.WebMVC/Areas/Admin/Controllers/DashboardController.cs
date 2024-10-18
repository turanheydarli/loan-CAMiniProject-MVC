using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Loan.WebMVC.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin,Merchant,Employee")]
public class DashboardController : Controller
{
    public async Task<IActionResult> Index()
    {
        return View();
    }
    
    public async Task<IActionResult> Settings()
    {
        return View();
    }
}