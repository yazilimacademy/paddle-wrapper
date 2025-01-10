using Microsoft.Extensions.Logging;
using Moq;
using PaddleWrapper.Interfaces;
using PaddleWrapper.Models.Common;
using PaddleWrapper.Models.Prices;
using PaddleWrapper.Services;

namespace PaddleWrapper.Tests.Services
{
    public class PriceServiceTests
    {
        private readonly Mock<IPaddleClient> _mockClient;
        private readonly Mock<ILogger<PriceService>> _mockLogger;
        private readonly PriceService _service;

        public PriceServiceTests()
        {
            _mockClient = new Mock<IPaddleClient>();
            _mockLogger = new Mock<ILogger<PriceService>>();
            _service = new PriceService(_mockClient.Object, _mockLogger.Object);
        }

        [Fact]
        public async Task ListPricesAsync_ShouldReturnPrices()
        {
            // Arrange
            PaddleResponse<List<Price>> expectedResponse = new()
            {
                Data = new List<Price>
                {
                    new() { Id = "pri_1", UnitPrice = new UnitPrice { Amount = "9.99", CurrencyCode = "USD" } },
                    new() { Id = "pri_2", UnitPrice = new UnitPrice { Amount = "19.99", CurrencyCode = "USD" } }
                }
            };

            _mockClient
                .Setup(x => x.GetAsync<PaddleResponse<List<Price>>>("/prices", It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResponse);

            // Act
            PaddleResponse<List<Price>> result = await _service.ListPricesAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Data.Count);
            Assert.Equal("pri_1", result.Data[0].Id);
            Assert.Equal("pri_2", result.Data[1].Id);
        }

        [Fact]
        public async Task GetPriceAsync_WithValidId_ShouldReturnPrice()
        {
            // Arrange
            string priceId = "pri_1";
            PaddleResponse<Price> expectedResponse = new()
            {
                Data = new Price { Id = priceId, UnitPrice = new UnitPrice { Amount = "9.99", CurrencyCode = "USD" } }
            };

            _mockClient
                .Setup(x => x.GetAsync<PaddleResponse<Price>>($"/prices/{priceId}", It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResponse);

            // Act
            PaddleResponse<Price> result = await _service.GetPriceAsync(priceId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(priceId, result.Data.Id);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async Task GetPriceAsync_WithInvalidId_ShouldThrowArgumentException(string priceId)
        {
            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _service.GetPriceAsync(priceId));
        }

        [Fact]
        public async Task CreatePriceAsync_WithValidPrice_ShouldReturnCreatedPrice()
        {
            // Arrange
            Price price = new() { UnitPrice = new UnitPrice { Amount = "9.99", CurrencyCode = "USD" } };
            PaddleResponse<Price> expectedResponse = new()
            {
                Data = new Price { Id = "pri_1", UnitPrice = new UnitPrice { Amount = "9.99", CurrencyCode = "USD" } }
            };

            _mockClient
                .Setup(x => x.PostAsync<Price, PaddleResponse<Price>>("/prices", price, It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResponse);

            // Act
            PaddleResponse<Price> result = await _service.CreatePriceAsync(price);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("pri_1", result.Data.Id);
            Assert.Equal(price.UnitPrice.Amount, result.Data.UnitPrice.Amount);
            Assert.Equal(price.UnitPrice.CurrencyCode, result.Data.UnitPrice.CurrencyCode);
        }

        [Fact]
        public async Task CreatePriceAsync_WithNullPrice_ShouldThrowArgumentNullException()
        {
            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => _service.CreatePriceAsync(null));
        }

        [Fact]
        public async Task UpdatePriceAsync_WithValidPrice_ShouldReturnUpdatedPrice()
        {
            // Arrange
            string priceId = "pri_1";
            Price price = new() { UnitPrice = new UnitPrice { Amount = "19.99", CurrencyCode = "USD" } };
            PaddleResponse<Price> expectedResponse = new()
            {
                Data = new Price { Id = priceId, UnitPrice = new UnitPrice { Amount = "19.99", CurrencyCode = "USD" } }
            };

            _mockClient
                .Setup(x => x.PatchAsync<Price, PaddleResponse<Price>>($"/prices/{priceId}", price, It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResponse);

            // Act
            PaddleResponse<Price> result = await _service.UpdatePriceAsync(priceId, price);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(priceId, result.Data.Id);
            Assert.Equal(price.UnitPrice.Amount, result.Data.UnitPrice.Amount);
            Assert.Equal(price.UnitPrice.CurrencyCode, result.Data.UnitPrice.CurrencyCode);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async Task UpdatePriceAsync_WithInvalidId_ShouldThrowArgumentException(string priceId)
        {
            // Arrange
            Price price = new() { UnitPrice = new UnitPrice { Amount = "9.99", CurrencyCode = "USD" } };

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _service.UpdatePriceAsync(priceId, price));
        }

        [Fact]
        public async Task UpdatePriceAsync_WithNullPrice_ShouldThrowArgumentNullException()
        {
            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => _service.UpdatePriceAsync("pri_1", null));
        }

        [Fact]
        public async Task ListProductPricesAsync_WithValidProductId_ShouldReturnPrices()
        {
            // Arrange
            string productId = "prod_1";
            PaddleResponse<List<Price>> expectedResponse = new()
            {
                Data = new List<Price>
                {
                    new() { Id = "pri_1", UnitPrice = new UnitPrice { Amount = "9.99", CurrencyCode = "USD" } },
                    new() { Id = "pri_2", UnitPrice = new UnitPrice { Amount = "19.99", CurrencyCode = "USD" } }
                }
            };

            _mockClient
                .Setup(x => x.GetAsync<PaddleResponse<List<Price>>>($"/prices?product_id={productId}", It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResponse);

            // Act
            PaddleResponse<List<Price>> result = await _service.ListProductPricesAsync(productId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Data.Count);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async Task ListProductPricesAsync_WithInvalidProductId_ShouldThrowArgumentException(string productId)
        {
            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _service.ListProductPricesAsync(productId));
        }
    }
}