namespace Api.Infrastructure.Persistence.Repositories
{
    public interface IRepository<T> where T: class
    {
        Task<T> GetByIdAsync(long id);
        Task<IEnumerable<T>> GetAsync();
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(long id);
    }
}
