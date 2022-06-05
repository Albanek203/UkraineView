namespace DLL.Repository;

public class RegionRepository : BaseRepository<Region> {
    public RegionRepository(UkraineContext context) : base(context) { }

    public override async Task<IReadOnlyCollection<Region>> GetAllAsync() =>
        await this.Entities.
            Include(x=>x.MapImage).
            Include(x=>x.Images).
            Include(x => x.Entertainments).ThenInclude(x => x.WorkTime).
            Include(x => x.Entertainments).ThenInclude(x => x.Address).
            Include(x => x.Entertainments).ThenInclude(x => x.Reviews).ThenInclude(x => x.Images).
            Include(x => x.Entertainments).ThenInclude(x => x.Images).
            Include(x => x.Entertainments).ThenInclude(x => x.Contact).
            Include(x => x.Entertainments).ThenInclude(x => x.About).

            Include(x => x.Monument).ThenInclude(x => x.WorkTime).
            Include(x => x.Monument).ThenInclude(x => x.Address).
            Include(x => x.Monument).ThenInclude(x => x.Reviews).ThenInclude(x => x.Images).
            Include(x => x.Monument).ThenInclude(x => x.Images).
            ToListAsync().ConfigureAwait(false);

    public override async Task<IReadOnlyCollection<Region>> FindByConditionAsync(Expression<Func<Region, bool>> predicate) =>
        await this.Entities.
            Include(x => x.Entertainments).ThenInclude(x => x.WorkTime).
            Include(x => x.Entertainments).ThenInclude(x => x.Address).
            Include(x => x.Entertainments).ThenInclude(x => x.Reviews).ThenInclude(x => x.Images).
            Include(x => x.Entertainments).ThenInclude(x => x.Images).
            Include(x => x.Entertainments).ThenInclude(x => x.Contact).
            Include(x => x.Entertainments).ThenInclude(x => x.About).

            Include(x => x.Monument).ThenInclude(x => x.WorkTime).
            Include(x => x.Monument).ThenInclude(x => x.Address).
            Include(x => x.Monument).ThenInclude(x => x.Reviews).ThenInclude(x => x.Images).
            Include(x => x.Monument).ThenInclude(x => x.Images).
            Where(predicate).ToListAsync().ConfigureAwait(false);
}