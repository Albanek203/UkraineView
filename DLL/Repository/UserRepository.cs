﻿namespace DLL.Repository;

public class UserRepository : BaseRepository<User>, IPagination<User> {
    public UserRepository(UkraineContext context) : base(context) { }

    public override async Task<IReadOnlyCollection<User>> GetAllAsync() =>
        await this.Entities.Include(x => x.Image).ToListAsync().ConfigureAwait(false);

    public override async Task<IReadOnlyCollection<User>>
        FindByConditionAsync(Expression<Func<User, bool>> predicate) =>
        await this.Entities.Include(x => x.Image).Where(predicate).ToListAsync().ConfigureAwait(false);

#region Update

    public async Task<OperationDetail> UpdatePhotoAsync(string userHash, string newPath) {
        try {
            var model = await this.Entities.FirstOrDefaultAsync(x => x.Id == userHash);
            ArgumentNullException.ThrowIfNull(model);
            model.Image = new Image { Path = newPath };
            this.Entities.Update(model);
            await _context.SaveChangesAsync();
            return new OperationDetail("Update user photo", true);
        } catch (Exception exception) {
            Log.Error(exception, "Update user photo");
            return new OperationDetail("Update user photo", false);
        }
    }

    public async Task<OperationDetail> UpdateNicknameAsync(string userHash, string newNickname) {
        try {
            var model = await this.Entities.FirstOrDefaultAsync(x => x.Id == userHash);
            ArgumentNullException.ThrowIfNull(model);
            model.UserName = newNickname;
            this.Entities.Update(model);
            await _context.SaveChangesAsync();
            return new OperationDetail("Update user nickname", true);
        } catch (Exception exception) {
            Log.Error(exception, "Update user nickname");
            return new OperationDetail("Update user nickname", false);
        }
    }

#endregion

    public OperationDetail Remove(User user) {
        try {
            this.Entities.Remove(user);
            _context.SaveChangesAsync();
            return new OperationDetail("Remove user", true);
        } catch (Exception exception) {
            Log.Error(exception, "Remove user");
            return new OperationDetail("Remove user", false);
        }
    }

    public async Task<IReadOnlyCollection<Entertainment>> GetEntertainmentsByUserAsync(string userHash) =>
        (await this.Entities.FirstOrDefaultAsync(x => x.Id == userHash))?.Entertainments!;

    public async Task<int> GetCountAsync() => await this.Entities.AsNoTracking().CountAsync();

    public async Task<IReadOnlyCollection<User>> GetPaginationAsync(int pageNumber, int pageSize) {
        var excludeRecord = pageNumber * pageSize - pageSize;
        return await this.Entities.AsNoTracking().Skip(excludeRecord).Take(pageSize).ToListAsync();
    }
}