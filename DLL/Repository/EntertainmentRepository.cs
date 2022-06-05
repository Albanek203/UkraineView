namespace DLL.Repository;

public class EntertainmentRepository : BaseRepository<Entertainment> {
    public EntertainmentRepository(UkraineContext context) : base(context) { }

    public override async Task<IReadOnlyCollection<Entertainment>> GetAllAsync() =>
        await this.Entities.
            Include(x => x.WorkTime).
            Include(x => x.Address).
            Include(x => x.Reviews).ThenInclude(x => x.Images).
            Include(x => x.Images).
            Include(x => x.Contact).
            Include(x => x.About).
            ToListAsync().ConfigureAwait(false);

    public override async Task<IReadOnlyCollection<Entertainment>> FindByConditionAsync(Expression<Func<Entertainment, bool>> predicate) =>
        await this.Entities.
            Include(x => x.WorkTime).
            Include(x => x.Address).
            Include(x => x.Reviews).ThenInclude(x => x.Images).
            Include(x => x.Images).
            Include(x => x.Contact).
            Include(x => x.About).
            Where(predicate).ToListAsync().ConfigureAwait(false);
}