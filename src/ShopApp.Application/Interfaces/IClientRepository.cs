using ShopApp.Domain.Entities;

namespace ShopApp.Application.Interfaces
{
    public interface IClientRepository : IRepository<Client>
    {
        Task<IEnumerable<Client>> GetBirthdaysOnAsync(DateTime date);
        Task<IEnumerable<(Client client, DateTime lastPurchase)>> GetClientsWithPurchasesInLastDaysAsync(int days);
    }
}
