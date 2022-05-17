using System.Linq.Expressions;
using DLL.Context;
using DLL.Repository.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DLL.Repository;

public class CityRepository : BaseRepository<City> {
    public CityRepository(UkraineContext context) : base(context) { }

    public override async Task<IReadOnlyCollection<City>> GetAllAsync() =>
        await this.Entities.
            Include(x => x.Entertainment).ThenInclude(x => x.WorkTime).
            Include(x => x.Entertainment).ThenInclude(x => x.Address).
            Include(x => x.Entertainment).ThenInclude(x => x.Reviews).ThenInclude(x => x.Images).
            Include(x => x.Entertainment).ThenInclude(x => x.Images).
            Include(x => x.Entertainment).ThenInclude(x => x.Contact).
            Include(x => x.Entertainment).ThenInclude(x => x.About).

            Include(x => x.Monument).ThenInclude(x => x.WorkTime).
            Include(x => x.Monument).ThenInclude(x => x.Address).
            Include(x => x.Monument).ThenInclude(x => x.Reviews).ThenInclude(x => x.Images).
            Include(x => x.Monument).ThenInclude(x => x.Images).
            ToListAsync().ConfigureAwait(false);

    public override async Task<IReadOnlyCollection<City>> FindByConditionAsync(Expression<Func<City, bool>> predicate) =>
        await this.Entities.
            Include(x => x.Entertainment).ThenInclude(x => x.WorkTime).
            Include(x => x.Entertainment).ThenInclude(x => x.Address).
            Include(x => x.Entertainment).ThenInclude(x => x.Reviews).ThenInclude(x => x.Images).
            Include(x => x.Entertainment).ThenInclude(x => x.Images).
            Include(x => x.Entertainment).ThenInclude(x => x.Contact).
            Include(x => x.Entertainment).ThenInclude(x => x.About).

            Include(x => x.Monument).ThenInclude(x => x.WorkTime).
            Include(x => x.Monument).ThenInclude(x => x.Address).
            Include(x => x.Monument).ThenInclude(x => x.Reviews).ThenInclude(x => x.Images).
            Include(x => x.Monument).ThenInclude(x => x.Images).
            Where(predicate).ToListAsync().ConfigureAwait(false);
}