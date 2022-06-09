namespace BLL.Services;

public class RegionService : IReceiving<Region> {
    private readonly RegionRepository _regionRepository;
    public RegionService(RegionRepository regionRepository) { _regionRepository = regionRepository; }
    public async Task<IReadOnlyCollection<Region>> GetAllAsync() => await _regionRepository.GetAllAsync();
    public async Task<IReadOnlyCollection<Region>> FindByConditionAsync(Expression<Func<Region, bool>> predicate) =>
        await _regionRepository.FindByConditionAsync(predicate);

    public async Task CreateRegionAsync(Region region) => await _regionRepository.CreateAsync(region);

    public async Task<IReadOnlyCollection<string>> GetOnlyNameListAsync() => await _regionRepository.GetOnlyNameListAsync();
    
    public async Task<int> GetRegionCountAsync() => await _regionRepository.GetCountAsync();

    public async Task<IReadOnlyCollection<Region>> GetRegionPaginationAsync(int pageNumber = 1, int pageSize = 1) =>
        await _regionRepository.GetPagination(pageNumber, pageSize);
}