using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Loan.WebMVC.Areas.Admin.Controllers;

[Area("Admin")]
public class DashboardController : Controller
{
    
    public async Task<IActionResult> Index()
    {
        return View();
    }
}