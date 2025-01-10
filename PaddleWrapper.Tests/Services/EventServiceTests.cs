using System;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Extensions.Options;
using Moq;
using PaddleWrapper.Core.Configuration;
using PaddleWrapper.Core.Interfaces;
using PaddleWrapper.Core.Models;
using PaddleWrapper.Core.Models.Event;
using PaddleWrapper.Core.Services;
using PaddleWrapper.Core.Services.Events;
using Xunit;

namespace PaddleWrapper.Tests.Services
{
    public class EventServiceTests
    {
        private readonly Mock<IPaddleLogger> _loggerMock;
        private readonly Mock<IOptions<PaddleOptions>> _optionsMock;
        private readonly PaddleOptions _options;

        public EventServiceTests()
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
        public async Task GetEventAsync_ValidId_ReturnsEvent()
        {
            // Arrange
            var expectedEvent = new Event 
            { 
                Id = "evt_123",
                Type = "subscription.created",
                OccurredAt = DateTime.UtcNow
            };
            var expectedResponse = new PaddleResponse<Event> { Success = true, Response = expectedEvent };

            var httpClient = new HttpClient(new MockHttpMessageHandler(expectedResponse));
            var paddleHttpClient = new PaddleHttpClient(httpClient, _optionsMock.Object, _loggerMock.Object);
            var eventService = new EventService(paddleHttpClient);

            // Act
            var result = await eventService.GetEventAsync("evt_123");

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.Response.Should().NotBeNull();
            result.Response.Id.Should().Be("evt_123");
            result.Response.Type.Should().Be("subscription.created");
            result.Response.OccurredAt.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(1));
        }

        [Fact]
        public async Task ListEventsAsync_ReturnsEvents()
        {
            // Arrange
            var expectedEvents = new[]
            {
                new Event { Id = "evt_123", Type = "subscription.created", OccurredAt = DateTime.UtcNow },
                new Event { Id = "evt_124", Type = "payment.succeeded", OccurredAt = DateTime.UtcNow }
            };
            var expectedResponse = new PaddleResponse<Event[]> { Success = true, Response = expectedEvents };

            var httpClient = new HttpClient(new MockHttpMessageHandler(expectedResponse));
            var paddleHttpClient = new PaddleHttpClient(httpClient, _optionsMock.Object, _loggerMock.Object);
            var eventService = new EventService(paddleHttpClient);

            // Act
            var result = await eventService.ListEventsAsync();

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.Response.Should().NotBeNull();
            result.Response.Should().HaveCount(2);
            result.Response[0].Type.Should().Be("subscription.created");
            result.Response[1].Type.Should().Be("payment.succeeded");
        }

        [Fact]
        public async Task GetCustomerEventsAsync_ValidCustomerId_ReturnsCustomerEvents()
        {
            // Arrange
            var expectedEvents = new[]
            {
                new Event { Id = "evt_123", Type = "customer.updated", OccurredAt = DateTime.UtcNow },
                new Event { Id = "evt_124", Type = "customer.created", OccurredAt = DateTime.UtcNow }
            };
            var expectedResponse = new PaddleResponse<Event[]> { Success = true, Response = expectedEvents };

            var httpClient = new HttpClient(new MockHttpMessageHandler(expectedResponse));
            var paddleHttpClient = new PaddleHttpClient(httpClient, _optionsMock.Object, _loggerMock.Object);
            var eventService = new EventService(paddleHttpClient);

            // Act
            var result = await eventService.GetCustomerEventsAsync("cus_123");

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.Response.Should().NotBeNull();
            result.Response.Should().HaveCount(2);
            result.Response[0].Type.Should().Be("customer.updated");
            result.Response[1].Type.Should().Be("customer.created");
        }

        [Fact]
        public async Task RetryEventAsync_ValidEventId_ReturnsSuccess()
        {
            // Arrange
            var expectedResponse = new PaddleResponse<bool> { Success = true, Response = true };

            var httpClient = new HttpClient(new MockHttpMessageHandler(expectedResponse));
            var paddleHttpClient = new PaddleHttpClient(httpClient, _optionsMock.Object, _loggerMock.Object);
            var eventService = new EventService(paddleHttpClient);

            // Act
            var result = await eventService.RetryEventAsync("evt_123");

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.Response.Should().BeTrue();
        }

        [Fact]
        public async Task MarkEventAsync_ValidEventIdAndStatus_ReturnsSuccess()
        {
            // Arrange
            var expectedResponse = new PaddleResponse<bool> { Success = true, Response = true };

            var httpClient = new HttpClient(new MockHttpMessageHandler(expectedResponse));
            var paddleHttpClient = new PaddleHttpClient(httpClient, _optionsMock.Object, _loggerMock.Object);
            var eventService = new EventService(paddleHttpClient);

            // Act
            var result = await eventService.MarkEventAsync("evt_123", "processed");

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.Response.Should().BeTrue();
        }
    }
} 