namespace View.Controllers;

[Authorize(Roles = "Administrator")]
public class RegionController : Controller, IJsonResponsePagination<Region> {
    private readonly RegionService _regionService;

    public RegionController(RegionService regionService) { _regionService = regionService; }

    public IActionResult Create() => View();

    [HttpPost]
    public async Task<IActionResult> Create(Region region) {
        if (Request.Form.Files.Count == 0) {
            ModelState.AddModelError(string.Empty, "No map image selected");
            return View();
        }
        if (region.Identifier.Length != 2) {
            ModelState.AddModelError(string.Empty, "Invalid value Identifier");
            return View();
        }
        await _regionService.CreateAsync(region);
        return RedirectToAction(nameof(Create));
    }

#region JsonResponsePagination

    public async Task<IActionResult> List(string pageNumber) {
        if (!int.TryParse(pageNumber, out var pageNumberInt)) pageNumberInt = 1;
        return View(await GetByChunk(pageNumberInt, 10));
    }

    [HttpPost]
    public async Task<IActionResult> JsonResponse(string pageNumber) {
        int.TryParse(pageNumber, out var pageNumberInt);
        var chunk = await GetByChunk(pageNumberInt, 10);
        var enumerable = chunk.Select(x => new {
            name = x.Name, identifier = x.Identifier, area = x.Area, formed = x.Formed.ToString("dd MMMM yyyy")
          , entertainmentCount = x.Entertainments.Count, monumentCount = x.Monuments.Count
        });
        return Json(enumerable);
    }

    public async Task<IReadOnlyCollection<Region>> GetByChunk(int pageNumber = 1, int pageSize = 1) {
        var chunk = await _regionService.GetPaginationAsync(pageNumber, pageSize);
        ViewData["ChunkCount"] = await _regionService.GetCountAsync() / pageSize + 1;
        return chunk;
    }

#endregion
}