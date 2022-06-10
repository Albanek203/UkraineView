namespace DLL.Repository.Interfaces;

public interface IPagination<TData> where TData : class {
    Task<int> GetCountAsync();
    Task<IReadOnlyCollection<TData>> GetPaginationAsync(int pageNumber = 1, int pageSize = 1);
}