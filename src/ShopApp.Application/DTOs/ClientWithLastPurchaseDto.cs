namespace ShopApp.Application.DTOs
{
    public class ClientWithLastPurchaseDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public DateTime LastPurchaseDate { get; set; }
    }
}
