namespace DLL.Repository;

public class UserRepository : BaseRepository<User> {
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
            return new OperationDetail {
                Message = "Update user photo", IsCompleted = true
            };
        } catch (Exception exception) {
            Log.Error(exception, "Update user photo");
            return new OperationDetail {
                Message = "Update user photo", IsCompleted = false
            };
        }
    }

    public async Task<OperationDetail> UpdateNicknameAsync(string userHash, string newNickname) {
        try {
            var model = await this.Entities.FirstOrDefaultAsync(x => x.Id == userHash);
            ArgumentNullException.ThrowIfNull(model);
            model.UserName = newNickname;
            this.Entities.Update(model);
            await _context.SaveChangesAsync();
            return new OperationDetail {
                Message = "Update user nickname", IsCompleted = true
            };
        } catch (Exception exception) {
            Log.Error(exception, "Update user nickname");
            return new OperationDetail {
                Message = "Update user nickname", IsCompleted = false
            };
        }
    }

#endregion

    public OperationDetail Remove(User user) {
        try {
            this.Entities.Remove(user);
            return new OperationDetail {
                Message = "Remove user", IsCompleted = true
            };
        } catch (Exception exception) {
            Log.Error(exception, "Remove user");
            return new OperationDetail {
                Message = "Remove user", IsCompleted = false
            };
        }
    }

    public async Task<IReadOnlyCollection<Entertainment>> GetEntertainmentsAsync(string userHash) =>
        (await this.Entities.FirstOrDefaultAsync(x => x.Id == userHash))?.Entertainments!;
}