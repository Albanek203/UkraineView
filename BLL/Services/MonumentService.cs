namespace BLL.Services;

public class MonumentService : IReceiving<Monument> {
    private readonly MonumentRepository _monumentRepository;
    private readonly ReviewRepository _reviewRepository;

    public MonumentService(MonumentRepository monumentRepository, ReviewRepository reviewRepository) {
        _monumentRepository = monumentRepository;
        _reviewRepository = reviewRepository;
    }

    public async Task CreateAsync(Monument monument) { await _monumentRepository.CreateAsync(monument); }

    public async Task<IReadOnlyCollection<Monument>> GetAllAsync() => await _monumentRepository.GetAllAsync();

    public async Task<IReadOnlyCollection<Monument>> FindByConditionAsync(Expression<Func<Monument, bool>> predicate) =>
        await _monumentRepository.FindByConditionAsync(predicate);

#region Pagination

    public async Task<int> GetCountAsync() => await _monumentRepository.GetCountAsync();

    public async Task<IReadOnlyCollection<Monument>> GetPaginationAsync(int pageNumber = 1, int pageSize = 1) =>
        await _monumentRepository.GetPaginationAsync(pageNumber, pageSize);

#endregion
    
    public async Task AddReviewAsync(int monumentId, Review review) {
        var monument = (await _monumentRepository.FindByConditionAsync(x => x.Id == monumentId)).FirstOrDefault();
        monument?.Reviews.Add(review);
        review.Monument = monument;
        await _reviewRepository.CreateAsync(review);
    }
}