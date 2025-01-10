using FluentAssertions;
using Microsoft.Extensions.Options;
using Moq;
using PaddleWrapper.Core.Configuration;
using PaddleWrapper.Core.Interfaces;
using PaddleWrapper.Core.Models;
using PaddleWrapper.Core.Models.Adjustment;
using PaddleWrapper.Core.Services;
using PaddleWrapper.Core.Services.Adjustments;
using Xunit;

namespace PaddleWrapper.Tests.Services
{
    public class AdjustmentServiceTests
    {
        private readonly Mock<IPaddleLogger> _loggerMock;
        private readonly Mock<IOptions<PaddleOptions>> _optionsMock;
        private readonly PaddleOptions _options;

        public AdjustmentServiceTests()
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
        public async Task GetAdjustmentAsync_ValidId_ReturnsAdjustment()
        {
            // Arrange
            Adjustment expectedAdjustment = new() { Id = "adj_123", Amount = 100.00m };
            PaddleResponse<Adjustment> expectedResponse = new() { Success = true, Response = expectedAdjustment };

            HttpClient httpClient = new(new MockHttpMessageHandler(expectedResponse));
            PaddleHttpClient paddleHttpClient = new(httpClient, _optionsMock.Object, _loggerMock.Object);
            AdjustmentService adjustmentService = new(paddleHttpClient);

            // Act
            PaddleResponse<Adjustment> result = await adjustmentService.GetAdjustmentAsync("adj_123");

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.Response.Should().NotBeNull();
            result.Response.Id.Should().Be("adj_123");
            result.Response.Amount.Should().Be(100.00m);
        }

        [Fact]
        public async Task CreateAdjustmentAsync_ValidAdjustment_ReturnsCreatedAdjustment()
        {
            // Arrange
            Adjustment newAdjustment = new() { Amount = 50.00m };
            PaddleResponse<Adjustment> expectedResponse = new()
            {
                Success = true,
                Response = new Adjustment { Id = "adj_123", Amount = 50.00m }
            };

            HttpClient httpClient = new(new MockHttpMessageHandler(expectedResponse));
            PaddleHttpClient paddleHttpClient = new(httpClient, _optionsMock.Object, _loggerMock.Object);
            AdjustmentService adjustmentService = new(paddleHttpClient);

            // Act
            PaddleResponse<Adjustment> result = await adjustmentService.CreateAdjustmentAsync(newAdjustment);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.Response.Should().NotBeNull();
            result.Response.Id.Should().Be("adj_123");
            result.Response.Amount.Should().Be(50.00m);
        }

        [Fact]
        public async Task ListAdjustmentsAsync_ReturnsAdjustments()
        {
            // Arrange
            Adjustment[] expectedAdjustments = new[]
            {
                new Adjustment { Id = "adj_123", Amount = 100.00m },
                new Adjustment { Id = "adj_124", Amount = 200.00m }
            };
            PaddleResponse<Adjustment[]> expectedResponse = new() { Success = true, Response = expectedAdjustments };

            HttpClient httpClient = new(new MockHttpMessageHandler(expectedResponse));
            PaddleHttpClient paddleHttpClient = new(httpClient, _optionsMock.Object, _loggerMock.Object);
            AdjustmentService adjustmentService = new(paddleHttpClient);

            // Act
            PaddleResponse<Adjustment[]> result = await adjustmentService.ListAdjustmentsAsync();

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.Response.Should().NotBeNull();
            result.Response.Should().HaveCount(2);
            result.Response[0].Id.Should().Be("adj_123");
            result.Response[1].Id.Should().Be("adj_124");
        }

        [Fact]
        public async Task CancelAdjustmentAsync_ValidId_ReturnsCancelledAdjustment()
        {
            // Arrange
            PaddleResponse<bool> expectedResponse = new() { Success = true, Response = true };

            HttpClient httpClient = new(new MockHttpMessageHandler(expectedResponse));
            PaddleHttpClient paddleHttpClient = new(httpClient, _optionsMock.Object, _loggerMock.Object);
            AdjustmentService adjustmentService = new(paddleHttpClient);

            // Act
            PaddleResponse<bool> result = await adjustmentService.CancelAdjustmentAsync("adj_123");

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.Response.Should().BeTrue();
        }
    }
}