using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using BLL.Services;
using View.Models;

namespace View.Controllers;

public class HomeController : Controller {
    private readonly RegionService _regionService;
    private readonly UserService _userService;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, RegionService regionService, UserService userService) {
        _logger = logger;
        _regionService = regionService;
        _userService = userService;
    }

    public IActionResult Index() => View();

    [ActionName("Region")]
    public async Task<IActionResult> ShowRegion(string data) {
        var region = (await _regionService.FindByConditionAsync(x => x.Identifier == data)).FirstOrDefault();
        if (region == null) return RedirectToAction("Index");
        ViewData["Title"] = region.Name;
        return View();
    }

    public IActionResult Login() => RedirectToPage("Login");

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}