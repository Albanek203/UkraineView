namespace BLL.Services;

public class UserService : IReceiving<User> {
    private readonly UserRepository _userRepository;

    public UserService(UserRepository userRepository) { _userRepository = userRepository; }
    public async Task CreateAsync(User user) { await _userRepository.CreateAsync(user); }

    public async Task<IReadOnlyCollection<User>> GetAllAsync() => await _userRepository.GetAllAsync();

    public async Task<IReadOnlyCollection<User>> FindByConditionAsync(Expression<Func<User, bool>> predicate) =>
        await _userRepository.FindByConditionAsync(predicate);

#region Pagination

    public async Task<int> GetCountAsync() => await _userRepository.GetCountAsync();

    public async Task<IReadOnlyCollection<User>> GetPaginationAsync(int pageNumber = 1, int pageSize = 1) =>
        await _userRepository.GetPaginationAsync(pageNumber, pageSize);

#endregion

#region Update

    public async Task UpdatePhotoAsync(string userHash, string newPath) {
        await _userRepository.UpdatePhotoAsync(userHash, newPath);
    }

    public async Task UpdateNicknameAsync(string userHash, string newNickname) {
        await _userRepository.UpdateNicknameAsync(userHash, newNickname);
    }

#endregion

    public void RemoveUser(User user) { _userRepository.Remove(user); }
}