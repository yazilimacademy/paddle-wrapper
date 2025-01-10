using System;
using System.Net.Http;
using System.Threading.Tasks;
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
            var expectedPrice = new Price 
            { 
                Id = "pri_123",
                UnitPrice = 99.99m,
                Currency = "USD"
            };
            var expectedResponse = new PaddleResponse<Price> { Success = true, Response = expectedPrice };

            var httpClient = new HttpClient(new MockHttpMessageHandler(expectedResponse));
            var paddleHttpClient = new PaddleHttpClient(httpClient, _optionsMock.Object, _loggerMock.Object);
            var priceService = new PriceService(paddleHttpClient);

            // Act
            var result = await priceService.GetPriceAsync("pri_123");

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
            var newPrice = new Price 
            { 
                UnitPrice = 149.99m,
                Currency = "EUR"
            };
            var expectedResponse = new PaddleResponse<Price>
            {
                Success = true,
                Response = new Price 
                { 
                    Id = "pri_123",
                    UnitPrice = 149.99m,
                    Currency = "EUR"
                }
            };

            var httpClient = new HttpClient(new MockHttpMessageHandler(expectedResponse));
            var paddleHttpClient = new PaddleHttpClient(httpClient, _optionsMock.Object, _loggerMock.Object);
            var priceService = new PriceService(paddleHttpClient);

            // Act
            var result = await priceService.CreatePriceAsync(newPrice);

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
            var expectedPrices = new[]
            {
                new Price { Id = "pri_123", UnitPrice = 99.99m, Currency = "USD" },
                new Price { Id = "pri_124", UnitPrice = 149.99m, Currency = "EUR" }
            };
            var expectedResponse = new PaddleResponse<Price[]> { Success = true, Response = expectedPrices };

            var httpClient = new HttpClient(new MockHttpMessageHandler(expectedResponse));
            var paddleHttpClient = new PaddleHttpClient(httpClient, _optionsMock.Object, _loggerMock.Object);
            var priceService = new PriceService(paddleHttpClient);

            // Act
            var result = await priceService.ListPricesAsync();

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
            var expectedResponse = new PaddleResponse<Price>
            {
                Success = true,
                Response = new Price 
                { 
                    Id = "pri_123",
                    UnitPrice = 89.99m,
                    Currency = "GBP"
                }
            };

            var httpClient = new HttpClient(new MockHttpMessageHandler(expectedResponse));
            var paddleHttpClient = new PaddleHttpClient(httpClient, _optionsMock.Object, _loggerMock.Object);
            var priceService = new PriceService(paddleHttpClient);

            // Act
            var result = await priceService.AddRegionalPricingAsync("pri_123", "GB", 89.99m);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.Response.Should().NotBeNull();
            result.Response.UnitPrice.Should().Be(89.99m);
            result.Response.Currency.Should().Be("GBP");
        }
    }
} 