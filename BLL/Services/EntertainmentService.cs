namespace BLL.Services;

public class EntertainmentService : IReceiving<Entertainment> {
    private readonly EntertainmentRepository _entertainmentRepository;
    private readonly ReviewRepository _reviewRepository;

    public EntertainmentService(EntertainmentRepository entertainmentRepository, ReviewRepository reviewRepository) {
        _entertainmentRepository = entertainmentRepository;
        _reviewRepository = reviewRepository;
    }

    public async Task<IReadOnlyCollection<Entertainment>>
        FindByConditionAsync(Expression<Func<Entertainment, bool>> predicate) =>
        await _entertainmentRepository.FindByConditionAsync(predicate);

    public async Task<IReadOnlyCollection<Entertainment>> GetAllAsync() => await _entertainmentRepository.GetAllAsync();

    public async Task AddEntertainmentAsync(Entertainment entertainment) {
        await _entertainmentRepository.CreateAsync(entertainment);
    }

    public async Task AddReviewAsync(int entertainmentId, Review review) {
        var entertainment = (await _entertainmentRepository.FindByConditionAsync(x => x.Id == entertainmentId))
           .FirstOrDefault();
        entertainment?.Reviews.Add(review);
        review.Entertainment = entertainment;
        await _reviewRepository.CreateAsync(review);
    }
    
    public async Task<int> GetEntertainmentCountAsync() => await _entertainmentRepository.GetCountAsync();

    public async Task<IReadOnlyCollection<Entertainment>> GetEntertainmentPagination(int pageNumber = 1, int pageSize = 1) =>
        await _entertainmentRepository.GetPagination(pageNumber, pageSize);
}