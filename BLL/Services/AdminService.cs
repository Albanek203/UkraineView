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

    public async Task<int> GetEntertainmentsByUserCountAsync(string userHash) =>
        await _userRepository.GetEntertainmentsByUserCountAsync(userHash);

    public async Task<IReadOnlyCollection<Entertainment>>
        GetPaginationEntertainmentsByUserAsync(string userHash, int pageNumber, int pageSize) =>
        await _userRepository.GetPaginationEntertainmentsByUserAsync(userHash, pageNumber, pageSize);

    public async Task AddEntertainmentToUser(string userHash, Entertainment entertainment) { await _userRepository.AddEntertainmentToUser(userHash, entertainment); }
}