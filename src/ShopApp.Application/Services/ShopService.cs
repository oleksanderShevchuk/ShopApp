using ShopApp.Application.DTOs;
using ShopApp.Application.Interfaces;
using ShopApp.Application.Mappers;

namespace ShopApp.Application.Services
{
    public class ShopService : IShopService
    {
        private readonly IUnitOfWork _uow;

        public ShopService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<IEnumerable<ClientDto>> GetBirthdaysAsync(DateTime date)
        {
            var clients = await _uow.Clients.GetBirthdaysOnAsync(date);
            return ClientMapper.ToDto(clients);
        }

        public async Task<IEnumerable<ClientWithLastPurchaseDto>> GetRecentCustomersAsync(int days)
        {
            return await _uow.Clients.GetClientsWithPurchasesInLastDaysAsync(days);
        }

        public async Task<IEnumerable<CategoryCountDto>> GetCustomerCategoriesAsync(Guid clientId)
        {
            var categories = await _uow.Purchases.GetCategoriesByClientAsync(clientId);
            return CategoryCountMapper.ToDto(categories);
        }
    }
}
