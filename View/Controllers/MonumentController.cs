namespace View.Controllers;

[Authorize(Roles = "Administrator")]
public class MonumentController : Controller, IJsonResponsePagination<Monument> {
    private readonly MonumentService _monumentService;
    private readonly RegionService _regionService;

    public MonumentController(MonumentService monumentService, RegionService regionService) {
        _monumentService = monumentService;
        _regionService = regionService;
    }

    public async Task<IActionResult> Create() {
        ViewData["listRegionName"] = await _regionService.GetOnlyNameListAsync();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Monument monument, string cityName) {
        var region = (await _regionService.FindByConditionAsync(x => x.Name == cityName)).FirstOrDefault()!;
        monument.Address.Region = region;
        await _monumentService.CreateAsync(monument);
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
            name = x.Name, region = x.Address.Region.Name, city = x.Address.City, street = x.Address.Street
          , rating = x.Rating
        });
        return Json(enumerable);
    }

    public async Task<IReadOnlyCollection<Monument>> GetByChunk(int pageNumber = 1, int pageSize = 1) {
        var chunk = await _monumentService.GetPaginationAsync(pageNumber, pageSize);
        ViewData["ChunkCount"] = await _monumentService.GetCountAsync() / pageSize + 1;
        return chunk;
    }

#endregion
}