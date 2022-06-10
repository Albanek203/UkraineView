namespace View.Areas.Manager.Controllers;

[Area("Manager")]
[Authorize(Roles = "Manager")]
public class HomeController : Controller {
    public IActionResult Index() => View();
}