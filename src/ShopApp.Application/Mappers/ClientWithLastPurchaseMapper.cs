using ShopApp.Application.DTOs;
using ShopApp.Domain.Entities;

namespace ShopApp.Application.Mappers
{
    public static class ClientWithLastPurchaseMapper
    {
        public static ClientWithLastPurchaseDto ToDto(Client client)
        {
            var lastPurchaseDate = client.Purchases?
                .OrderByDescending(p => p.Date)
                .FirstOrDefault()?.Date ?? DateTime.MinValue;

            return new ClientWithLastPurchaseDto
            {
                Id = client.Id,
                FullName = client.FullName,
                LastPurchaseDate = lastPurchaseDate
            };
        }

        public static IEnumerable<ClientWithLastPurchaseDto> ToDto(IEnumerable<Client> clients)
        {
            return clients.Select(ToDto);
        }
    }
}
