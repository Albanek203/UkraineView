using BLL.Services.Interfaces;
using DLL.Repository;
using Domain.Models;

namespace BLL.Services;

public class MonumentService : IInstitution<Monument> {
    private readonly MonumentRepository _monumentRepository;
    private readonly ReviewRepository _reviewRepository;

    public MonumentService(MonumentRepository monumentRepository, ReviewRepository reviewRepository) {
        _monumentRepository = monumentRepository;
        _reviewRepository = reviewRepository;
    }

    public async Task<IEnumerable<Monument>> GetAllAsync() => await _monumentRepository.GetAllAsync();
    public async Task<IEnumerable<Review>> GetAllReviewsAsync(int id) =>
        (await _monumentRepository.FindByConditionAsync(x => x.Id == id)).FirstOrDefault()!.Reviews;
    public async Task<IEnumerable<Image>> GetAllImages(int id) =>
        (await _monumentRepository.FindByConditionAsync(x => x.Id == id)).FirstOrDefault()!.Images;

    public async Task AddUserAsync(Monument monument) { await _monumentRepository.CreateAsync(monument); }
    public async Task AddReviewAsync(int monumentId, Review review) {
        var monument = (await _monumentRepository.FindByConditionAsync(x => x.Id == monumentId)).FirstOrDefault();
        monument?.Reviews.Add(review);
        review.Monument = monument;
        await _reviewRepository.CreateAsync(review);
    }
}
