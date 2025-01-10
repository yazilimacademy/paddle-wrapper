using FluentAssertions;
using Microsoft.Extensions.Options;
using Moq;
using PaddleWrapper.Core.Configuration;
using PaddleWrapper.Core.Interfaces;
using PaddleWrapper.Core.Models;
using PaddleWrapper.Core.Models.Customer;
using PaddleWrapper.Core.Services;
using PaddleWrapper.Core.Services.Customers;
using Xunit;

namespace PaddleWrapper.Tests.Services
{
    public class CustomerServiceTests
    {
        private readonly Mock<IPaddleLogger> _loggerMock;
        private readonly Mock<IOptions<PaddleOptions>> _optionsMock;
        private readonly PaddleOptions _options;

        public CustomerServiceTests()
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
        public async Task GetCustomerAsync_ValidId_ReturnsCustomer()
        {
            // Arrange
            Customer expectedCustomer = new()
            {
                Id = "cus_123",
                Email = "test@example.com",
                Name = "Test Customer"
            };
            PaddleResponse<Customer> expectedResponse = new() { Success = true, Response = expectedCustomer };

            HttpClient httpClient = new(new MockHttpMessageHandler(expectedResponse));
            PaddleHttpClient paddleHttpClient = new(httpClient, _optionsMock.Object, _loggerMock.Object);
            CustomerService customerService = new(paddleHttpClient);

            // Act
            PaddleResponse<Customer> result = await customerService.GetCustomerAsync("cus_123");

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.Response.Should().NotBeNull();
            result.Response.Id.Should().Be("cus_123");
            result.Response.Email.Should().Be("test@example.com");
            result.Response.Name.Should().Be("Test Customer");
        }

        [Fact]
        public async Task CreateCustomerAsync_ValidCustomer_ReturnsCreatedCustomer()
        {
            // Arrange
            Customer newCustomer = new()
            {
                Email = "new@example.com",
                Name = "New Customer"
            };
            PaddleResponse<Customer> expectedResponse = new()
            {
                Success = true,
                Response = new Customer
                {
                    Id = "cus_123",
                    Email = "new@example.com",
                    Name = "New Customer"
                }
            };

            HttpClient httpClient = new(new MockHttpMessageHandler(expectedResponse));
            PaddleHttpClient paddleHttpClient = new(httpClient, _optionsMock.Object, _loggerMock.Object);
            CustomerService customerService = new(paddleHttpClient);

            // Act
            PaddleResponse<Customer> result = await customerService.CreateCustomerAsync(newCustomer);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.Response.Should().NotBeNull();
            result.Response.Id.Should().Be("cus_123");
            result.Response.Email.Should().Be("new@example.com");
            result.Response.Name.Should().Be("New Customer");
        }

        [Fact]
        public async Task GetCustomerAddressesAsync_ValidCustomerId_ReturnsAddresses()
        {
            // Arrange
            Address[] expectedAddresses = new[]
            {
                new Address { Id = "addr_123", CountryCode = "US" },
                new Address { Id = "addr_124", CountryCode = "GB" }
            };
            PaddleResponse<Address[]> expectedResponse = new() { Success = true, Response = expectedAddresses };

            HttpClient httpClient = new(new MockHttpMessageHandler(expectedResponse));
            PaddleHttpClient paddleHttpClient = new(httpClient, _optionsMock.Object, _loggerMock.Object);
            CustomerService customerService = new(paddleHttpClient);

            // Act
            PaddleResponse<Address[]> result = await customerService.GetCustomerAddressesAsync("cus_123");

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.Response.Should().NotBeNull();
            result.Response.Should().HaveCount(2);
            result.Response[0].Id.Should().Be("addr_123");
            result.Response[1].Id.Should().Be("addr_124");
        }

        [Fact]
        public async Task GetCustomerBusinessAsync_ValidCustomerId_ReturnsBusiness()
        {
            // Arrange
            Business expectedBusiness = new()
            {
                Id = "biz_123",
                Name = "Test Business",
                TaxNumber = "123456789"
            };
            PaddleResponse<Business> expectedResponse = new() { Success = true, Response = expectedBusiness };

            HttpClient httpClient = new(new MockHttpMessageHandler(expectedResponse));
            PaddleHttpClient paddleHttpClient = new(httpClient, _optionsMock.Object, _loggerMock.Object);
            CustomerService customerService = new(paddleHttpClient);

            // Act
            PaddleResponse<Business> result = await customerService.GetCustomerBusinessAsync("cus_123");

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.Response.Should().NotBeNull();
            result.Response.Id.Should().Be("biz_123");
            result.Response.Name.Should().Be("Test Business");
            result.Response.TaxNumber.Should().Be("123456789");
        }
    }
}