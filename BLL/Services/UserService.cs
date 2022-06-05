﻿namespace BLL.Services;

public class UserService : IReceiving<User> {
    private readonly UserRepository _userRepository;

    public UserService(UserRepository userRepository) { _userRepository = userRepository; }

    public async Task<IReadOnlyCollection<User>> GetAllAsync() => await _userRepository.GetAllAsync();

    public async Task<IReadOnlyCollection<User>> FindByConditionAsync(Expression<Func<User, bool>> predicate) =>
        await _userRepository.FindByConditionAsync(predicate);

    public async Task AddUserAsync(User user) { await _userRepository.CreateAsync(user); }
    public void RemoveUser(User user) { _userRepository.Remove(user); }

#region Update

    public async Task UpdatePhotoAsync(string userHash, string newPath) {
        await _userRepository.UpdatePhotoAsync(userHash, newPath);
    }

    public async Task UpdateNicknameAsync(string userHash, string newNickname) {
        await _userRepository.UpdateNicknameAsync(userHash, newNickname);
    }

#endregion
}