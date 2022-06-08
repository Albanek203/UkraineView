namespace DLL.Repository.Interfaces;

public interface IPagination<TData> where TData : class {
    Task<int> GetCountAsync();
    Task<IReadOnlyCollection<TData>> GetPagination(int pageNumber, int pageSize);
}