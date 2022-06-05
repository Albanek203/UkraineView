namespace BLL.Services.Interfaces;

public interface IReceiving<T> {
    Task<IReadOnlyCollection<T>> GetAllAsync();
    Task<IReadOnlyCollection<T>> FindByConditionAsync(Expression<Func<T, bool>> predicate);
}