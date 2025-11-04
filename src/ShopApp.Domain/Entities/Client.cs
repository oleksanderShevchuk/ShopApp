namespace ShopApp.Domain.Entities
{
    public class Client
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FullName { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public DateTime RegisteredAt { get; set; } = DateTime.UtcNow;
        public ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
    }
}
