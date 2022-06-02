using System.Linq.Expressions;
using BLL.Services.Interfaces;
using DLL.Repository;
using Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace BLL.Services;

public class UserService : IReceiving<User> {
    private readonly UserRepository _userRepository;

    public UserService(UserRepository userRepository) { _userRepository = userRepository; }

    public async Task<IReadOnlyCollection<User>> GetAllAsync() => await _userRepository.GetAllAsync();

    public async Task<IReadOnlyCollection<User>> FindByConditionAsync(Expression<Func<User, bool>> predicate) =>
        await _userRepository.FindByConditionAsync(predicate);

    public async Task AddUserAsync(User user) { await _userRepository.CreateAsync(user); }
    public void RemoveUser(User user) { _userRepository.Remove(user); }

    public async Task UpdatePhotoAsync(User user, string newPath) {
        await _userRepository.UpdatePhotoAsync(x => x.Id == user.Id, newPath);
    }

    public async Task UpdateNicknameAsync(User user, string newNickname) { }
}