using Microsoft.EntityFrameworkCore;
using ShopApp.Domain.Entities;

namespace ShopApp.Infrastructure.Persistence
{
    public class ShopDbContext : DbContext
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options) { }

        public DbSet<Client> Clients { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Purchase> Purchases { get; set; } = null!;
        public DbSet<PurchaseItem> PurchaseItems { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Client>(b =>
            {
                b.HasKey(x => x.Id);
                b.Property(x => x.FullName)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Product>(b =>
            {
                b.HasKey(x => x.Id);
                b.Property(x => x.Name)
                    .IsRequired()
                    .HasMaxLength(200);
                b.Property(x => x.Category)
                    .IsRequired()
                    .HasMaxLength(100);
                b.Property(x => x.SKU)
                    .IsRequired()
                    .HasMaxLength(50);
                b.Property(x => x.Price)
                    .HasPrecision(18, 2);
            });

            modelBuilder.Entity<Purchase>(b =>
            {
                b.HasKey(x => x.Id);
                b.Property(x => x.Number)
                    .IsRequired()
                    .HasMaxLength(50);
                b.Property(x => x.Total)
                    .HasPrecision(18, 2);

                b.HasOne(p => p.Client)
                    .WithMany(c => c.Purchases)
                    .HasForeignKey(p => p.ClientId);
            });

            modelBuilder.Entity<PurchaseItem>(b =>
            {
                b.HasKey(x => x.Id);

                b.HasOne(pi => pi.Purchase)
                    .WithMany(p => p.Items)
                    .HasForeignKey(pi => pi.PurchaseId);

                b.HasOne(pi => pi.Product)
                    .WithMany(p => p.PurchaseItems)
                    .HasForeignKey(pi => pi.ProductId);

                b.Property(pi => pi.UnitPrice)
                    .HasPrecision(18, 2);
            });
        }
    }
}
