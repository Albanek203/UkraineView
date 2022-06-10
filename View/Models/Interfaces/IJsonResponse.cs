namespace View.Models.Interfaces;

public interface IJsonResponsePagination<T> {
    Task<IActionResult> List(string pageNumber);
    Task<IActionResult> JsonResponse(string pageNumber);
    Task<IReadOnlyCollection<T>> GetByChunk(int pageNumber = 1, int pageSize = 1);
}