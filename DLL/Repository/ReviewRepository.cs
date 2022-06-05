namespace DLL.Repository;

public class ReviewRepository : BaseRepository<Review> {
    public ReviewRepository(UkraineContext context) : base(context) { }
    public override async Task<IReadOnlyCollection<Review>> GetAllAsync() =>
        await this.Entities.
            Include(x => x.PublishTime).
            Include(x => x.Images).
            Include(x => x.Entertainment).
            Include(x => x.Monument).
            ToListAsync().ConfigureAwait(false);

    public override async Task<IReadOnlyCollection<Review>> FindByConditionAsync(Expression<Func<Review, bool>> predicate) =>
        await this.Entities.
            Include(x => x.PublishTime).
            Include(x => x.Images).
            Include(x => x.Entertainment).
            Include(x => x.Monument).
            Where(predicate).ToListAsync().ConfigureAwait(false);
}