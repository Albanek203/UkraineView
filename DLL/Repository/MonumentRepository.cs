using System.Linq.Expressions;
using DLL.Context;
using DLL.Repository.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DLL.Repository;

public class MonumentRepository : BaseRepository<Monument> {
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
}