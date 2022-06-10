namespace View.Controllers;

[Authorize(Roles = "Administrator")]
public class UserController : Controller, IJsonResponsePagination<User> {
    private readonly UserService _userService;
    private readonly UserManager<User> _userManager;

    public UserController(UserService userService, UserManager<User> userManager) {
        _userService = userService;
        _userManager = userManager;
    }

#region JsonResponsePagination

    public async Task<IActionResult> List(string pageNumber) {
        if (!int.TryParse(pageNumber, out var pageNumberInt)) pageNumberInt = 1;
        ViewData["userManager"] = _userManager;
        return View(await GetByChunk(pageNumberInt, 10));
    }

    [HttpPost]
    public async Task<IActionResult> JsonResponse(string pageNumber) {
        int.TryParse(pageNumber, out var pageNumberInt);
        var chunk = await GetByChunk(pageNumberInt, 10);
        var enumerable = chunk.Select(async x => new {
            photoPath = string.IsNullOrWhiteSpace(x.Image?.Path) ? "null" : x.Image.Path, nickname = x.NickName
          , role = (await _userManager.GetRolesAsync(x)).FirstOrDefault(), gender = x.isMale ? "Male" : "Female"
          , birthDay = x.BirthDay.ToString("dd MMMM yyyy")
          , phone = string.IsNullOrWhiteSpace(x.PhoneNumber) ? "null" : x.PhoneNumber, email = x.Email
        });
        return Json(enumerable);
    }

    public async Task<IReadOnlyCollection<User>> GetByChunk(int pageNumber = 1, int pageSize = 1) {
        var chunk = await _userService.GetPaginationAsync(pageNumber, pageSize);
        ViewData["ChunkCount"] = await _userService.GetCountAsync() / pageSize + 1;
        return chunk;
    }

#endregion
}