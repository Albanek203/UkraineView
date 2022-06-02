using System.Linq.Expressions;
using BLL.Services.Interfaces;
using DLL.Repository;
using Domain.Models;

namespace BLL.Services;

public class MonumentService : IReceiving<Monument>, IInstitution<Monument> {
    private readonly MonumentRepository _monumentRepository;
    private readonly ReviewRepository _reviewRepository;
    public MonumentService(MonumentRepository monumentRepository, ReviewRepository reviewRepository) {
        _monumentRepository = monumentRepository;
        _reviewRepository = reviewRepository;
    }
    public virtual async Task<IReadOnlyCollection<Monument>> FindByConditionAsync(Expression<Func<Monument, bool>> predicate) =>
        await _monumentRepository.FindByConditionAsync(predicate);
    public async Task<IReadOnlyCollection<Monument>> GetAllAsync() => await _monumentRepository.GetAllAsync();
    public async Task<IReadOnlyCollection<Review>> GetAllReviewsAsync(int monumentId) =>
        (await _monumentRepository.FindByConditionAsync(x => x.Id == monumentId)).FirstOrDefault()!.Reviews;
    public async Task<IReadOnlyCollection<Image>> GetAllImages(int monumentId) =>
        (await _monumentRepository.FindByConditionAsync(x => x.Id == monumentId)).FirstOrDefault()!.Images;
    public async Task AddMonumentAsync(Monument monument) { await _monumentRepository.CreateAsync(monument); }
    public async Task AddReviewAsync(int monumentId, Review review) {
        var monument = (await _monumentRepository.FindByConditionAsync(x => x.Id == monumentId)).FirstOrDefault();
        monument?.Reviews.Add(review);
        review.Monument = monument;
        await _reviewRepository.CreateAsync(review);
    }
}