using ShopApp.Application.DTOs;
using ShopApp.Domain.Entities;

namespace ShopApp.Application.Mappers
{
    public static class ClientMapper
    {
        public static ClientDto ToDto(Client entity)
        {
            return new ClientDto
            {
                Id = entity.Id,
                FullName = entity.FullName
            };
        }

        public static IEnumerable<ClientDto> ToDto(IEnumerable<Client> entities)
        {
            return entities.Select(ToDto);
        }
    }
}
