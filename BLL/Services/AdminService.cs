namespace BLL.Services;

public class AdminService {
    private readonly MonumentRepository _monumentRepository;
    private readonly EntertainmentRepository _entertainmentRepository;
    private readonly UserRepository _userRepository;

    public AdminService(MonumentRepository monumentRepository
                      , EntertainmentRepository entertainmentRepository
                      , UserRepository userRepository) {
        _monumentRepository = monumentRepository;
        _entertainmentRepository = entertainmentRepository;
        _userRepository = userRepository;
    }

    public async Task<IReadOnlyCollection<Entertainment>> GetOwnEntertainmentsAsync(string userHash) =>
        await _userRepository.GetEntertainmentsByUserAsync(userHash);
}