using Domain.Models;

namespace BLL.Services.Interfaces;

public interface IInstitution<T> {
    Task<IEnumerable<T>> GetAllAsync();
    Task<IEnumerable<Review>> GetAllReviewsAsync(int id);
    Task<IEnumerable<Image>> GetAllImages(int id);
}