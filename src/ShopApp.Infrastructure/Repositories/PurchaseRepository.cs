using Microsoft.EntityFrameworkCore;
using ShopApp.Application.Interfaces;
using ShopApp.Domain.Entities;
using ShopApp.Infrastructure.Persistence;

namespace ShopApp.Infrastructure.Repositories
{
    public class PurchaseRepository : EfRepository<Purchase>, IPurchaseRepository
    {
        public PurchaseRepository(ShopDbContext db) : base(db) { }

        public async Task<IEnumerable<(string Category, int Quantity)>> GetCategoriesByClientAsync(Guid clientId)
        {
            // Join purchases -> items -> product, sum quantities by product category
            var q = from p in _db.Purchases
                    where p.ClientId == clientId
                    join pi in _db.PurchaseItems on p.Id equals pi.PurchaseId
                    join prod in _db.Products on pi.ProductId equals prod.Id
                    group pi by prod.Category into g
                    select new { Category = g.Key, Quantity = g.Sum(x => x.Quantity) };

            var list = await q.ToListAsync();
            return list.Select(x => (x.Category, x.Quantity));
        }
    }
}
