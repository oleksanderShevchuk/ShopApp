namespace ShopApp.Domain.Entities
{
    public class PurchaseItem
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid PurchaseId { get; set; }
        public Purchase Purchase { get; set; } = null!;
        public Guid ProductId { get; set; }
        public Product Product { get; set; } = null!;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
