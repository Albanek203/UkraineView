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
        ViewData["Title"] = region!.Name;
        return View(region);
    }

    public IActionResult Login() => RedirectToPage("Login");
}