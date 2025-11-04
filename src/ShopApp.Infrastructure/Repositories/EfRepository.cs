using Microsoft.EntityFrameworkCore;
using ShopApp.Application.Interfaces;
using ShopApp.Infrastructure.Persistence;

namespace ShopApp.Infrastructure.Repositories
{
    public class EfRepository<T> : IRepository<T> where T : class
    {
        protected readonly ShopDbContext _db;
        protected readonly DbSet<T> _set;
        public EfRepository(ShopDbContext db) { _db = db; _set = db.Set<T>(); }
        public async Task AddAsync(T entity) => await _set.AddAsync(entity);
        public async Task<T?> GetAsync(Guid id) => await _set.FindAsync(id);
        public async Task<IEnumerable<T>> GetAllAsync() => await _set.ToListAsync();
        public void Update(T entity) => _set.Update(entity);
        public void Remove(T entity) => _set.Remove(entity);
        public IQueryable<T> Query() => _set.AsQueryable();
    }
}
