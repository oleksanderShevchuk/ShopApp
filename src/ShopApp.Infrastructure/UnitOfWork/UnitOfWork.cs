using ShopApp.Application.Interfaces;
using ShopApp.Infrastructure.Persistence;

namespace ShopApp.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ShopDbContext _db;
        public IClientRepository Clients { get; }
        public IPurchaseRepository Purchases { get; }

        public UnitOfWork(ShopDbContext db,
            IClientRepository clients,
            IPurchaseRepository purchases)
        {
            _db = db;
            Clients = clients;
            Purchases = purchases;
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
            => _db.SaveChangesAsync(cancellationToken);

        public void Dispose() => _db.Dispose();
    }
}
