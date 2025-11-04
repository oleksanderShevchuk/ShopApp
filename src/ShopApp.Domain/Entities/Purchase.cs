namespace ShopApp.Domain.Entities
{
    public class Purchase
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Number { get; set; } = null!; // order number
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public decimal Total { get; set; }
        public Guid ClientId { get; set; }
        public Client Client { get; set; } = null!;
        public ICollection<PurchaseItem> Items { get; set; } = new List<PurchaseItem>();
    }
}
