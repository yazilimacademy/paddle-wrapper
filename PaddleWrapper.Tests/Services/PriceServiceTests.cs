using FluentAssertions;
using Microsoft.Extensions.Options;
using Moq;
using PaddleWrapper.Core.Configuration;
using PaddleWrapper.Core.Interfaces;
using PaddleWrapper.Core.Models;
using PaddleWrapper.Core.Models.Price;
using PaddleWrapper.Core.Services;
using PaddleWrapper.Core.Services.Prices;
using Xunit;

namespace PaddleWrapper.Tests.Services
{
    public class PriceServiceTests
    {
        private readonly Mock<IPaddleLogger> _loggerMock;
        private readonly Mock<IOptions<PaddleOptions>> _optionsMock;
        private readonly PaddleOptions _options;

        public PriceServiceTests()
        {
            _loggerMock = new Mock<IPaddleLogger>();
            _options = new PaddleOptions
            {
                ApiKey = "test_api_key",
                VendorId = "test_vendor_id"
            };
            _optionsMock = new Mock<IOptions<PaddleOptions>>();
            _optionsMock.Setup(x => x.Value).Returns(_options);
        }

        [Fact]
        public async Task GetPriceAsync_ValidId_ReturnsPrice()
        {
            // Arrange
            Price expectedPrice = new()
            {
                Id = "pri_123",
                UnitPrice = 99.99m,
                Currency = "USD"
            };
            PaddleResponse<Price> expectedResponse = new() { Success = true, Response = expectedPrice };

            HttpClient httpClient = new(new MockHttpMessageHandler(expectedResponse));
            PaddleHttpClient paddleHttpClient = new(httpClient, _optionsMock.Object, _loggerMock.Object);
            PriceService priceService = new(paddleHttpClient);

            // Act
            PaddleResponse<Price> result = await priceService.GetPriceAsync("pri_123");

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.Response.Should().NotBeNull();
            result.Response.Id.Should().Be("pri_123");
            result.Response.UnitPrice.Should().Be(99.99m);
            result.Response.Currency.Should().Be("USD");
        }

        [Fact]
        public async Task CreatePriceAsync_ValidPrice_ReturnsCreatedPrice()
        {
            // Arrange
            Price newPrice = new()
            {
                UnitPrice = 149.99m,
                Currency = "EUR"
            };
            PaddleResponse<Price> expectedResponse = new()
            {
                Success = true,
                Response = new Price
                {
                    Id = "pri_123",
                    UnitPrice = 149.99m,
                    Currency = "EUR"
                }
            };

            HttpClient httpClient = new(new MockHttpMessageHandler(expectedResponse));
            PaddleHttpClient paddleHttpClient = new(httpClient, _optionsMock.Object, _loggerMock.Object);
            PriceService priceService = new(paddleHttpClient);

            // Act
            PaddleResponse<Price> result = await priceService.CreatePriceAsync(newPrice);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.Response.Should().NotBeNull();
            result.Response.Id.Should().Be("pri_123");
            result.Response.UnitPrice.Should().Be(149.99m);
            result.Response.Currency.Should().Be("EUR");
        }

        [Fact]
        public async Task ListPricesAsync_ReturnsPrices()
        {
            // Arrange
            Price[] expectedPrices = new[]
            {
                new Price { Id = "pri_123", UnitPrice = 99.99m, Currency = "USD" },
                new Price { Id = "pri_124", UnitPrice = 149.99m, Currency = "EUR" }
            };
            PaddleResponse<Price[]> expectedResponse = new() { Success = true, Response = expectedPrices };

            HttpClient httpClient = new(new MockHttpMessageHandler(expectedResponse));
            PaddleHttpClient paddleHttpClient = new(httpClient, _optionsMock.Object, _loggerMock.Object);
            PriceService priceService = new(paddleHttpClient);

            // Act
            PaddleResponse<Price[]> result = await priceService.ListPricesAsync();

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.Response.Should().NotBeNull();
            result.Response.Should().HaveCount(2);
            result.Response[0].Currency.Should().Be("USD");
            result.Response[1].Currency.Should().Be("EUR");
        }

        [Fact]
        public async Task AddRegionalPricingAsync_ValidData_ReturnsUpdatedPrice()
        {
            // Arrange
            PaddleResponse<Price> expectedResponse = new()
            {
                Success = true,
                Response = new Price
                {
                    Id = "pri_123",
                    UnitPrice = 89.99m,
                    Currency = "GBP"
                }
            };

            HttpClient httpClient = new(new MockHttpMessageHandler(expectedResponse));
            PaddleHttpClient paddleHttpClient = new(httpClient, _optionsMock.Object, _loggerMock.Object);
            PriceService priceService = new(paddleHttpClient);

            // Act
            PaddleResponse<Price> result = await priceService.AddRegionalPricingAsync("pri_123", "GB", 89.99m);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.Response.Should().NotBeNull();
            result.Response.UnitPrice.Should().Be(89.99m);
            result.Response.Currency.Should().Be("GBP");
        }
    }
}