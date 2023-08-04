using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using rar.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace rar.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private RoleManager<IdentityRole> roleManager;
    private UserManager<User> userManager;

    public HomeController(ILogger<HomeController> logger, RoleManager<IdentityRole> roleManager,
      UserManager<User> userManager)
    {
        _logger = logger;
        roleManager = roleManager;
        userManager = userManager;

    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Home() => View();
    public IActionResult About() => View();
    public IActionResult FAQ() => View();

    public IActionResult Contact() => View();

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
