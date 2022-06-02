using System.Linq.Expressions;
using DLL.Context;
using DLL.Models;
using DLL.Repository.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;

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

    public async Task<OperationDetail> UpdateNameAsync(int id, string newName) {
        try {
            var monument = this.Entities.FirstOrDefault(x => x.Id == id);
            monument!.Name = newName;
            this.Entities.Update(monument);
            await _context.SaveChangesAsync();
            return new OperationDetail {
                Message = "Update monument name",
                IsCompleted = true
            };
        }
        catch (Exception exception) {
            Log.Error(exception, "Create Fatal Exception");
            return new OperationDetail {
                Message = "Update monument name",
                IsCompleted = false
            };
        }
    }
    public async Task<OperationDetail> UpdateWorkTimeAsync(int id, string newName) {
        try {
            var monument = this.Entities.FirstOrDefault(x => x.Id == id);
            monument!.Name = newName;
            this.Entities.Update(monument);
            await _context.SaveChangesAsync();
            return new OperationDetail {
                Message = "Update monument name",
                IsCompleted = true
            };
        }
        catch (Exception exception) {
            Log.Error(exception, "Create Fatal Exception");
            return new OperationDetail {
                Message = "Update monument name",
                IsCompleted = false
            };
        }
    }
}