using DLL.Repository;
using Domain.Models;

namespace BLL.Services;

public class UserService {
    private readonly UserRepository _userRepository;
    public UserService(UserRepository userRepository) { _userRepository = userRepository; }

    public async Task AddUserAsync(User user) { await _userRepository.CreateAsync(user); }
    public void RemoveUser(User user) { _userRepository.Remove(user); }
    public async Task UpdatePhotoAsync(User user, string newPath) {
        await _userRepository.UpdatePhotoAsync(x => x.Id == user.Id, newPath);
    }
    public async Task UpdateNicknameAsync(User user, string newNickname) {
        await _userRepository.UpdateNicknameAsync(x => x.Id == user.Id, newNickname);
    }
}