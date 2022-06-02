using Domain.Models;

namespace BLL.Services.Interfaces;

public interface IInstitution<T> {
    Task<IReadOnlyCollection<Review>> GetAllReviewsAsync(int id);
    Task<IReadOnlyCollection<Image>> GetAllImages(int id);
}