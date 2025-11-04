using ShopApp.Domain.Entities;

namespace ShopApp.Application.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<string>> GetCategoriesByClientIdAsync(int clientId);
    }
}
