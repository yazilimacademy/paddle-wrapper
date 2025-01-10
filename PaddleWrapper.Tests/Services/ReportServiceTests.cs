using System;
using System.Net.Http;
using System.Threading.Tasks;
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
            var parameters = new ReportParameters
            {
                StartDate = DateTime.UtcNow.AddDays(-30),
                EndDate = DateTime.UtcNow,
                GroupBy = "day"
            };
            var expectedReport = new Report 
            { 
                Id = "rep_123",
                Type = "revenue",
                Status = "completed",
                CreatedAt = DateTime.UtcNow
            };
            var expectedResponse = new PaddleResponse<Report> { Success = true, Response = expectedReport };

            var httpClient = new HttpClient(new MockHttpMessageHandler(expectedResponse));
            var paddleHttpClient = new PaddleHttpClient(httpClient, _optionsMock.Object, _loggerMock.Object);
            var reportService = new ReportService(paddleHttpClient);

            // Act
            var result = await reportService.CreateReportAsync("revenue", parameters);

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
            var expectedReport = new Report 
            { 
                Id = "rep_123",
                Type = "revenue",
                Status = "completed",
                CreatedAt = DateTime.UtcNow
            };
            var expectedResponse = new PaddleResponse<Report> { Success = true, Response = expectedReport };

            var httpClient = new HttpClient(new MockHttpMessageHandler(expectedResponse));
            var paddleHttpClient = new PaddleHttpClient(httpClient, _optionsMock.Object, _loggerMock.Object);
            var reportService = new ReportService(paddleHttpClient);

            // Act
            var result = await reportService.GetReportAsync("rep_123");

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
            var expectedReports = new[]
            {
                new Report { Id = "rep_123", Type = "revenue", Status = "completed" },
                new Report { Id = "rep_124", Type = "subscription", Status = "completed" }
            };
            var expectedResponse = new PaddleResponse<Report[]> { Success = true, Response = expectedReports };

            var httpClient = new HttpClient(new MockHttpMessageHandler(expectedResponse));
            var paddleHttpClient = new PaddleHttpClient(httpClient, _optionsMock.Object, _loggerMock.Object);
            var reportService = new ReportService(paddleHttpClient);

            // Act
            var result = await reportService.ListReportsAsync();

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
            var expectedData = new byte[] { 1, 2, 3, 4, 5 };
            var expectedResponse = new PaddleResponse<byte[]> { Success = true, Response = expectedData };

            var httpClient = new HttpClient(new MockHttpMessageHandler(expectedResponse));
            var paddleHttpClient = new PaddleHttpClient(httpClient, _optionsMock.Object, _loggerMock.Object);
            var reportService = new ReportService(paddleHttpClient);

            // Act
            var result = await reportService.DownloadReportAsync("rep_123");

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
            var startDate = DateTime.UtcNow.AddDays(-30);
            var endDate = DateTime.UtcNow;
            var expectedReport = new Report 
            { 
                Id = "rep_123",
                Type = "revenue",
                Status = "completed"
            };
            var expectedResponse = new PaddleResponse<Report> { Success = true, Response = expectedReport };

            var httpClient = new HttpClient(new MockHttpMessageHandler(expectedResponse));
            var paddleHttpClient = new PaddleHttpClient(httpClient, _optionsMock.Object, _loggerMock.Object);
            var reportService = new ReportService(paddleHttpClient);

            // Act
            var result = await reportService.CreateRevenueReportAsync(startDate, endDate);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.Response.Should().NotBeNull();
            result.Response.Type.Should().Be("revenue");
            result.Response.Status.Should().Be("completed");
        }
    }
} 