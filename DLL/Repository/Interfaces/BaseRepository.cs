using System.Linq.Expressions;
using DLL.Context;
using DLL.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace DLL.Repository.Interfaces;

public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class {
    public BaseRepository(UkraineContext context) { this._context = context; }

    protected readonly UkraineContext _context;
    private DbSet<TEntity> _entities;
    protected DbSet<TEntity> Entities => this._entities ??= _context.Set<TEntity>();
    public virtual async Task<IReadOnlyCollection<TEntity>> GetAllAsync() => await this.Entities.ToListAsync().ConfigureAwait(false);
    public virtual async Task<IReadOnlyCollection<TEntity>> FindByConditionAsync(Expression<Func<TEntity, bool>> predicate) =>
        await this.Entities.Where(predicate).ToListAsync().ConfigureAwait(false);

    public async Task<OperationDetail> CreateAsync(TEntity entity) {
        try {
            await Entities.AddAsync(entity).ConfigureAwait(false);
            return new OperationDetail {
                Message = "Create",
                IsCompleted = true
            };
        }
        catch (Exception exception) {
            Log.Error(exception, "Create Fatal Exception");
            return new OperationDetail {
                Message = "Create",
                IsCompleted = false
            };
        }
    }
}