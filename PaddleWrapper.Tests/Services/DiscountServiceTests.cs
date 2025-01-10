using System;
using System.Net.Http;
using System.Threading.Tasks;
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
            var expectedDiscount = new Discount 
            { 
                Id = "disc_123",
                Code = "TEST10",
                Amount = 10,
                Type = "percentage"
            };
            var expectedResponse = new PaddleResponse<Discount> { Success = true, Response = expectedDiscount };

            var httpClient = new HttpClient(new MockHttpMessageHandler(expectedResponse));
            var paddleHttpClient = new PaddleHttpClient(httpClient, _optionsMock.Object, _loggerMock.Object);
            var discountService = new DiscountService(paddleHttpClient);

            // Act
            var result = await discountService.GetDiscountAsync("disc_123");

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
            var newDiscount = new Discount 
            { 
                Code = "NEW20",
                Amount = 20,
                Type = "percentage"
            };
            var expectedResponse = new PaddleResponse<Discount>
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

            var httpClient = new HttpClient(new MockHttpMessageHandler(expectedResponse));
            var paddleHttpClient = new PaddleHttpClient(httpClient, _optionsMock.Object, _loggerMock.Object);
            var discountService = new DiscountService(paddleHttpClient);

            // Act
            var result = await discountService.CreateDiscountAsync(newDiscount);

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
            var expectedDiscounts = new[]
            {
                new Discount { Id = "disc_123", Code = "TEST10", Amount = 10, Type = "percentage" },
                new Discount { Id = "disc_124", Code = "TEST20", Amount = 20, Type = "percentage" }
            };
            var expectedResponse = new PaddleResponse<Discount[]> { Success = true, Response = expectedDiscounts };

            var httpClient = new HttpClient(new MockHttpMessageHandler(expectedResponse));
            var paddleHttpClient = new PaddleHttpClient(httpClient, _optionsMock.Object, _loggerMock.Object);
            var discountService = new DiscountService(paddleHttpClient);

            // Act
            var result = await discountService.ListDiscountsAsync();

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
            var expectedResponse = new PaddleResponse<bool> { Success = true, Response = true };

            var httpClient = new HttpClient(new MockHttpMessageHandler(expectedResponse));
            var paddleHttpClient = new PaddleHttpClient(httpClient, _optionsMock.Object, _loggerMock.Object);
            var discountService = new DiscountService(paddleHttpClient);

            // Act
            var result = await discountService.ValidateDiscountAsync("TEST10");

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.Response.Should().BeTrue();
        }
    }
} 