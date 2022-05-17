using System.Linq.Expressions;
using DLL.Context;
using DLL.Models;
using DLL.Repository.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace DLL.Repository;

public class UserRepository : BaseRepository<User> {
    public UserRepository(UkraineContext context) : base(context) { }

    public override async Task<IReadOnlyCollection<User>> GetAllAsync() =>
        await this.Entities.
            Include(x => x.Image).
            ToListAsync().ConfigureAwait(false);

    public override async Task<IReadOnlyCollection<User>> FindByConditionAsync(Expression<Func<User, bool>> predicate) =>
        await this.Entities.
            Include(x => x.Image).
            Where(predicate).ToListAsync().ConfigureAwait(false);

    public async Task<OperationDetail> UpdatePhotoAsync(Expression<Func<User, bool>> predicate, string newPath) {
        try {
            var model = await Entities.Where(predicate).FirstAsync();
            model.Image = new Image { Path = newPath };
            this.Entities.Update(model);
            await _context.SaveChangesAsync();
            return new OperationDetail {
                Message = "Update user photo",
                IsCompleted = true
            };
        }
        catch (Exception exception) {
            Log.Error(exception, "Create Fatal Exception");
            return new OperationDetail {
                Message = "Update user photo",
                IsCompleted = false
            };
        }
    }  
    
    public async Task<OperationDetail> UpdateNicknameAsync(Expression<Func<User, bool>> predicate, string newNickname) {
        try {
            var model = await Entities.Where(predicate).FirstAsync();
            model.Nickname = newNickname;
            this.Entities.Update(model);
            await _context.SaveChangesAsync();
            return new OperationDetail {
                Message = "Update user nickname",
                IsCompleted = true
            };
        }
        catch (Exception exception) {
            Log.Error(exception, "Create Fatal Exception");
            return new OperationDetail {
                Message = "Update user nickname",
                IsCompleted = false
            };
        }
    }

    public void Remove(User user) { this.Entities.Remove(user); }
}