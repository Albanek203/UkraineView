namespace View.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Administrator")]
public class HomeController : Controller {
    public IActionResult Index() => View();
}