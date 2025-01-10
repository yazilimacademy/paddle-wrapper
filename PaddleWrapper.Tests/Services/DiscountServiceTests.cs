using FluentAssertions;
using Microsoft.Extensions.Options;
using Moq;
using PaddleWrapper.Core.Configuration;
using PaddleWrapper.Core.Interfaces;
using PaddleWrapper.Core.Models;
using PaddleWrapper.Core.Models.Discount;
using PaddleWrapper.Core.Services;
using PaddleWrapper.Core.Services.Discounts;
using Xunit;

namespace PaddleWrapper.Tests.Services
{
    public class DiscountServiceTests
    {
        private readonly Mock<IPaddleLogger> _loggerMock;
        private readonly Mock<IOptions<PaddleOptions>> _optionsMock;
        private readonly PaddleOptions _options;

        public DiscountServiceTests()
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
        public async Task GetDiscountAsync_ValidId_ReturnsDiscount()
        {
            // Arrange
            Discount expectedDiscount = new()
            {
                Id = "disc_123",
                Code = "TEST10",
                Amount = 10,
                Type = "percentage"
            };
            PaddleResponse<Discount> expectedResponse = new() { Success = true, Response = expectedDiscount };

            HttpClient httpClient = new(new MockHttpMessageHandler(expectedResponse));
            PaddleHttpClient paddleHttpClient = new(httpClient, _optionsMock.Object, _loggerMock.Object);
            DiscountService discountService = new(paddleHttpClient);

            // Act
            PaddleResponse<Discount> result = await discountService.GetDiscountAsync("disc_123");

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.Response.Should().NotBeNull();
            result.Response.Id.Should().Be("disc_123");
            result.Response.Code.Should().Be("TEST10");
            result.Response.Amount.Should().Be(10);
            result.Response.Type.Should().Be("percentage");
        }

        [Fact]
        public async Task CreateDiscountAsync_ValidDiscount_ReturnsCreatedDiscount()
        {
            // Arrange
            Discount newDiscount = new()
            {
                Code = "NEW20",
                Amount = 20,
                Type = "percentage"
            };
            PaddleResponse<Discount> expectedResponse = new()
            {
                Success = true,
                Response = new Discount
                {
                    Id = "disc_123",
                    Code = "NEW20",
                    Amount = 20,
                    Type = "percentage"
                }
            };

            HttpClient httpClient = new(new MockHttpMessageHandler(expectedResponse));
            PaddleHttpClient paddleHttpClient = new(httpClient, _optionsMock.Object, _loggerMock.Object);
            DiscountService discountService = new(paddleHttpClient);

            // Act
            PaddleResponse<Discount> result = await discountService.CreateDiscountAsync(newDiscount);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.Response.Should().NotBeNull();
            result.Response.Id.Should().Be("disc_123");
            result.Response.Code.Should().Be("NEW20");
            result.Response.Amount.Should().Be(20);
            result.Response.Type.Should().Be("percentage");
        }

        [Fact]
        public async Task ListDiscountsAsync_ReturnsDiscounts()
        {
            // Arrange
            Discount[] expectedDiscounts = new[]
            {
                new Discount { Id = "disc_123", Code = "TEST10", Amount = 10, Type = "percentage" },
                new Discount { Id = "disc_124", Code = "TEST20", Amount = 20, Type = "percentage" }
            };
            PaddleResponse<Discount[]> expectedResponse = new() { Success = true, Response = expectedDiscounts };

            HttpClient httpClient = new(new MockHttpMessageHandler(expectedResponse));
            PaddleHttpClient paddleHttpClient = new(httpClient, _optionsMock.Object, _loggerMock.Object);
            DiscountService discountService = new(paddleHttpClient);

            // Act
            PaddleResponse<Discount[]> result = await discountService.ListDiscountsAsync();

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.Response.Should().NotBeNull();
            result.Response.Should().HaveCount(2);
            result.Response[0].Code.Should().Be("TEST10");
            result.Response[1].Code.Should().Be("TEST20");
        }

        [Fact]
        public async Task ValidateDiscountAsync_ValidCode_ReturnsValidationResult()
        {
            // Arrange
            PaddleResponse<bool> expectedResponse = new() { Success = true, Response = true };

            HttpClient httpClient = new(new MockHttpMessageHandler(expectedResponse));
            PaddleHttpClient paddleHttpClient = new(httpClient, _optionsMock.Object, _loggerMock.Object);
            DiscountService discountService = new(paddleHttpClient);

            // Act
            PaddleResponse<bool> result = await discountService.ValidateDiscountAsync("TEST10");

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.Response.Should().BeTrue();
        }
    }
}