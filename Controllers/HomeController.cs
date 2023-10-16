using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using rar.Models;
using rar.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace rar.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private RoleManager<IdentityRole> roleManager;
    private UserManager<User> userManager;
    private IAccount context;

    public HomeController(ILogger<HomeController> logger, RoleManager<IdentityRole> roleManager_,
      UserManager<User> userManager_, IAccount ctx)
    {
        _logger = logger;
        roleManager = roleManager_;
        userManager = userManager_;
        context = ctx;

    }

    
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        
        BaseViewModel vm = new BaseViewModel();
        vm.Accounts = context.Accounts;
        return View(vm);
    }

    //[Authorize(Roles="Admins")]
    public IActionResult Home() 
    {
        
        BaseViewModel vm = new BaseViewModel();
        vm.Accounts = context.Accounts;
        return View(vm);
    }

    public IActionResult About()
    {
        BaseViewModel vm = new BaseViewModel();
        vm.Accounts = context.Accounts;
        return View(vm);
    }
    public IActionResult FAQ()
    {
        BaseViewModel vm = new BaseViewModel();
        vm.Accounts = context.Accounts;
        return View(vm);
    }
 
    public IActionResult Contact() 
    {
        BaseViewModel vm = new BaseViewModel();
        vm.Accounts = context.Accounts;
        return View(vm);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
