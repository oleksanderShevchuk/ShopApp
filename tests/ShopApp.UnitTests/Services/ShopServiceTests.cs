using Moq;
using ShopApp.Application.DTOs;
using ShopApp.Application.Interfaces;
using ShopApp.Application.Services;
using ShopApp.Domain.Entities;

namespace ShopApp.UnitTests.Services
{
    public class ShopServiceTests
    {
        private readonly Mock<IUnitOfWork> _uowMock;
        private readonly Mock<IClientRepository> _clientRepoMock;
        private readonly Mock<IPurchaseRepository> _purchaseRepoMock;
        private readonly ShopService _service;

        public ShopServiceTests()
        {
            _uowMock = new Mock<IUnitOfWork>();
            _clientRepoMock = new Mock<IClientRepository>();
            _purchaseRepoMock = new Mock<IPurchaseRepository>();

            _uowMock.Setup(u => u.Clients).Returns(_clientRepoMock.Object);
            _uowMock.Setup(u => u.Purchases).Returns(_purchaseRepoMock.Object);

            _service = new ShopService(_uowMock.Object);
        }

        [Fact]
        public async Task GetBirthdaysAsync_ReturnsMappedClients()
        {
            // Arrange
            var date = new DateTime(2025, 11, 4);
            var clients = new List<Client>
            {
                new Client { Id = Guid.NewGuid(), FullName = "John Doe", BirthDate = date },
                new Client { Id = Guid.NewGuid(), FullName = "Jane Smith", BirthDate = date }
            };

            _clientRepoMock.Setup(r => r.GetBirthdaysOnAsync(date))
                .ReturnsAsync(clients);

            // Act
            var result = await _service.GetBirthdaysAsync(date);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            Assert.All(result, c => Assert.False(string.IsNullOrEmpty(c.FullName)));

            _clientRepoMock.Verify(r => r.GetBirthdaysOnAsync(date), Times.Once);
        }

        [Fact]
        public async Task GetRecentCustomersAsync_ReturnsClientsWithPurchases()
        {
            // Arrange
            int days = 7;
            var data = new List<ClientWithLastPurchaseDto>
            {
                new ClientWithLastPurchaseDto
                {
                    Id = Guid.NewGuid(),
                    FullName = "Alice",
                    LastPurchaseDate = DateTime.UtcNow.AddDays(-1)
                }
            };

            _clientRepoMock.Setup(r => r.GetClientsWithPurchasesInLastDaysAsync(days))
                .ReturnsAsync(data);

            // Act
            var result = await _service.GetRecentCustomersAsync(days);

            // Assert
            Assert.Single(result);
            Assert.Equal("Alice", result.First().FullName);
            _clientRepoMock.Verify(r => r.GetClientsWithPurchasesInLastDaysAsync(days), Times.Once);
        }

        [Fact]
        public async Task GetCustomerCategoriesAsync_ReturnsCategoryCounts()
        {
            // Arrange
            var clientId = Guid.NewGuid();
            var categories = new List<(string Category, int Quantity)>
            {
                ("Electronics", 5),
                ("Books", 3)
            };

            _purchaseRepoMock.Setup(r => r.GetCategoriesByClientAsync(clientId))
                .ReturnsAsync(categories);

            // Act
            var result = await _service.GetCustomerCategoriesAsync(clientId);

            // Assert
            Assert.Equal(2, result.Count());
            Assert.Contains(result, c => c.Category == "Electronics" && c.Quantity == 5);
            _purchaseRepoMock.Verify(r => r.GetCategoriesByClientAsync(clientId), Times.Once);
        }
    }
}
