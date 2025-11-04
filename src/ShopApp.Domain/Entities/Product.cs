namespace ShopApp.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = null!;
        public string Category { get; set; } = null!;
        public string SKU { get; set; } = null!;
        public decimal Price { get; set; }
        public ICollection<PurchaseItem> PurchaseItems { get; set; } = new List<PurchaseItem>();
    }
}
