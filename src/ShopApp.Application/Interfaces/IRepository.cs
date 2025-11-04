namespace ShopApp.Application.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T?> GetAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        void Update(T entity);
        void Remove(T entity);
        IQueryable<T> Query(); // for custom queries
    }
}
