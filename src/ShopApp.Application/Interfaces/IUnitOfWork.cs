namespace ShopApp.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IClientRepository Clients { get; }
        IProductRepository Products { get; }
        IPurchaseRepository Purchases { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
