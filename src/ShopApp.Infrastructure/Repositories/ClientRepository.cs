using Microsoft.EntityFrameworkCore;
using ShopApp.Application.DTOs;
using ShopApp.Application.Interfaces;
using ShopApp.Domain.Entities;
using ShopApp.Infrastructure.Persistence;

namespace ShopApp.Infrastructure.Repositories
{
    public class ClientRepository : EfRepository<Client>, IClientRepository
    {
        public ClientRepository(ShopDbContext db) : base(db) { }

        public async Task<IEnumerable<Client>> GetBirthdaysOnAsync(DateTime date)
        {
            int m = date.Month, d = date.Day;
            return await _db.Clients
                .Where(c => c.BirthDate.Month == m && c.BirthDate.Day == d)
                .ToListAsync();
        }

        public async Task<IEnumerable<ClientWithLastPurchaseDto>> GetClientsWithPurchasesInLastDaysAsync(int days)
        {
            var from = DateTime.UtcNow.Date.AddDays(-days);

            var clients = await _db.Clients
                .Where(c => c.Purchases.Any(p => p.Date >= from))
                .Select(c => new ClientWithLastPurchaseDto
                {
                    Id = c.Id,
                    FullName = c.FullName,
                    LastPurchaseDate = c.Purchases
                                           .Where(p => p.Date >= from)
                                           .Max(p => p.Date)
                })
                .ToListAsync();

            return clients;
        }
    }
}
