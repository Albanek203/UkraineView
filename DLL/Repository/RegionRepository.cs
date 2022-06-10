namespace DLL.Repository;

public class RegionRepository : BaseRepository<Region>, IPagination<Region> {
    public RegionRepository(UkraineContext context) : base(context) { }

    public override async Task<IReadOnlyCollection<Region>> GetAllAsync() =>
        await this.Entities.Include(x => x.MapImage).Include(x => x.MapImage).Include(x => x.Images)
                  .Include(x => x.Entertainments).ThenInclude(x => x.WorkTime).Include(x => x.Entertainments)
                  .ThenInclude(x => x.Address).Include(x => x.Entertainments).ThenInclude(x => x.Reviews)
                  .ThenInclude(x => x.Images).Include(x => x.Entertainments).ThenInclude(x => x.Images)
                  .Include(x => x.Entertainments).ThenInclude(x => x.Contact).Include(x => x.Entertainments)
                  .ThenInclude(x => x.About).Include(x => x.Monuments).ThenInclude(x => x.WorkTime)
                  .Include(x => x.Monuments).ThenInclude(x => x.Address).Include(x => x.Monuments)
                  .ThenInclude(x => x.Reviews).ThenInclude(x => x.Images).Include(x => x.Monuments)
                  .ThenInclude(x => x.Images).ToListAsync().ConfigureAwait(false);

    public override async Task<IReadOnlyCollection<Region>>
        FindByConditionAsync(Expression<Func<Region, bool>> predicate) =>
        await this.Entities.Include(x => x.MapImage).Include(x => x.Entertainments).ThenInclude(x => x.WorkTime)
                  .Include(x => x.Entertainments).ThenInclude(x => x.Address).Include(x => x.Entertainments)
                  .ThenInclude(x => x.Reviews).ThenInclude(x => x.Images).Include(x => x.Entertainments)
                  .ThenInclude(x => x.Images).Include(x => x.Entertainments).ThenInclude(x => x.Contact)
                  .Include(x => x.Entertainments).ThenInclude(x => x.About).Include(x => x.Monuments)
                  .ThenInclude(x => x.WorkTime).Include(x => x.Monuments).ThenInclude(x => x.Address)
                  .Include(x => x.Monuments).ThenInclude(x => x.Reviews).ThenInclude(x => x.Images)
                  .Include(x => x.Monuments).ThenInclude(x => x.Images).Where(predicate).ToListAsync()
                  .ConfigureAwait(false);

    public async Task<IReadOnlyCollection<string>> GetOnlyNameListAsync() =>
        await this.Entities.Select(x => x.Name).ToListAsync();

    public async Task<int> GetCountAsync() => await this.Entities.AsNoTracking().CountAsync();

    public async Task<IReadOnlyCollection<Region>> GetPagination(int pageNumber, int pageSize) {
        var excludeRecord = pageNumber * pageSize - pageSize;
        return await this.Entities.AsNoTracking().Skip(excludeRecord).Take(pageSize).ToListAsync();
    }
}