using System.Linq.Expressions;
using BLL.Services.Interfaces;
using DLL.Repository;
using Domain.Models;

namespace BLL.Services;

public class EntertainmentService : IReceiving<Entertainment>, IInstitution<Entertainment> {
    private readonly EntertainmentRepository _entertainmentRepository;
    private readonly ReviewRepository _reviewRepository;
    public EntertainmentService(EntertainmentRepository entertainmentRepository, ReviewRepository reviewRepository) {
        _entertainmentRepository = entertainmentRepository;
        _reviewRepository = reviewRepository;
    }
    public virtual async Task<IReadOnlyCollection<Entertainment>>
        FindByConditionAsync(Expression<Func<Entertainment, bool>> predicate) =>
        await _entertainmentRepository.FindByConditionAsync(predicate);
    public async Task<IReadOnlyCollection<Entertainment>> GetAllAsync() => await _entertainmentRepository.GetAllAsync();
    public async Task<IReadOnlyCollection<Review>> GetAllReviewsAsync(int id) =>
        (await _entertainmentRepository.FindByConditionAsync(x => x.Id == id)).FirstOrDefault()!.Reviews;
    public async Task<IReadOnlyCollection<Image>> GetAllImages(int id) =>
        (await _entertainmentRepository.FindByConditionAsync(x => x.Id == id)).FirstOrDefault()!.Images;
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
}