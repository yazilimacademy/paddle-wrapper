using FluentAssertions;
using Microsoft.Extensions.Options;
using Moq;
using PaddleWrapper.Core.Configuration;
using PaddleWrapper.Core.Interfaces;
using PaddleWrapper.Core.Models;
using PaddleWrapper.Core.Models.Report;
using PaddleWrapper.Core.Services;
using PaddleWrapper.Core.Services.Reports;
using Xunit;

namespace PaddleWrapper.Tests.Services
{
    public class ReportServiceTests
    {
        private readonly Mock<IPaddleLogger> _loggerMock;
        private readonly Mock<IOptions<PaddleOptions>> _optionsMock;
        private readonly PaddleOptions _options;

        public ReportServiceTests()
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
        public async Task CreateReportAsync_ValidParameters_ReturnsReport()
        {
            // Arrange
            ReportParameters parameters = new()
            {
                StartDate = DateTime.UtcNow.AddDays(-30),
                EndDate = DateTime.UtcNow,
                GroupBy = "day"
            };
            Report expectedReport = new()
            {
                Id = "rep_123",
                Type = "revenue",
                Status = "completed",
                CreatedAt = DateTime.UtcNow
            };
            PaddleResponse<Report> expectedResponse = new() { Success = true, Response = expectedReport };

            HttpClient httpClient = new(new MockHttpMessageHandler(expectedResponse));
            PaddleHttpClient paddleHttpClient = new(httpClient, _optionsMock.Object, _loggerMock.Object);
            ReportService reportService = new(paddleHttpClient);

            // Act
            PaddleResponse<Report> result = await reportService.CreateReportAsync("revenue", parameters);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.Response.Should().NotBeNull();
            result.Response.Id.Should().Be("rep_123");
            result.Response.Type.Should().Be("revenue");
            result.Response.Status.Should().Be("completed");
        }

        [Fact]
        public async Task GetReportAsync_ValidId_ReturnsReport()
        {
            // Arrange
            Report expectedReport = new()
            {
                Id = "rep_123",
                Type = "revenue",
                Status = "completed",
                CreatedAt = DateTime.UtcNow
            };
            PaddleResponse<Report> expectedResponse = new() { Success = true, Response = expectedReport };

            HttpClient httpClient = new(new MockHttpMessageHandler(expectedResponse));
            PaddleHttpClient paddleHttpClient = new(httpClient, _optionsMock.Object, _loggerMock.Object);
            ReportService reportService = new(paddleHttpClient);

            // Act
            PaddleResponse<Report> result = await reportService.GetReportAsync("rep_123");

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.Response.Should().NotBeNull();
            result.Response.Id.Should().Be("rep_123");
            result.Response.Type.Should().Be("revenue");
            result.Response.Status.Should().Be("completed");
        }

        [Fact]
        public async Task ListReportsAsync_ReturnsReports()
        {
            // Arrange
            Report[] expectedReports = new[]
            {
                new Report { Id = "rep_123", Type = "revenue", Status = "completed" },
                new Report { Id = "rep_124", Type = "subscription", Status = "completed" }
            };
            PaddleResponse<Report[]> expectedResponse = new() { Success = true, Response = expectedReports };

            HttpClient httpClient = new(new MockHttpMessageHandler(expectedResponse));
            PaddleHttpClient paddleHttpClient = new(httpClient, _optionsMock.Object, _loggerMock.Object);
            ReportService reportService = new(paddleHttpClient);

            // Act
            PaddleResponse<Report[]> result = await reportService.ListReportsAsync();

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.Response.Should().NotBeNull();
            result.Response.Should().HaveCount(2);
            result.Response[0].Type.Should().Be("revenue");
            result.Response[1].Type.Should().Be("subscription");
        }

        [Fact]
        public async Task DownloadReportAsync_ValidId_ReturnsReportData()
        {
            // Arrange
            byte[] expectedData = new byte[] { 1, 2, 3, 4, 5 };
            PaddleResponse<byte[]> expectedResponse = new() { Success = true, Response = expectedData };

            HttpClient httpClient = new(new MockHttpMessageHandler(expectedResponse));
            PaddleHttpClient paddleHttpClient = new(httpClient, _optionsMock.Object, _loggerMock.Object);
            ReportService reportService = new(paddleHttpClient);

            // Act
            PaddleResponse<byte[]> result = await reportService.DownloadReportAsync("rep_123");

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.Response.Should().NotBeNull();
            result.Response.Should().BeEquivalentTo(expectedData);
        }

        [Fact]
        public async Task CreateRevenueReportAsync_ValidParameters_ReturnsReport()
        {
            // Arrange
            DateTime startDate = DateTime.UtcNow.AddDays(-30);
            DateTime endDate = DateTime.UtcNow;
            Report expectedReport = new()
            {
                Id = "rep_123",
                Type = "revenue",
                Status = "completed"
            };
            PaddleResponse<Report> expectedResponse = new() { Success = true, Response = expectedReport };

            HttpClient httpClient = new(new MockHttpMessageHandler(expectedResponse));
            PaddleHttpClient paddleHttpClient = new(httpClient, _optionsMock.Object, _loggerMock.Object);
            ReportService reportService = new(paddleHttpClient);

            // Act
            PaddleResponse<Report> result = await reportService.CreateRevenueReportAsync(startDate, endDate);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.Response.Should().NotBeNull();
            result.Response.Type.Should().Be("revenue");
            result.Response.Status.Should().Be("completed");
        }
    }
}