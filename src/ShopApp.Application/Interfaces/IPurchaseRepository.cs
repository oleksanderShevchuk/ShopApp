using ShopApp.Domain.Entities;

namespace ShopApp.Application.Interfaces
{
    public interface IPurchaseRepository : IRepository<Purchase>
    {
        Task<IEnumerable<(string Category, int Quantity)>> GetCategoriesByClientAsync(Guid clientId);
    }
}
