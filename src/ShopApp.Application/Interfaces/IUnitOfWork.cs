namespace ShopApp.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IClientRepository Clients { get; }
        IPurchaseRepository Purchases { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
