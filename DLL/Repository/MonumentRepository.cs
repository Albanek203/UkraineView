namespace DLL.Repository;

public class MonumentRepository : BaseRepository<Monument>, IPagination<Monument> {
    public MonumentRepository(UkraineContext context) : base(context) { }

    public override async Task<IReadOnlyCollection<Monument>> GetAllAsync() =>
        await this.Entities.
            Include(x => x.WorkTime).
            Include(x => x.Address).
            Include(x => x.Reviews).ThenInclude(x => x.Images).
            Include(x => x.Images).
            ToListAsync().ConfigureAwait(false);

    public override async Task<IReadOnlyCollection<Monument>> FindByConditionAsync(Expression<Func<Monument, bool>> predicate) =>
        await this.Entities.
            Include(x => x.WorkTime).
            Include(x => x.Address).
            Include(x => x.Reviews).ThenInclude(x => x.Images).
            Include(x => x.Images).
            Where(predicate).ToListAsync().ConfigureAwait(false);

    public async Task<OperationDetail> UpdateNameAsync(int id, string newName) {
        try {
            var monument = await this.Entities.FirstOrDefaultAsync(x => x.Id == id);
            ArgumentNullException.ThrowIfNull(monument);
            monument.Name = newName;
            this.Entities.Update(monument);
            await _context.SaveChangesAsync();
            return new OperationDetail {
                Message = "Update monument name", IsCompleted = true
            };
        } catch (Exception exception) {
            Log.Error(exception, "Update monument name");
            return new OperationDetail {
                Message = "Update monument name", IsCompleted = false
            };
        }
    }

    public async Task<IReadOnlyCollection<Review>> GetAllReviewsAsync(int monumentId) =>
        (await this.Entities.FirstOrDefaultAsync(x => x.Id == monumentId))?.Reviews!;

    public async Task<int> GetCountAsync() => await this.Entities.AsNoTracking().CountAsync();

    public async Task<IReadOnlyCollection<Monument>> GetPagination(int pageNumber, int pageSize) {
        var excludeRecord = pageNumber * pageSize - pageSize;
        return await this.Entities.AsNoTracking().Skip(excludeRecord).Take(pageSize).ToListAsync();
    }
}