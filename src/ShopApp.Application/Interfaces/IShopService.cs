using ShopApp.Application.DTOs;

namespace ShopApp.Application.Interfaces
{
    public interface IShopService
    {
        Task<IEnumerable<ClientDto>> GetBirthdaysAsync(DateTime date);
        Task<IEnumerable<ClientWithLastPurchaseDto>> GetRecentCustomersAsync(int days);
        Task<IEnumerable<CategoryCountDto>> GetCustomerCategoriesAsync(Guid clientId);
    }
}
