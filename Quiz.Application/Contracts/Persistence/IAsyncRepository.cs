

namespace Quiz.Application.Contracts.Persistence
{
    public interface IAsyncRepository<T> where T: class
    {
        Task<T?> GetByIDAsync(int id);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        Task DeleteAsync(T entity);
        Task UpdateAsync(T entity);
        Task<IReadOnlyList<T>>GetPagedRespanseAsync(int pageIndex, int pageSize);
    }
}
