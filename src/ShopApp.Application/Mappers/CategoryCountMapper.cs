using ShopApp.Application.DTOs;

namespace ShopApp.Application.Mappers
{
    public static class CategoryCountMapper
    {
        public static CategoryCountDto ToDto((string Category, int Quantity) categoryTuple)
        {
            return new CategoryCountDto
            {
                Category = categoryTuple.Category,
                Quantity = categoryTuple.Quantity
            };
        }

        public static IEnumerable<CategoryCountDto> ToDto(IEnumerable<(string Category, int Quantity)> categories)
        {
            return categories.Select(ToDto);
        }
    }
}
