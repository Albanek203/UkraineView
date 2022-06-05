namespace BLL.Services;

public class RegionService : IReceiving<Region> {
    private readonly RegionRepository _regionRepository;
    public RegionService(RegionRepository regionRepository) { _regionRepository = regionRepository; }
    public async Task<IReadOnlyCollection<Region>> GetAllAsync() => await _regionRepository.GetAllAsync();
    public async Task<IReadOnlyCollection<Region>> FindByConditionAsync(Expression<Func<Region, bool>> predicate) =>
        await _regionRepository.FindByConditionAsync(predicate);
}