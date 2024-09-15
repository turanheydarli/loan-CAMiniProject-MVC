using Loan.DataAccess.Models;
using Loan.WebMVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Loan.WebMVC.Controllers;

public class AuthController : Controller
{
    [Route("/login", Name = "auth-login")]
    public async Task<IActionResult> Login()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Route("/login", Name = "auth-login")]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            return View();
        }

        return View();
    }
}