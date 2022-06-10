using System.Security.Claims;

namespace View.Controllers;

[Authorize(Roles = "Administrator,Manager")]
public class EntertainmentController : Controller, IJsonResponsePagination<Entertainment> {
    private readonly EntertainmentService _entertainmentService;
    private readonly RegionService _regionService;
    private readonly AdminService _adminService;
    private readonly UserManager<User> _userManager;

    public EntertainmentController(EntertainmentService entertainmentService
                                 , RegionService regionService
                                 , AdminService adminService
                                 , UserManager<User> userManager) {
        _entertainmentService = entertainmentService;
        _regionService = regionService;
        _adminService = adminService;
        _userManager = userManager;
    }

    public async Task<IActionResult> Create() {
        ViewData["listRegionName"] = await _regionService.GetOnlyNameListAsync();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Entertainment entertainment, string cityName) {
        var region = (await _regionService.FindByConditionAsync(x => x.Name == cityName)).FirstOrDefault()!;
        entertainment.Address.Region = region;
        entertainment.CreateDate = DateTime.Now;
        await _entertainmentService.CreateAsync(entertainment);
        return RedirectToAction(nameof(Create));
    }

#region JsonResponsePagination

    [Authorize(Roles = "Administrator")]
    public async Task<IActionResult> List(string pageNumber) {
        if (!int.TryParse(pageNumber, out var pageNumberInt)) pageNumberInt = 1;
        return View(await GetByChunk(pageNumberInt, 10));
    }

    [Authorize(Roles = "Manager")]
    public async Task<IActionResult> OwnList(string pageNumber) {
        if (!int.TryParse(pageNumber, out var pageNumberInt)) pageNumberInt = 1;
        return View(await GetByChunkOwnList(pageNumberInt, 10));
    }

    [HttpPost]
    public async Task<IActionResult> JsonResponse(string pageNumber) {
        int.TryParse(pageNumber, out var pageNumberInt);
        var chunk = await GetByChunk(pageNumberInt, 10);
        var enumerable = chunk.Select(x => new {
            name = x.Name, type = x.EntertainmentType, rating = x.Rating, region = x.Address.Region.Name
          , city = x.Address.City, street = x.Address.Street, activeStatus = x.IsChecked
        });
        return Json(enumerable);
    }

    [Authorize(Roles = "Administrator")]
    public async Task<IReadOnlyCollection<Entertainment>> GetByChunk(int pageNumber = 1, int pageSize = 1) {
        var chunk = await _entertainmentService.GetPaginationAsync(pageNumber, pageSize);
        ViewData["ChunkCount"] = await _entertainmentService.GetCountAsync() / pageSize + 1;
        return chunk;
    }

    [Authorize(Roles = "Manager")]
    private async Task<IReadOnlyCollection<Entertainment>> GetByChunkOwnList(int pageNumber = 1, int pageSize = 1) {
        var userHash = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var chunk = await _adminService.GetPaginationEntertainmentsByUserAsync(userHash, pageNumber, pageSize);
        ViewData["ChunkCount"] = await _adminService.GetEntertainmentsByUserCountAsync(userHash) / pageSize + 1;
        return chunk;
    }

#endregion
}